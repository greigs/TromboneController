using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;
using NAudio.Wave;
using System;
using System.Linq;
using System.Windows.Forms;

namespace TromboneControl;

public partial class AudioLevelForm : Form
{
    public float LevelFraction { get; private set; } = 0f;
    public AsioOut AsioOut { get; private set; }
    public WaveInEvent WaveIn { get; private set; }

    private int maxPcmValue = 0;
    private int framesSinceLastRefresh = -1;
    private float[] asioData = new float[512];
    private SkiaCanvas canvas;
    private System.Drawing.Point mouseLoc;
    private Color fillColor = Color.FromArgb("#003366");
    private Config configForm;
    private KeyHandler keyHandler;
    private const int WM_HOTKEY_MSG_ID = 0x0312;
    private const int SkipRenderFrames = 3;
    private const Keys HotKey = Keys.M;

    public AudioLevelForm()
    {
        InitializeComponent();
        skglControl1.MouseMove += Form1_MouseMove;
        skglControl1.MouseDown += Form1_MouseDown;

        keyHandler = new KeyHandler(HotKey, this);
        keyHandler.Register();

        StartAudio();
    }

    private void StartAudio()
    {
        if (UserState.WavInEnabled)
        {
            WaveIn = new WaveInEvent
            {
                // DeviceNumber = 0, // customize this to select your microphone device
                WaveFormat = new WaveFormat(rate: 10000, bits: 16, channels: 1),
                BufferMilliseconds = 1
            };
            WaveIn.DataAvailable += WaveIn_DataAvailable;
            WaveIn.StartRecording();
        }
        else if (UserState.ASIOEnabled)
        {
            var names = AsioOut.GetDriverNames();
            AsioOut = new AsioOut(AsioOut.GetDriverNames().First());
            AsioOut.ShowControlPanel();
            var name = AsioOut.AsioInputChannelName(1);
            AsioOut.InputChannelOffset = 0;
            var recordChannelCount = 1;
            var sampleRate = 48000;
            AsioOut.InitRecordAndPlayback(null, recordChannelCount, sampleRate);
            AsioOut.AudioAvailable += OnAsioOutAudioAvailable;
            AsioOut.Play(); // start recording
        }
    }

    private void HandleHotkey()
    {
        UserState.ControlMouse = !UserState.ControlMouse;
        UpdateButtonLabels();
    }

    private void UpdateButtonLabels()
    {
        if (UserState.ControlMouse)
        {
            controlMouseButton.Text = "Stop (m key)";
        }
        else
        {
            controlMouseButton.Text = "Control Mouse (m key)";
        }
    }

    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_HOTKEY_MSG_ID)
            HandleHotkey();
        base.WndProc(ref m);
    }

    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        mouseLoc = e.Location;
    }

    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            int dx = e.Location.X - mouseLoc.X;
            int dy = e.Location.Y - mouseLoc.Y;
            this.Location = new System.Drawing.Point(this.Location.X + dx, this.Location.Y + dy);
        }
    }

    private void OnAsioOutAudioAvailable(object sender, AsioAudioAvailableEventArgs e)
    {
        int latestMax = int.MinValue;
        e.GetAsInterleavedSamples(asioData);
        for (int index = 0; index < asioData.Length; index++)
        {
            int value = (int)(asioData[index] * 1000f);
            if (value < 0)
            {
                value = value * -1;
            }
            latestMax = Math.Max(latestMax, value);
        }

        // report maximum relative to the maximum value previously seen
        maxPcmValue = Math.Max(maxPcmValue, latestMax);
        float fraction = (float)latestMax / maxPcmValue;

        // basic smoothing so the level does not change too quickly
        LevelFraction += (fraction - LevelFraction) * .1f;

        if (framesSinceLastRefresh < 0 || framesSinceLastRefresh > SkipRenderFrames)
        {
            skglControl1.Invalidate();
            framesSinceLastRefresh = 0;
        }
        else
        {
            framesSinceLastRefresh++;
        }
    }

    private void WaveIn_DataAvailable(object? sender, WaveInEventArgs e)
    {
        int latestMax = int.MinValue;
        for (int index = 0; index < e.BytesRecorded; index += 2)
        {
            int value = BitConverter.ToInt16(e.Buffer, index);
            latestMax = Math.Max(latestMax, value);
        }

        // report maximum relative to the maximum value previously seen
        maxPcmValue = Math.Max(maxPcmValue, latestMax);
        float fraction = (float)latestMax / maxPcmValue;

        // basic smoothing so the level does not change too quickly
        LevelFraction += (fraction - LevelFraction) * .1f;

        if (framesSinceLastRefresh < 0 || framesSinceLastRefresh > SkipRenderFrames)
        {
            skglControl1.Invalidate();
            framesSinceLastRefresh = 0;
        }
        else
        {
            framesSinceLastRefresh++;
        }
    }

    private void skglControl1_PaintSurface(object sender, SkiaSharp.Views.Desktop.SKPaintGLSurfaceEventArgs e)
    {
        float width = skglControl1.Width;
        float height = skglControl1.Height;

        if (canvas == null)
        {
            canvas = new SkiaCanvas() { Canvas = e.Surface.Canvas };                        
        }
        canvas.FillColor = fillColor;
        canvas.FillRectangle(0, 0, width, height);

        if (LevelFraction < UserState.AudioTriggerPercentageThreshold)
        {
            canvas.FillColor = Colors.LightGreen;
        }
        else
        {
            canvas.FillColor = Colors.Red;
        }
        canvas.FillRectangle(0, 0, width * LevelFraction, height);
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void controlMouseButton_Click(object sender, EventArgs e)
    {
        UserState.ControlMouse = !UserState.ControlMouse;
        UpdateButtonLabels();
    }

    private void configureButton_Click(object sender, EventArgs e)
    {
        if (configForm == null || configForm.IsDisposed)
        {
            configForm = new Config();
        }
        configForm.Show();
    }
}
