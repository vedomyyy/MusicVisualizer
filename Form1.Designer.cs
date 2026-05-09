namespace MusicVisualizer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelCanvas = new Panel();
            btnSettings = new ReaLTaiizor.Controls.DreamButton();
            lblTime = new ReaLTaiizor.Controls.NightHeaderLabel();
            lblFileName = new ReaLTaiizor.Controls.NightHeaderLabel();
            trackBarVolume = new ReaLTaiizor.Controls.HopeTrackBar();
            trackBarProgress = new ReaLTaiizor.Controls.HopeTrackBar();
            dreamButton4 = new ReaLTaiizor.Controls.DreamButton();
            dreamButton3 = new ReaLTaiizor.Controls.DreamButton();
            dreamButton2 = new ReaLTaiizor.Controls.DreamButton();
            dreamButton1 = new ReaLTaiizor.Controls.DreamButton();
            panelCanvas.SuspendLayout();
            SuspendLayout();
            // 
            // panelCanvas
            // 
            panelCanvas.Controls.Add(btnSettings);
            panelCanvas.Controls.Add(lblTime);
            panelCanvas.Controls.Add(lblFileName);
            panelCanvas.Controls.Add(trackBarVolume);
            panelCanvas.Controls.Add(trackBarProgress);
            panelCanvas.Controls.Add(dreamButton4);
            panelCanvas.Controls.Add(dreamButton3);
            panelCanvas.Controls.Add(dreamButton2);
            panelCanvas.Controls.Add(dreamButton1);
            resources.ApplyResources(panelCanvas, "panelCanvas");
            panelCanvas.Name = "panelCanvas";
            // 
            // btnSettings
            // 
            btnSettings.ColorA = Color.FromArgb(31, 31, 31);
            btnSettings.ColorB = Color.FromArgb(41, 41, 41);
            btnSettings.ColorC = Color.FromArgb(51, 51, 51);
            btnSettings.ColorD = Color.FromArgb(0, 0, 0, 0);
            btnSettings.ColorE = Color.FromArgb(25, 255, 255, 255);
            resources.ApplyResources(btnSettings, "btnSettings");
            btnSettings.ForeColor = Color.FromArgb(40, 218, 255);
            btnSettings.Name = "btnSettings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // lblTime
            // 
            resources.ApplyResources(lblTime, "lblTime");
            lblTime.BackColor = Color.Transparent;
            lblTime.ForeColor = Color.FromArgb(250, 250, 250);
            lblTime.LeftSideForeColor = Color.FromArgb(250, 250, 250);
            lblTime.Name = "lblTime";
            lblTime.RightSideForeColor = Color.FromArgb(170, 171, 176);
            lblTime.Side = ReaLTaiizor.Controls.NightHeaderLabel.PanelSide.LeftPanel;
            lblTime.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            lblTime.UseCompatibleTextRendering = true;
            // 
            // lblFileName
            // 
            resources.ApplyResources(lblFileName, "lblFileName");
            lblFileName.BackColor = Color.Transparent;
            lblFileName.ForeColor = Color.FromArgb(250, 250, 250);
            lblFileName.LeftSideForeColor = Color.FromArgb(250, 250, 250);
            lblFileName.Name = "lblFileName";
            lblFileName.RightSideForeColor = Color.FromArgb(170, 171, 176);
            lblFileName.Side = ReaLTaiizor.Controls.NightHeaderLabel.PanelSide.LeftPanel;
            lblFileName.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            lblFileName.UseCompatibleTextRendering = true;
            // 
            // trackBarVolume
            // 
            trackBarVolume.AlwaysValueVisible = false;
            trackBarVolume.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackBarVolume.BallonColor = Color.FromArgb(64, 158, 255);
            trackBarVolume.BarColor = Color.FromArgb(218, 220, 223);
            trackBarVolume.BaseColor = Color.FromArgb(44, 55, 66);
            trackBarVolume.FillBarColor = Color.FromArgb(64, 158, 255);
            resources.ApplyResources(trackBarVolume, "trackBarVolume");
            trackBarVolume.ForeColor = Color.White;
            trackBarVolume.HeadBorderColor = Color.DodgerBlue;
            trackBarVolume.HeadColor = Color.Black;
            trackBarVolume.MaxValue = 10;
            trackBarVolume.MinValue = 0;
            trackBarVolume.Name = "trackBarVolume";
            trackBarVolume.ShowValue = false;
            trackBarVolume.ThemeColor = Color.FromArgb(64, 158, 255);
            trackBarVolume.UnknownColor = Color.White;
            trackBarVolume.Value = 8;
            trackBarVolume.MouseMove += trackBarVolume_MouseMove;
            // 
            // trackBarProgress
            // 
            trackBarProgress.AlwaysValueVisible = false;
            trackBarProgress.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackBarProgress.BallonColor = Color.FromArgb(64, 158, 255);
            trackBarProgress.BarColor = Color.FromArgb(218, 220, 223);
            trackBarProgress.BaseColor = Color.FromArgb(44, 55, 66);
            trackBarProgress.FillBarColor = Color.FromArgb(64, 158, 255);
            resources.ApplyResources(trackBarProgress, "trackBarProgress");
            trackBarProgress.ForeColor = Color.White;
            trackBarProgress.HeadBorderColor = Color.DodgerBlue;
            trackBarProgress.HeadColor = Color.Black;
            trackBarProgress.MaxValue = 1000;
            trackBarProgress.MinValue = 0;
            trackBarProgress.Name = "trackBarProgress";
            trackBarProgress.ShowValue = false;
            trackBarProgress.ThemeColor = Color.FromArgb(64, 158, 255);
            trackBarProgress.UnknownColor = Color.White;
            trackBarProgress.Value = 0;
            trackBarProgress.MouseDown += trackBarProgress_MouseDown;
            trackBarProgress.MouseUp += trackBarProgress_MouseUp;
            // 
            // dreamButton4
            // 
            dreamButton4.ColorA = Color.FromArgb(31, 31, 31);
            dreamButton4.ColorB = Color.FromArgb(41, 41, 41);
            dreamButton4.ColorC = Color.FromArgb(51, 51, 51);
            dreamButton4.ColorD = Color.FromArgb(0, 0, 0, 0);
            dreamButton4.ColorE = Color.FromArgb(25, 255, 255, 255);
            resources.ApplyResources(dreamButton4, "dreamButton4");
            dreamButton4.ForeColor = Color.FromArgb(40, 218, 255);
            dreamButton4.Name = "dreamButton4";
            dreamButton4.UseVisualStyleBackColor = true;
            dreamButton4.Click += btnStop_Click;
            // 
            // dreamButton3
            // 
            dreamButton3.ColorA = Color.FromArgb(31, 31, 31);
            dreamButton3.ColorB = Color.FromArgb(41, 41, 41);
            dreamButton3.ColorC = Color.FromArgb(51, 51, 51);
            dreamButton3.ColorD = Color.FromArgb(0, 0, 0, 0);
            dreamButton3.ColorE = Color.FromArgb(25, 255, 255, 255);
            resources.ApplyResources(dreamButton3, "dreamButton3");
            dreamButton3.ForeColor = Color.FromArgb(40, 218, 255);
            dreamButton3.Name = "dreamButton3";
            dreamButton3.UseVisualStyleBackColor = true;
            dreamButton3.Click += btnPause_Click;
            // 
            // dreamButton2
            // 
            dreamButton2.ColorA = Color.FromArgb(31, 31, 31);
            dreamButton2.ColorB = Color.FromArgb(41, 41, 41);
            dreamButton2.ColorC = Color.FromArgb(51, 51, 51);
            dreamButton2.ColorD = Color.FromArgb(0, 0, 0, 0);
            dreamButton2.ColorE = Color.FromArgb(25, 255, 255, 255);
            resources.ApplyResources(dreamButton2, "dreamButton2");
            dreamButton2.ForeColor = Color.FromArgb(40, 218, 255);
            dreamButton2.Name = "dreamButton2";
            dreamButton2.UseVisualStyleBackColor = true;
            dreamButton2.Click += btnPlay_Click;
            // 
            // dreamButton1
            // 
            dreamButton1.ColorA = Color.FromArgb(31, 31, 31);
            dreamButton1.ColorB = Color.FromArgb(41, 41, 41);
            dreamButton1.ColorC = Color.FromArgb(51, 51, 51);
            dreamButton1.ColorD = Color.FromArgb(0, 0, 0, 0);
            dreamButton1.ColorE = Color.FromArgb(25, 255, 255, 255);
            resources.ApplyResources(dreamButton1, "dreamButton1");
            dreamButton1.ForeColor = Color.FromArgb(40, 218, 255);
            dreamButton1.Name = "dreamButton1";
            dreamButton1.UseVisualStyleBackColor = true;
            dreamButton1.Click += btnOpen_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelCanvas);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            panelCanvas.ResumeLayout(false);
            panelCanvas.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCanvas;
        private ReaLTaiizor.Controls.DreamButton dreamButton3;
        private ReaLTaiizor.Controls.DreamButton dreamButton2;
        private ReaLTaiizor.Controls.DreamButton dreamButton1;
        private ReaLTaiizor.Controls.DreamButton dreamButton4;
        private ReaLTaiizor.Controls.HopeTrackBar trackBarProgress;
        private ReaLTaiizor.Controls.HopeTrackBar trackBarVolume;
        private ReaLTaiizor.Controls.NightHeaderLabel lblFileName;
        private ReaLTaiizor.Controls.NightHeaderLabel lblTime;
        private ReaLTaiizor.Controls.DreamButton btnSettings;
    }
}
