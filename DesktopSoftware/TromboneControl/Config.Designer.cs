namespace TromboneControl
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.asioRadioButton = new System.Windows.Forms.RadioButton();
            this.wavRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.micSensitivityLabel = new System.Windows.Forms.Label();
            this.tofSensorSensitivityLab = new System.Windows.Forms.Label();
            this.microphoneSensitivity = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tofSensorSensitivity = new System.Windows.Forms.TrackBar();
            this.saveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.microphoneSensitivity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tofSensorSensitivity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.asioRadioButton);
            this.groupBox1.Controls.Add(this.wavRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(19, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox1.Size = new System.Drawing.Size(266, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Audio Driver for Microphone";
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // asioRadioButton
            // 
            this.asioRadioButton.AutoSize = true;
            this.asioRadioButton.Location = new System.Drawing.Point(16, 45);
            this.asioRadioButton.Margin = new System.Windows.Forms.Padding(1);
            this.asioRadioButton.Name = "asioRadioButton";
            this.asioRadioButton.Size = new System.Drawing.Size(248, 19);
            this.asioRadioButton.TabIndex = 1;
            this.asioRadioButton.TabStop = true;
            this.asioRadioButton.Text = "ASIO -requires special driver, less input lag";
            this.asioRadioButton.UseVisualStyleBackColor = true;
            // 
            // wavRadioButton
            // 
            this.wavRadioButton.AutoSize = true;
            this.wavRadioButton.Location = new System.Drawing.Point(16, 20);
            this.wavRadioButton.Margin = new System.Windows.Forms.Padding(1);
            this.wavRadioButton.Name = "wavRadioButton";
            this.wavRadioButton.Size = new System.Drawing.Size(204, 19);
            this.wavRadioButton.TabIndex = 0;
            this.wavRadioButton.TabStop = true;
            this.wavRadioButton.Text = "Default Windows - more input lag";
            this.wavRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(16, 108);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox2.Size = new System.Drawing.Size(269, 65);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ToF Sensor COM Port";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 27);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(127, 23);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.micSensitivityLabel);
            this.groupBox3.Controls.Add(this.tofSensorSensitivityLab);
            this.groupBox3.Controls.Add(this.microphoneSensitivity);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tofSensorSensitivity);
            this.groupBox3.Location = new System.Drawing.Point(16, 187);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(1);
            this.groupBox3.Size = new System.Drawing.Size(269, 132);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Calibration";
            // 
            // micSensitivityLabel
            // 
            this.micSensitivityLabel.AutoSize = true;
            this.micSensitivityLabel.Location = new System.Drawing.Point(236, 85);
            this.micSensitivityLabel.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.micSensitivityLabel.Name = "micSensitivityLabel";
            this.micSensitivityLabel.Size = new System.Drawing.Size(13, 15);
            this.micSensitivityLabel.TabIndex = 5;
            this.micSensitivityLabel.Text = "1";
            // 
            // tofSensorSensitivityLab
            // 
            this.tofSensorSensitivityLab.AutoSize = true;
            this.tofSensorSensitivityLab.Location = new System.Drawing.Point(236, 37);
            this.tofSensorSensitivityLab.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.tofSensorSensitivityLab.Name = "tofSensorSensitivityLab";
            this.tofSensorSensitivityLab.Size = new System.Drawing.Size(13, 15);
            this.tofSensorSensitivityLab.TabIndex = 4;
            this.tofSensorSensitivityLab.Text = "1";
            // 
            // microphoneSensitivity
            // 
            this.microphoneSensitivity.Location = new System.Drawing.Point(19, 85);
            this.microphoneSensitivity.Margin = new System.Windows.Forms.Padding(1);
            this.microphoneSensitivity.Minimum = 1;
            this.microphoneSensitivity.Name = "microphoneSensitivity";
            this.microphoneSensitivity.Size = new System.Drawing.Size(207, 45);
            this.microphoneSensitivity.TabIndex = 3;
            this.microphoneSensitivity.Value = 1;
            this.microphoneSensitivity.Scroll += new System.EventHandler(this.microhponeSensitivity_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Microphone Sensitivity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "ToF Sensor Sensitivity";
            // 
            // tofSensorSensitivity
            // 
            this.tofSensorSensitivity.Location = new System.Drawing.Point(19, 37);
            this.tofSensorSensitivity.Margin = new System.Windows.Forms.Padding(1);
            this.tofSensorSensitivity.Minimum = 1;
            this.tofSensorSensitivity.Name = "tofSensorSensitivity";
            this.tofSensorSensitivity.Size = new System.Drawing.Size(207, 45);
            this.tofSensorSensitivity.TabIndex = 0;
            this.tofSensorSensitivity.Value = 1;
            this.tofSensorSensitivity.Scroll += new System.EventHandler(this.tofSensorSensitivity_Scroll);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(208, 334);
            this.saveButton.Margin = new System.Windows.Forms.Padding(1);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(77, 30);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "OK";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(5, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trombone Control Beta v0.1 ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(16, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "made by";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.Location = new System.Drawing.Point(63, 356);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(91, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "@ThereminHero";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 374);
            this.ControlBox = false;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(500, 80);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Config";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Config";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.microphoneSensitivity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tofSensorSensitivity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton asioRadioButton;
        private System.Windows.Forms.RadioButton wavRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tofSensorSensitivity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar microphoneSensitivity;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label micSensitivityLabel;
        private System.Windows.Forms.Label tofSensorSensitivityLab;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}