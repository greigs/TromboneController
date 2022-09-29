using Microsoft.Maui.Graphics;
using Microsoft.Maui.Graphics.Skia;
using NAudio.Wave;
using System;
using System.Linq;
using System.Windows.Forms;

namespace TromboneControl;

public partial class AudioLevelForm : Form
{
    public float LevelFraction = 0;
    int MaxPcmValue = 0;
    int framesSinceLastRefresh = -1;
    float[] asioData = new float[512];
    public AsioOut asioOut;
    SkiaCanvas _canvas;
    private System.Drawing.Point _mouseLoc;
    private Color fillColor = Color.FromArgb("#003366");
    private const int SkipRenderFrames = 3;

    public AudioLevelForm()
    {
        InitializeComponent();
        skglControl1.MouseMove += Form1_MouseMove;
        skglControl1.MouseDown += Form1_MouseDown;

        if (UserState.WavInEnabled)
        {
            var waveIn = new NAudio.Wave.WaveInEvent
            {
                DeviceNumber = 0, // customize this to select your microphone device
                WaveFormat = new NAudio.Wave.WaveFormat(rate: 10000, bits: 16, channels: 1),
                BufferMilliseconds = 1
            };
            waveIn.DataAvailable += WaveIn_DataAvailable;
            waveIn.StartRecording();
        } 
        else if (UserState.ASIOEnabled)
        {
            var names = AsioOut.GetDriverNames();
            asioOut = new AsioOut(AsioOut.GetDriverNames().First());
            //asioOut.ShowControlPanel();
            var name = asioOut.AsioInputChannelName(1);
            asioOut.InputChannelOffset = 0;
            var recordChannelCount = 1;
            var sampleRate = 48000;
            asioOut.InitRecordAndPlayback(null, recordChannelCount, sampleRate);
            asioOut.AudioAvailable += OnAsioOutAudioAvailable;
            asioOut.Play(); // start recording

        }

    }

    private void Form1_MouseDown(object sender, MouseEventArgs e)
    {
        _mouseLoc = e.Location;
    }

    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            int dx = e.Location.X - _mouseLoc.X;
            int dy = e.Location.Y - _mouseLoc.Y;
            this.Location = new System.Drawing.Point(this.Location.X + dx, this.Location.Y + dy);
        }
    }

    void OnAsioOutAudioAvailable(object sender, AsioAudioAvailableEventArgs e)
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
        MaxPcmValue = Math.Max(MaxPcmValue, latestMax);
        float fraction = (float)latestMax / MaxPcmValue;

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

    private void WaveIn_DataAvailable(object? sender, NAudio.Wave.WaveInEventArgs e)
    {
        int latestMax = int.MinValue;
        for (int index = 0; index < e.BytesRecorded; index += 2)
        {
            int value = BitConverter.ToInt16(e.Buffer, index);
            latestMax = Math.Max(latestMax, value);
        }

        // report maximum relative to the maximum value previously seen
        MaxPcmValue = Math.Max(MaxPcmValue, latestMax);
        float fraction = (float)latestMax / MaxPcmValue;

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

        if (_canvas == null)
        {
            _canvas = new SkiaCanvas() { Canvas = e.Surface.Canvas };                        
        }
        _canvas.FillColor = fillColor;
        _canvas.FillRectangle(0, 0, width, height);

        if (LevelFraction < UserState.AudioTriggerPercentageThreshold)
        {
            _canvas.FillColor = Colors.LightGreen;
        }
        else
        {
            _canvas.FillColor = Colors.Red;
        }
        _canvas.FillRectangle(0, 0, width * LevelFraction, height);
    }

    private void closeButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void controlMouseButton_Click(object sender, EventArgs e)
    {
        UserState.ControlMouse = !UserState.ControlMouse;
        if (UserState.ControlMouse)
        {
            controlMouseButton.Text = "Stop";
        }
        else
        {
            controlMouseButton.Text = "Control Mouse";
        }
    }
}
