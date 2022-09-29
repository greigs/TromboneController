using Quellatalo.Nin.TheHands;
using System;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;

namespace TromboneControl;

static class Program
{
    static MouseHandler mouseHandler;
    static bool _continue = true;
    private static int prevMouse;
    private static bool mousePressed;
    private static AudioLevelForm _audioLevelForm;
    static bool _readFromSerial = false;
    static SerialPortReader spr;
    

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        mouseHandler = new MouseHandler();
        
        if (_readFromSerial)
        {
            var readThread = new Thread(Read);
            spr = new SerialPortReader();
            spr.ConfigurePort();
            readThread.Start();
        }
     
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        _audioLevelForm = new AudioLevelForm();
        _audioLevelForm.FormClosed += _form1_FormClosed;
        Application.Run(_audioLevelForm);
    }

    private static void _form1_FormClosed(object? sender, FormClosedEventArgs e)
    {
        ExitApp();
    }

    private static void ExitApp()
    {
        _continue = false;
        _audioLevelForm.asioOut.Stop();
        _audioLevelForm.asioOut.Dispose();
        Application.Exit();
    }

    public static void Read()
    {
        while (_continue && UserState.ControlMouse)
        {
            try
            {
                string message = spr.ReadLine();
                if (int.TryParse(message, out int value))
                {
                    UpdateMouse(value);
                    if (_audioLevelForm != null)
                    {
                        if (_audioLevelForm.LevelFraction > UserState.AudioTriggerPercentageThreshold)
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

                //Console.WriteLine(message);
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

    private static void UpdateMouse(int value)
    {
        if (prevMouse == 0)
        {
            prevMouse = value;
            return;
        }
        var delta = value - prevMouse;
        mouseHandler.Move(0, 0 + delta * 5);
        prevMouse = value;
    }
}