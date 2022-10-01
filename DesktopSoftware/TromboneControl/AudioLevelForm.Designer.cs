namespace TromboneControl;

partial class AudioLevelForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.skglControl1 = new SkiaSharp.Views.Desktop.SKGLControl();
            this.controlMouseButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.configureButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // skglControl1
            // 
            this.skglControl1.BackColor = System.Drawing.Color.Black;
            this.skglControl1.Location = new System.Drawing.Point(0, 0);
            this.skglControl1.Margin = new System.Windows.Forms.Padding(0);
            this.skglControl1.Name = "skglControl1";
            this.skglControl1.Size = new System.Drawing.Size(329, 40);
            this.skglControl1.TabIndex = 0;
            this.skglControl1.VSync = true;
            this.skglControl1.PaintSurface += new System.EventHandler<SkiaSharp.Views.Desktop.SKPaintGLSurfaceEventArgs>(this.skglControl1_PaintSurface);
            // 
            // controlMouseButton
            // 
            this.controlMouseButton.Location = new System.Drawing.Point(346, 8);
            this.controlMouseButton.Margin = new System.Windows.Forms.Padding(1);
            this.controlMouseButton.Name = "controlMouseButton";
            this.controlMouseButton.Size = new System.Drawing.Size(146, 23);
            this.controlMouseButton.TabIndex = 1;
            this.controlMouseButton.Text = "Control Mouse (m key)";
            this.controlMouseButton.UseVisualStyleBackColor = true;
            this.controlMouseButton.Click += new System.EventHandler(this.controlMouseButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(641, 8);
            this.closeButton.Margin = new System.Windows.Forms.Padding(1);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(48, 23);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // configureButton
            // 
            this.configureButton.Location = new System.Drawing.Point(505, 8);
            this.configureButton.Margin = new System.Windows.Forms.Padding(1);
            this.configureButton.Name = "configureButton";
            this.configureButton.Size = new System.Drawing.Size(95, 23);
            this.configureButton.TabIndex = 3;
            this.configureButton.Text = "Configure";
            this.configureButton.UseVisualStyleBackColor = true;
            this.configureButton.Click += new System.EventHandler(this.configureButton_Click);
            // 
            // AudioLevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(700, 40);
            this.ControlBox = false;
            this.Controls.Add(this.configureButton);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.controlMouseButton);
            this.Controls.Add(this.skglControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(200, 0);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "AudioLevelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Trombone Controller";
            this.TopMost = true;
            this.ResumeLayout(false);

    }

    #endregion

    private SkiaSharp.Views.Desktop.SKGLControl skglControl1;
    private System.Windows.Forms.Button controlMouseButton;
    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.Button configureButton;
}
