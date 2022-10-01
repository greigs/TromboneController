using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Windows.Forms;

namespace TromboneControl
{
    public partial class Config : Form
    {
        private const string LinkUrl = "https://youtube.com/thereminhero";
        public Config()
        {
            InitializeComponent();
            tofSensorSensitivity.Value = UserState.MouseMoveMultiplier;
            tofSensorSensitivityLab.Text = tofSensorSensitivity.Value.ToString();

            microphoneSensitivity.Value = UserState.MicSensitivitySliderValue;
            micSensitivityLabel.Text = microphoneSensitivity.Value.ToString();

            var comNames = SerialPort.GetPortNames();
            var current = UserState.ComPortName;
            comboBox1.Items.AddRange(comNames);
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(current);

            this.asioRadioButton.Checked = UserState.ASIOEnabled;
            this.wavRadioButton.Checked = !this.asioRadioButton.Checked;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Settings.Default.MouseMoveMultiplier = UserState.MouseMoveMultiplier;
            Settings.Default.MicSensitivitySliderValue = UserState.MicSensitivitySliderValue;
            Settings.Default.AudioTriggerPercentageThreshold = UserState.AudioTriggerPercentageThreshold;
            Settings.Default.SpecifyComPort = UserState.ComPortName;
            Settings.Default.Save();
            this.Close();
        }

        private void tofSensorSensitivity_Scroll(object sender, EventArgs e)
        {
            tofSensorSensitivityLab.Text = tofSensorSensitivity.Value.ToString();
            UserState.MouseMoveMultiplier = tofSensorSensitivity.Value;
        }

        private void microhponeSensitivity_Scroll(object sender, EventArgs e)
        {
            micSensitivityLabel.Text = microphoneSensitivity.Value.ToString();
            UserState.MicSensitivitySliderValue = microphoneSensitivity.Value;
            UserState.AudioTriggerPercentageThreshold = (100 - (microphoneSensitivity.Value * 9)) / 100f;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.SerialPortReader.ConfigureAndOpenPort(comboBox1.SelectedValue as string);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(LinkUrl) { UseShellExecute = true });
        }
    }
}
