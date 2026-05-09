namespace MusicVisualizer
{
    partial class SettingsForm
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
            trackHue = new ReaLTaiizor.Controls.HopeTrackBar();
            trackSaturation = new ReaLTaiizor.Controls.HopeTrackBar();
            trackBrightness = new ReaLTaiizor.Controls.HopeTrackBar();
            panelBgColor = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            trackBallSize = new ReaLTaiizor.Controls.HopeTrackBar();
            trackMaxRadius = new ReaLTaiizor.Controls.HopeTrackBar();
            trackBars = new ReaLTaiizor.Controls.HopeTrackBar();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            trackHighBoost = new ReaLTaiizor.Controls.HopeTrackBar();
            trackBassBoost = new ReaLTaiizor.Controls.HopeTrackBar();
            trackBarSmooth = new ReaLTaiizor.Controls.HopeTrackBar();
            label8 = new Label();
            chkParticles = new ReaLTaiizor.Controls.HopeCheckBox();
            trackSpawnThreshold = new ReaLTaiizor.Controls.HopeTrackBar();
            trackMaxParticles = new ReaLTaiizor.Controls.HopeTrackBar();
            label9 = new Label();
            chkGlow = new ReaLTaiizor.Controls.HopeCheckBox();
            trackGlowIntensity = new ReaLTaiizor.Controls.HopeTrackBar();
            btnOk = new ReaLTaiizor.Controls.HopeButton();
            btnApply = new ReaLTaiizor.Controls.HopeButton();
            btnCancel = new ReaLTaiizor.Controls.HopeButton();
            btnReset = new ReaLTaiizor.Controls.HopeButton();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            SuspendLayout();
            // 
            // trackHue
            // 
            trackHue.AlwaysValueVisible = false;
            trackHue.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackHue.BallonColor = Color.FromArgb(64, 158, 255);
            trackHue.BarColor = Color.FromArgb(218, 220, 223);
            trackHue.BaseColor = Color.FromArgb(44, 55, 66);
            trackHue.FillBarColor = Color.FromArgb(64, 158, 255);
            trackHue.Font = new Font("Segoe UI", 8F);
            trackHue.ForeColor = Color.White;
            trackHue.HeadBorderColor = Color.DodgerBlue;
            trackHue.HeadColor = Color.Black;
            trackHue.Location = new Point(225, 49);
            trackHue.MaxValue = 360;
            trackHue.MinValue = 0;
            trackHue.Name = "trackHue";
            trackHue.ShowValue = false;
            trackHue.Size = new Size(176, 16);
            trackHue.TabIndex = 2;
            trackHue.Text = "hopeTrackBar1";
            trackHue.ThemeColor = Color.FromArgb(64, 158, 255);
            trackHue.UnknownColor = Color.White;
            trackHue.Value = 0;
            // 
            // trackSaturation
            // 
            trackSaturation.AlwaysValueVisible = false;
            trackSaturation.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackSaturation.BallonColor = Color.FromArgb(64, 158, 255);
            trackSaturation.BarColor = Color.FromArgb(218, 220, 223);
            trackSaturation.BaseColor = Color.FromArgb(44, 55, 66);
            trackSaturation.FillBarColor = Color.FromArgb(64, 158, 255);
            trackSaturation.Font = new Font("Segoe UI", 8F);
            trackSaturation.ForeColor = Color.White;
            trackSaturation.HeadBorderColor = Color.DodgerBlue;
            trackSaturation.HeadColor = Color.Black;
            trackSaturation.Location = new Point(225, 87);
            trackSaturation.MaxValue = 200;
            trackSaturation.MinValue = 0;
            trackSaturation.Name = "trackSaturation";
            trackSaturation.ShowValue = false;
            trackSaturation.Size = new Size(176, 16);
            trackSaturation.TabIndex = 3;
            trackSaturation.Text = "hopeTrackBar2";
            trackSaturation.ThemeColor = Color.FromArgb(64, 158, 255);
            trackSaturation.UnknownColor = Color.White;
            trackSaturation.Value = 0;
            // 
            // trackBrightness
            // 
            trackBrightness.AlwaysValueVisible = false;
            trackBrightness.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackBrightness.BallonColor = Color.FromArgb(64, 158, 255);
            trackBrightness.BarColor = Color.FromArgb(218, 220, 223);
            trackBrightness.BaseColor = Color.FromArgb(44, 55, 66);
            trackBrightness.FillBarColor = Color.FromArgb(64, 158, 255);
            trackBrightness.Font = new Font("Segoe UI", 8F);
            trackBrightness.ForeColor = Color.White;
            trackBrightness.HeadBorderColor = Color.DodgerBlue;
            trackBrightness.HeadColor = Color.Black;
            trackBrightness.Location = new Point(225, 124);
            trackBrightness.MaxValue = 200;
            trackBrightness.MinValue = 0;
            trackBrightness.Name = "trackBrightness";
            trackBrightness.ShowValue = false;
            trackBrightness.Size = new Size(176, 16);
            trackBrightness.TabIndex = 4;
            trackBrightness.Text = "hopeTrackBar3";
            trackBrightness.ThemeColor = Color.FromArgb(64, 158, 255);
            trackBrightness.UnknownColor = Color.White;
            trackBrightness.Value = 0;
            // 
            // panelBgColor
            // 
            panelBgColor.Location = new Point(128, 161);
            panelBgColor.Name = "panelBgColor";
            panelBgColor.Size = new Size(45, 35);
            panelBgColor.TabIndex = 5;
            panelBgColor.Click += panelBgColor_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 45);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 6;
            label1.Text = "Сдвиг цвета";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 87);
            label2.Name = "label2";
            label2.Size = new Size(114, 20);
            label2.TabIndex = 7;
            label2.Text = "Насыщенность";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 124);
            label3.Name = "label3";
            label3.Size = new Size(64, 20);
            label3.TabIndex = 8;
            label3.Text = "Яркость";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 176);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 9;
            label4.Text = "Фон";
            // 
            // trackBallSize
            // 
            trackBallSize.AlwaysValueVisible = false;
            trackBallSize.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackBallSize.BallonColor = Color.FromArgb(64, 158, 255);
            trackBallSize.BarColor = Color.FromArgb(218, 220, 223);
            trackBallSize.BaseColor = Color.FromArgb(44, 55, 66);
            trackBallSize.FillBarColor = Color.FromArgb(64, 158, 255);
            trackBallSize.Font = new Font("Segoe UI", 8F);
            trackBallSize.ForeColor = Color.White;
            trackBallSize.HeadBorderColor = Color.DodgerBlue;
            trackBallSize.HeadColor = Color.Black;
            trackBallSize.Location = new Point(612, 49);
            trackBallSize.MaxValue = 55;
            trackBallSize.MinValue = 0;
            trackBallSize.Name = "trackBallSize";
            trackBallSize.ShowValue = false;
            trackBallSize.Size = new Size(176, 16);
            trackBallSize.TabIndex = 10;
            trackBallSize.Text = "hopeTrackBar1";
            trackBallSize.ThemeColor = Color.FromArgb(64, 158, 255);
            trackBallSize.UnknownColor = Color.White;
            trackBallSize.Value = 20;
            // 
            // trackMaxRadius
            // 
            trackMaxRadius.AlwaysValueVisible = false;
            trackMaxRadius.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackMaxRadius.BallonColor = Color.FromArgb(64, 158, 255);
            trackMaxRadius.BarColor = Color.FromArgb(218, 220, 223);
            trackMaxRadius.BaseColor = Color.FromArgb(44, 55, 66);
            trackMaxRadius.FillBarColor = Color.FromArgb(64, 158, 255);
            trackMaxRadius.Font = new Font("Segoe UI", 8F);
            trackMaxRadius.ForeColor = Color.White;
            trackMaxRadius.HeadBorderColor = Color.DodgerBlue;
            trackMaxRadius.HeadColor = Color.Black;
            trackMaxRadius.Location = new Point(612, 91);
            trackMaxRadius.MaxValue = 60;
            trackMaxRadius.MinValue = 0;
            trackMaxRadius.Name = "trackMaxRadius";
            trackMaxRadius.ShowValue = false;
            trackMaxRadius.Size = new Size(176, 16);
            trackMaxRadius.TabIndex = 11;
            trackMaxRadius.Text = "hopeTrackBar2";
            trackMaxRadius.ThemeColor = Color.FromArgb(64, 158, 255);
            trackMaxRadius.UnknownColor = Color.White;
            trackMaxRadius.Value = 60;
            // 
            // trackBars
            // 
            trackBars.AlwaysValueVisible = false;
            trackBars.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackBars.BallonColor = Color.FromArgb(64, 158, 255);
            trackBars.BarColor = Color.FromArgb(218, 220, 223);
            trackBars.BaseColor = Color.FromArgb(44, 55, 66);
            trackBars.FillBarColor = Color.FromArgb(64, 158, 255);
            trackBars.Font = new Font("Segoe UI", 8F);
            trackBars.ForeColor = Color.White;
            trackBars.HeadBorderColor = Color.DodgerBlue;
            trackBars.HeadColor = Color.Black;
            trackBars.Location = new Point(612, 128);
            trackBars.MaxValue = 256;
            trackBars.MinValue = 0;
            trackBars.Name = "trackBars";
            trackBars.ShowValue = false;
            trackBars.Size = new Size(176, 16);
            trackBars.TabIndex = 12;
            trackBars.Text = "hopeTrackBar3";
            trackBars.ThemeColor = Color.FromArgb(64, 158, 255);
            trackBars.UnknownColor = Color.White;
            trackBars.Value = 128;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(26, 9);
            label5.Name = "label5";
            label5.Size = new Size(42, 20);
            label5.TabIndex = 13;
            label5.Text = "Цвет";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(557, 9);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 14;
            label6.Text = "Геометрия";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(26, 235);
            label7.Name = "label7";
            label7.Size = new Size(60, 20);
            label7.TabIndex = 15;
            label7.Text = "Физика";
            // 
            // trackHighBoost
            // 
            trackHighBoost.AlwaysValueVisible = false;
            trackHighBoost.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackHighBoost.BallonColor = Color.FromArgb(64, 158, 255);
            trackHighBoost.BarColor = Color.FromArgb(218, 220, 223);
            trackHighBoost.BaseColor = Color.FromArgb(44, 55, 66);
            trackHighBoost.FillBarColor = Color.FromArgb(64, 158, 255);
            trackHighBoost.Font = new Font("Segoe UI", 8F);
            trackHighBoost.ForeColor = Color.White;
            trackHighBoost.HeadBorderColor = Color.DodgerBlue;
            trackHighBoost.HeadColor = Color.Black;
            trackHighBoost.Location = new Point(225, 345);
            trackHighBoost.MaxValue = 30;
            trackHighBoost.MinValue = 0;
            trackHighBoost.Name = "trackHighBoost";
            trackHighBoost.ShowValue = false;
            trackHighBoost.Size = new Size(176, 16);
            trackHighBoost.TabIndex = 18;
            trackHighBoost.Text = "hopeTrackBar3";
            trackHighBoost.ThemeColor = Color.FromArgb(64, 158, 255);
            trackHighBoost.UnknownColor = Color.White;
            trackHighBoost.Value = 12;
            // 
            // trackBassBoost
            // 
            trackBassBoost.AlwaysValueVisible = false;
            trackBassBoost.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackBassBoost.BallonColor = Color.FromArgb(64, 158, 255);
            trackBassBoost.BarColor = Color.FromArgb(218, 220, 223);
            trackBassBoost.BaseColor = Color.FromArgb(44, 55, 66);
            trackBassBoost.FillBarColor = Color.FromArgb(64, 158, 255);
            trackBassBoost.Font = new Font("Segoe UI", 8F);
            trackBassBoost.ForeColor = Color.White;
            trackBassBoost.HeadBorderColor = Color.DodgerBlue;
            trackBassBoost.HeadColor = Color.Black;
            trackBassBoost.Location = new Point(225, 308);
            trackBassBoost.MaxValue = 50;
            trackBassBoost.MinValue = 0;
            trackBassBoost.Name = "trackBassBoost";
            trackBassBoost.ShowValue = false;
            trackBassBoost.Size = new Size(176, 16);
            trackBassBoost.TabIndex = 17;
            trackBassBoost.Text = "hopeTrackBar2";
            trackBassBoost.ThemeColor = Color.FromArgb(64, 158, 255);
            trackBassBoost.UnknownColor = Color.White;
            trackBassBoost.Value = 25;
            // 
            // trackBarSmooth
            // 
            trackBarSmooth.AlwaysValueVisible = false;
            trackBarSmooth.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackBarSmooth.BallonColor = Color.FromArgb(64, 158, 255);
            trackBarSmooth.BarColor = Color.FromArgb(218, 220, 223);
            trackBarSmooth.BaseColor = Color.FromArgb(44, 55, 66);
            trackBarSmooth.FillBarColor = Color.FromArgb(64, 158, 255);
            trackBarSmooth.Font = new Font("Segoe UI", 8F);
            trackBarSmooth.ForeColor = Color.White;
            trackBarSmooth.HeadBorderColor = Color.DodgerBlue;
            trackBarSmooth.HeadColor = Color.Black;
            trackBarSmooth.Location = new Point(225, 270);
            trackBarSmooth.MaxValue = 90;
            trackBarSmooth.MinValue = 0;
            trackBarSmooth.Name = "trackBarSmooth";
            trackBarSmooth.ShowValue = false;
            trackBarSmooth.Size = new Size(176, 16);
            trackBarSmooth.TabIndex = 16;
            trackBarSmooth.Text = "hopeTrackBar1";
            trackBarSmooth.ThemeColor = Color.FromArgb(64, 158, 255);
            trackBarSmooth.UnknownColor = Color.White;
            trackBarSmooth.Value = 45;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(521, 176);
            label8.Name = "label8";
            label8.Size = new Size(69, 20);
            label8.TabIndex = 19;
            label8.Text = "Частицы";
            // 
            // chkParticles
            // 
            chkParticles.AutoSize = true;
            chkParticles.Checked = true;
            chkParticles.CheckedColor = Color.FromArgb(64, 158, 255);
            chkParticles.CheckState = CheckState.Checked;
            chkParticles.DisabledColor = Color.FromArgb(196, 198, 202);
            chkParticles.DisabledStringColor = Color.FromArgb(186, 187, 189);
            chkParticles.Enable = true;
            chkParticles.EnabledCheckedColor = Color.FromArgb(64, 158, 255);
            chkParticles.EnabledStringColor = Color.FromArgb(153, 153, 153);
            chkParticles.EnabledUncheckedColor = Color.FromArgb(156, 158, 161);
            chkParticles.Font = new Font("Segoe UI", 12F);
            chkParticles.ForeColor = Color.FromArgb(48, 49, 51);
            chkParticles.Location = new Point(521, 207);
            chkParticles.Name = "chkParticles";
            chkParticles.Size = new Size(25, 20);
            chkParticles.TabIndex = 20;
            chkParticles.UseVisualStyleBackColor = true;
            // 
            // trackSpawnThreshold
            // 
            trackSpawnThreshold.AlwaysValueVisible = false;
            trackSpawnThreshold.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackSpawnThreshold.BallonColor = Color.FromArgb(64, 158, 255);
            trackSpawnThreshold.BarColor = Color.FromArgb(218, 220, 223);
            trackSpawnThreshold.BaseColor = Color.FromArgb(44, 55, 66);
            trackSpawnThreshold.FillBarColor = Color.FromArgb(64, 158, 255);
            trackSpawnThreshold.Font = new Font("Segoe UI", 8F);
            trackSpawnThreshold.ForeColor = Color.White;
            trackSpawnThreshold.HeadBorderColor = Color.DodgerBlue;
            trackSpawnThreshold.HeadColor = Color.Black;
            trackSpawnThreshold.Location = new Point(612, 287);
            trackSpawnThreshold.MaxValue = 80;
            trackSpawnThreshold.MinValue = 0;
            trackSpawnThreshold.Name = "trackSpawnThreshold";
            trackSpawnThreshold.ShowValue = false;
            trackSpawnThreshold.Size = new Size(176, 16);
            trackSpawnThreshold.TabIndex = 22;
            trackSpawnThreshold.Text = "hopeTrackBar2";
            trackSpawnThreshold.ThemeColor = Color.FromArgb(64, 158, 255);
            trackSpawnThreshold.UnknownColor = Color.White;
            trackSpawnThreshold.Value = 24;
            // 
            // trackMaxParticles
            // 
            trackMaxParticles.AlwaysValueVisible = false;
            trackMaxParticles.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackMaxParticles.BallonColor = Color.FromArgb(64, 158, 255);
            trackMaxParticles.BarColor = Color.FromArgb(218, 220, 223);
            trackMaxParticles.BaseColor = Color.FromArgb(44, 55, 66);
            trackMaxParticles.FillBarColor = Color.FromArgb(64, 158, 255);
            trackMaxParticles.Font = new Font("Segoe UI", 8F);
            trackMaxParticles.ForeColor = Color.White;
            trackMaxParticles.HeadBorderColor = Color.DodgerBlue;
            trackMaxParticles.HeadColor = Color.Black;
            trackMaxParticles.Location = new Point(612, 249);
            trackMaxParticles.MaxValue = 500;
            trackMaxParticles.MinValue = 0;
            trackMaxParticles.Name = "trackMaxParticles";
            trackMaxParticles.ShowValue = false;
            trackMaxParticles.Size = new Size(176, 16);
            trackMaxParticles.TabIndex = 21;
            trackMaxParticles.Text = "hopeTrackBar1";
            trackMaxParticles.ThemeColor = Color.FromArgb(64, 158, 255);
            trackMaxParticles.UnknownColor = Color.White;
            trackMaxParticles.Value = 220;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(35, 390);
            label9.Name = "label9";
            label9.Size = new Size(76, 20);
            label9.TabIndex = 23;
            label9.Text = "Свечение";
            // 
            // chkGlow
            // 
            chkGlow.AutoSize = true;
            chkGlow.Checked = true;
            chkGlow.CheckedColor = Color.FromArgb(64, 158, 255);
            chkGlow.CheckState = CheckState.Checked;
            chkGlow.DisabledColor = Color.FromArgb(196, 198, 202);
            chkGlow.DisabledStringColor = Color.FromArgb(186, 187, 189);
            chkGlow.Enable = true;
            chkGlow.EnabledCheckedColor = Color.FromArgb(64, 158, 255);
            chkGlow.EnabledStringColor = Color.FromArgb(153, 153, 153);
            chkGlow.EnabledUncheckedColor = Color.FromArgb(156, 158, 161);
            chkGlow.Font = new Font("Segoe UI", 12F);
            chkGlow.ForeColor = Color.FromArgb(48, 49, 51);
            chkGlow.Location = new Point(139, 424);
            chkGlow.Name = "chkGlow";
            chkGlow.Size = new Size(25, 20);
            chkGlow.TabIndex = 24;
            chkGlow.UseVisualStyleBackColor = true;
            // 
            // trackGlowIntensity
            // 
            trackGlowIntensity.AlwaysValueVisible = false;
            trackGlowIntensity.BallonArrowColor = Color.FromArgb(64, 158, 255);
            trackGlowIntensity.BallonColor = Color.FromArgb(64, 158, 255);
            trackGlowIntensity.BarColor = Color.FromArgb(218, 220, 223);
            trackGlowIntensity.BaseColor = Color.FromArgb(44, 55, 66);
            trackGlowIntensity.FillBarColor = Color.FromArgb(64, 158, 255);
            trackGlowIntensity.Font = new Font("Segoe UI", 8F);
            trackGlowIntensity.ForeColor = Color.White;
            trackGlowIntensity.HeadBorderColor = Color.DodgerBlue;
            trackGlowIntensity.HeadColor = Color.Black;
            trackGlowIntensity.Location = new Point(225, 466);
            trackGlowIntensity.MaxValue = 200;
            trackGlowIntensity.MinValue = 0;
            trackGlowIntensity.Name = "trackGlowIntensity";
            trackGlowIntensity.ShowValue = false;
            trackGlowIntensity.Size = new Size(176, 16);
            trackGlowIntensity.TabIndex = 25;
            trackGlowIntensity.Text = "hopeTrackBar2";
            trackGlowIntensity.ThemeColor = Color.FromArgb(64, 158, 255);
            trackGlowIntensity.UnknownColor = Color.White;
            trackGlowIntensity.Value = 100;
            // 
            // btnOk
            // 
            btnOk.BorderColor = Color.FromArgb(220, 223, 230);
            btnOk.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnOk.DangerColor = Color.FromArgb(245, 108, 108);
            btnOk.DefaultColor = Color.FromArgb(255, 255, 255);
            btnOk.Font = new Font("Segoe UI", 12F);
            btnOk.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnOk.InfoColor = Color.FromArgb(144, 147, 153);
            btnOk.Location = new Point(474, 400);
            btnOk.Name = "btnOk";
            btnOk.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnOk.Size = new Size(116, 44);
            btnOk.SuccessColor = Color.FromArgb(103, 194, 58);
            btnOk.TabIndex = 26;
            btnOk.Text = "OK";
            btnOk.TextColor = Color.White;
            btnOk.WarningColor = Color.FromArgb(230, 162, 60);
            btnOk.Click += btnOk_Click;
            // 
            // btnApply
            // 
            btnApply.BorderColor = Color.FromArgb(220, 223, 230);
            btnApply.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnApply.DangerColor = Color.FromArgb(245, 108, 108);
            btnApply.DefaultColor = Color.FromArgb(255, 255, 255);
            btnApply.Font = new Font("Segoe UI", 12F);
            btnApply.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnApply.InfoColor = Color.FromArgb(144, 147, 153);
            btnApply.Location = new Point(642, 400);
            btnApply.Name = "btnApply";
            btnApply.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnApply.Size = new Size(116, 44);
            btnApply.SuccessColor = Color.FromArgb(103, 194, 58);
            btnApply.TabIndex = 27;
            btnApply.Text = "Применить";
            btnApply.TextColor = Color.White;
            btnApply.WarningColor = Color.FromArgb(230, 162, 60);
            btnApply.Click += btnApply_Click;
            // 
            // btnCancel
            // 
            btnCancel.BorderColor = Color.FromArgb(220, 223, 230);
            btnCancel.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnCancel.DangerColor = Color.FromArgb(245, 108, 108);
            btnCancel.DefaultColor = Color.FromArgb(255, 255, 255);
            btnCancel.Font = new Font("Segoe UI", 12F);
            btnCancel.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnCancel.InfoColor = Color.FromArgb(144, 147, 153);
            btnCancel.Location = new Point(474, 466);
            btnCancel.Name = "btnCancel";
            btnCancel.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnCancel.Size = new Size(116, 44);
            btnCancel.SuccessColor = Color.FromArgb(103, 194, 58);
            btnCancel.TabIndex = 28;
            btnCancel.Text = "Отмена";
            btnCancel.TextColor = Color.White;
            btnCancel.WarningColor = Color.FromArgb(230, 162, 60);
            btnCancel.Click += btnCancel_Click;
            // 
            // btnReset
            // 
            btnReset.BorderColor = Color.FromArgb(220, 223, 230);
            btnReset.ButtonType = ReaLTaiizor.Util.HopeButtonType.Primary;
            btnReset.DangerColor = Color.FromArgb(245, 108, 108);
            btnReset.DefaultColor = Color.FromArgb(255, 255, 255);
            btnReset.Font = new Font("Segoe UI", 12F);
            btnReset.HoverTextColor = Color.FromArgb(48, 49, 51);
            btnReset.InfoColor = Color.FromArgb(144, 147, 153);
            btnReset.Location = new Point(642, 466);
            btnReset.Name = "btnReset";
            btnReset.PrimaryColor = Color.FromArgb(64, 158, 255);
            btnReset.Size = new Size(116, 44);
            btnReset.SuccessColor = Color.FromArgb(103, 194, 58);
            btnReset.TabIndex = 29;
            btnReset.Text = "Сбросить";
            btnReset.TextColor = Color.White;
            btnReset.WarningColor = Color.FromArgb(230, 162, 60);
            btnReset.Click += btnReset_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(424, 49);
            label10.Name = "label10";
            label10.Size = new Size(101, 20);
            label10.TabIndex = 30;
            label10.Text = "Размер шара";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(424, 91);
            label11.Name = "label11";
            label11.Size = new Size(158, 20);
            label11.TabIndex = 31;
            label11.Text = "Радиус визуализации";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(424, 128);
            label12.Name = "label12";
            label12.Size = new Size(136, 20);
            label12.TabIndex = 32;
            label12.Text = "Количество полос";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(26, 270);
            label13.Name = "label13";
            label13.Size = new Size(129, 20);
            label13.TabIndex = 33;
            label13.Text = "Плавность полос";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(26, 304);
            label14.Name = "label14";
            label14.Size = new Size(112, 20);
            label14.TabIndex = 34;
            label14.Text = "Усиление баса";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(26, 341);
            label15.Name = "label15";
            label15.Size = new Size(138, 20);
            label15.TabIndex = 35;
            label15.Text = "Усиление высоких";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(26, 426);
            label16.Name = "label16";
            label16.Size = new Size(76, 20);
            label16.TabIndex = 36;
            label16.Text = "Свечение";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(26, 462);
            label17.Name = "label17";
            label17.Size = new Size(184, 20);
            label17.TabIndex = 37;
            label17.Text = "Интенсивность свечения";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(424, 207);
            label18.Name = "label18";
            label18.Size = new Size(69, 20);
            label18.TabIndex = 38;
            label18.Text = "Частицы";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(424, 245);
            label19.Name = "label19";
            label19.Size = new Size(98, 20);
            label19.TabIndex = 39;
            label19.Text = "Макс. частиц";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(424, 282);
            label20.Name = "label20";
            label20.Size = new Size(184, 20);
            label20.TabIndex = 40;
            label20.Text = "Порог появления частиц";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 548);
            Controls.Add(label20);
            Controls.Add(label19);
            Controls.Add(label18);
            Controls.Add(label17);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(btnReset);
            Controls.Add(btnCancel);
            Controls.Add(btnApply);
            Controls.Add(btnOk);
            Controls.Add(trackGlowIntensity);
            Controls.Add(chkGlow);
            Controls.Add(label9);
            Controls.Add(trackSpawnThreshold);
            Controls.Add(trackMaxParticles);
            Controls.Add(chkParticles);
            Controls.Add(label8);
            Controls.Add(trackHighBoost);
            Controls.Add(trackBassBoost);
            Controls.Add(trackBarSmooth);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(trackBars);
            Controls.Add(trackMaxRadius);
            Controls.Add(trackBallSize);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelBgColor);
            Controls.Add(trackBrightness);
            Controls.Add(trackSaturation);
            Controls.Add(trackHue);
            Name = "SettingsForm";
            Text = "SettingsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.HopeTrackBar trackHue;
        private ReaLTaiizor.Controls.HopeTrackBar trackSaturation;
        private ReaLTaiizor.Controls.HopeTrackBar trackBrightness;
        private Panel panelBgColor;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ReaLTaiizor.Controls.HopeTrackBar trackBallSize;
        private ReaLTaiizor.Controls.HopeTrackBar trackMaxRadius;
        private ReaLTaiizor.Controls.HopeTrackBar trackBars;
        private Label label5;
        private Label label6;
        private Label label7;
        private ReaLTaiizor.Controls.HopeTrackBar trackHighBoost;
        private ReaLTaiizor.Controls.HopeTrackBar trackBassBoost;
        private ReaLTaiizor.Controls.HopeTrackBar trackBarSmooth;
        private Label label8;
        private ReaLTaiizor.Controls.HopeCheckBox chkParticles;
        private ReaLTaiizor.Controls.HopeTrackBar trackSpawnThreshold;
        private ReaLTaiizor.Controls.HopeTrackBar trackMaxParticles;
        private Label label9;
        private ReaLTaiizor.Controls.HopeCheckBox chkGlow;
        private ReaLTaiizor.Controls.HopeTrackBar trackGlowIntensity;
        private ReaLTaiizor.Controls.HopeButton btnOk;
        private ReaLTaiizor.Controls.HopeButton btnApply;
        private ReaLTaiizor.Controls.HopeButton btnCancel;
        private ReaLTaiizor.Controls.HopeButton btnReset;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
    }
}