using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusicVisualizer
{
    public partial class SettingsForm : Form
    {
        private readonly VisualizerSettings _s;
        private readonly VisualizerPanel _visual;

        public SettingsForm(VisualizerSettings settings, VisualizerPanel visual)
        {
            InitializeComponent();
            _s = settings;
            _visual = visual;

            // Устанавливаем границы вручную в правильном порядке
            trackHue.MinValue = 0; trackHue.MaxValue = 360;
            trackSaturation.MinValue = 0; trackSaturation.MaxValue = 200;
            trackBrightness.MinValue = 0; trackBrightness.MaxValue = 200;
            trackBallSize.MinValue = 20; trackBallSize.MaxValue = 55;
            trackMaxRadius.MinValue = 30; trackMaxRadius.MaxValue = 60;
            trackBars.MinValue = 32; trackBars.MaxValue = 256;
            trackBarSmooth.MinValue = 10; trackBarSmooth.MaxValue = 90;
            trackBassBoost.MinValue = 10; trackBassBoost.MaxValue = 50;
            trackHighBoost.MinValue = 0; trackHighBoost.MaxValue = 30;
            trackMaxParticles.MinValue = 0; trackMaxParticles.MaxValue = 500;
            trackSpawnThreshold.MinValue = 5; trackSpawnThreshold.MaxValue = 80;
            trackGlowIntensity.MinValue = 0; trackGlowIntensity.MaxValue = 200;

            LoadToControls();
            // подписки на события...
        }

        // Загружаем текущие значения настроек в контролы
        private void LoadToControls()
        {
            // Цвет
            trackHue.Value = (int)_s.HueShift;           // 0..360
            trackSaturation.Value = (int)(_s.Saturation * 100); // 0..200
            trackBrightness.Value = (int)(_s.Brightness * 100); // 0..200
            panelBgColor.BackColor = Color.FromArgb(_s.BackgroundR, _s.BackgroundG, _s.BackgroundB);

            // Геометрия
            trackBallSize.Value = (int)(_s.BallSizeRatio * 100);   // 20..55
            trackMaxRadius.Value = (int)(_s.MaxRadiusRatio * 100);  // 30..60
            trackBars.Value = _s.Bars;                          // 32..256

            // Физика
            trackBarSmooth.Value = (int)(_s.BarSmoothing * 100);    // 10..90
            trackBassBoost.Value = (int)(_s.BassBoost * 10);        // 10..50
            trackHighBoost.Value = (int)(_s.HighFreqBoost * 10);    // 0..30

            // Частицы
            chkParticles.Checked = _s.ParticlesEnabled;
            trackMaxParticles.Value = _s.MaxParticles;                 // 0..500
            trackSpawnThreshold.Value = (int)(_s.SpawnThreshold * 100); // 5..80

            // Свечение
            chkGlow.Checked = _s.GlowEnabled;
            trackGlowIntensity.Value = (int)(_s.GlowIntensity * 100); // 0..200
        }

        // Кнопка «Применить»
        private void btnApply_Click(object sender, EventArgs e)
        {
            SaveFromControls();
            _s.Save();
        }

        // Кнопка «OK» — применить и закрыть
        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveFromControls();
            _s.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        // Кнопка «Отмена»
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Кнопка «Сбросить» — вернуть дефолтные значения
        private void btnReset_Click(object sender, EventArgs e)
        {
            var def = new VisualizerSettings();
            _s.HueShift = def.HueShift;
            _s.Saturation = def.Saturation;
            _s.Brightness = def.Brightness;
            _s.BackgroundR = def.BackgroundR;
            _s.BackgroundG = def.BackgroundG;
            _s.BackgroundB = def.BackgroundB;
            _s.BallSizeRatio = def.BallSizeRatio;
            _s.MaxRadiusRatio = def.MaxRadiusRatio;
            _s.Bars = def.Bars;
            _s.BarSmoothing = def.BarSmoothing;
            _s.BassBoost = def.BassBoost;
            _s.HighFreqBoost = def.HighFreqBoost;
            _s.ParticlesEnabled = def.ParticlesEnabled;
            _s.MaxParticles = def.MaxParticles;
            _s.SpawnThreshold = def.SpawnThreshold;
            _s.GlowEnabled = def.GlowEnabled;
            _s.GlowIntensity = def.GlowIntensity;
            LoadToControls();
        }

        // Выбор фонового цвета через стандартный ColorDialog
        private void panelBgColor_Click(object sender, EventArgs e)
        {
            using var dlg = new ColorDialog { Color = panelBgColor.BackColor };
            if (dlg.ShowDialog() == DialogResult.OK)
                panelBgColor.BackColor = dlg.Color;
        }

        private void SaveFromControls()
        {
            _s.HueShift = trackHue.Value;
            _s.Saturation = trackSaturation.Value / 100f;
            _s.Brightness = trackBrightness.Value / 100f;
            _s.BackgroundR = panelBgColor.BackColor.R;
            _s.BackgroundG = panelBgColor.BackColor.G;
            _s.BackgroundB = panelBgColor.BackColor.B;

            _s.BallSizeRatio = trackBallSize.Value / 100f;
            _s.MaxRadiusRatio = trackMaxRadius.Value / 100f;
            _s.Bars = trackBars.Value;

            _s.BarSmoothing = trackBarSmooth.Value / 100f;
            _s.BassBoost = trackBassBoost.Value / 10f;
            _s.HighFreqBoost = trackHighBoost.Value / 10f;

            _s.ParticlesEnabled = chkParticles.Checked;
            _s.MaxParticles = trackMaxParticles.Value;
            _s.SpawnThreshold = trackSpawnThreshold.Value / 100f;

            _s.GlowEnabled = chkGlow.Checked;
            _s.GlowIntensity = trackGlowIntensity.Value / 100f;
        }
    }
}