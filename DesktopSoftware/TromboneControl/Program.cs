using Quellatalo.Nin.TheHands;
using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using Extreme.Mathematics.SignalProcessing;
using Extreme.Mathematics;

namespace TromboneControl;

public static class Program
{
    public static SerialPortReader SerialPortReader { get; private set; }

    private static Func<Vector<double>, Vector<double>> smootherFunc;
    private static MouseHandler mouseHandler;
    private static bool continueReadingFromComPort = true;
    private static int prevMouse;
    private static bool mousePressed;
    private static AudioLevelForm audioLevelForm;
    private const int QueueCapacity = 5;
    private const int DeadZoneThreshold = 2;
    private static Queue<int> tofValues = new Queue<int>(QueueCapacity);
    
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // COM Port retry loop until there is at least one
        if (!CheckAtLeastOneComPort())
        {
            return; // Exit if no com ports
        }

        WarnIfMoreThanOneComPort();

        smootherFunc = Smoothing.MovingAverageSmoother(QueueCapacity, Extreme.Mathematics.SignalProcessing.Padding.None);

        mouseHandler = new MouseHandler();
        
        // Start COM port Serial read
        var readThread = new Thread(ReadFromToFSensor);
        SerialPortReader = new SerialPortReader();
        SerialPortReader.ConfigureAndOpenPort(Settings.Default.SpecifyComPort);
        if (!UserState.ComPortOpened)
        {
            MessageBox.Show("Could not open COM port. Already in use? Exiting", "Error", MessageBoxButtons.OK);
            return; // Exit if port could be opened.
        }
        readThread.Start();
        
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        audioLevelForm = new AudioLevelForm();
        audioLevelForm.FormClosed += _form1_FormClosed;
        Application.Run(audioLevelForm);
    }

    private static bool CheckAtLeastOneComPort()
    {
        DialogResult result = DialogResult.Retry;
        while (!SerialPort.GetPortNames().Any() && result == DialogResult.Retry)
        {
            result = MessageBox.Show("No COM ports found. Check ToF sensor is connected.", "No COM ports found", MessageBoxButtons.RetryCancel);
        }
        return result != DialogResult.Cancel;
    }

    private static void WarnIfMoreThanOneComPort()
    {
        if (SerialPort.GetPortNames().Count() > 1)
        {
            MessageBox.Show("More than one COM port found, check the correct one is selected in configuration", "Warning", MessageBoxButtons.OK);
        }
    }

    private static void _form1_FormClosed(object? sender, FormClosedEventArgs e)
    {
        ExitApp();
    }

    private static void ExitApp()
    {
        continueReadingFromComPort = false;
        if (audioLevelForm?.AsioOut != null)
        {
            audioLevelForm.AsioOut.Stop();
            audioLevelForm.AsioOut.Dispose();
        }

        if (audioLevelForm?.WaveIn != null)
        {
            audioLevelForm.WaveIn.StopRecording();
            audioLevelForm.WaveIn.Dispose();
        }

        if (UserState.ComPortOpened)
        {
            SerialPortReader.CloseAndDispose();
        }

        Application.Exit();
    }

    public static void ReadFromToFSensor()
    {
        while (continueReadingFromComPort && UserState.ComPortOpened)
        {
            try
            {
                string message = SerialPortReader.ReadLine();
                if (int.TryParse(message, out int value))
                {
                    if (tofValues.Count == QueueCapacity)
                    {
                        tofValues.Dequeue();
                    }
                    while (tofValues.Count < QueueCapacity)
                    {
                        tofValues.Enqueue(value);
                    }
                    var smoothed = LatestSmoothedValueFromQueue();
                    if (UserState.ControlMouse)
                    {
                        UpdateMousePosition(smoothed);
                        if (audioLevelForm != null)
                        {
                            if (audioLevelForm.LevelFraction > UserState.AudioTriggerPercentageThreshold)
                            {
                                if (!mousePressed)
                                {
                                    mouseHandler.LeftDown();
                                    mousePressed = true;
                                }
                            }
                            else
                            {
                                if (mousePressed)
                                {
                                    mouseHandler.LeftUp();
                                    mousePressed = false;
                                }
                            }
                        }
                    }
                }
            }
            catch (TimeoutException)
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

    private static void UpdateMousePosition(int value)
    {
        if (prevMouse == 0)
        {
            prevMouse = value;
            return;
        }

        var delta = value - prevMouse;
        mouseHandler.Move(0, 0 + delta * UserState.MouseMoveMultiplier);
        prevMouse = value;
    }

    private static int LatestSmoothedValueFromQueue()
    {
        
        Vector<double> unsmoothedData = Vector.Create(tofValues.Select(x => (double)x).ToArray());

        var result = smootherFunc(unsmoothedData);
        var first = (int)Math.Round((decimal)result.First());
        var last = (int)Math.Round((decimal)result.Last());
        //var first = (int)unsmoothedData.First();
        //var last = (int)unsmoothedData.Last();
        var delta = Math.Abs(first - last);
        if (delta < DeadZoneThreshold)
        {
            return prevMouse;
        }
        return last;
    }
}