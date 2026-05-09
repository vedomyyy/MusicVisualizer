using System;
using System.Windows.Forms;

namespace MusicVisualizer
{
    public partial class Form1 : Form
    {
        private readonly AudioEngine _audio = new();
        private readonly VisualizerPanel _visual = new();
        private readonly System.Windows.Forms.Timer _timer = new() { Interval = 16 };
        private readonly VisualizerSettings _settings = VisualizerSettings.Load(); // НОВОЕ

        private bool _seekingProgress = false;

        public Form1()
        {
            InitializeComponent();

            _visual.Dock = DockStyle.Fill;
            panelCanvas.Controls.Add(_visual);
            _audio.Volume = trackBarVolume.Value / 10f;
            panelCanvas.Controls.Remove(lblFileName);
            panelCanvas.Controls.Remove(lblTime);
            _visual.Controls.Add(lblFileName);
            _visual.Controls.Add(lblTime);

            _visual.ApplySettings(_settings); // НОВОЕ

            _timer.Tick += OnTick;
            _timer.Start();
        }

        private void OnTick(object? s, EventArgs e)
        {
            _visual.UpdateMagnitudes(_audio.Magnitudes, 0.016f);

            if (!_seekingProgress && _audio.TotalTime.HasValue)
            {
                var total = _audio.TotalTime.Value;
                var current = _audio.CurrentTime;
                trackBarProgress.Value = (int)(current.TotalSeconds /
                    total.TotalSeconds * trackBarProgress.MaxValue);
                lblTime.Text = $"{current:mm\\:ss} / {total:mm\\:ss}";
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string path = WinApiDialog.Show(Handle);
            if (string.IsNullOrEmpty(path)) return;
            _audio.Open(path);
            _audio.Volume = trackBarVolume.Value / 10f;
            _audio.Play();
            lblFileName.Text = System.IO.Path.GetFileName(path);
        }

        private void btnPlay_Click(object sender, EventArgs e) => _audio.Play();
        private void btnPause_Click(object sender, EventArgs e) => _audio.Pause();
        private void btnStop_Click(object sender, EventArgs e) => _audio.Stop();

        private void trackBarVolume_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _audio.Volume = trackBarVolume.Value / 10f;
        }

        private void trackBarProgress_MouseDown(object sender, MouseEventArgs e)
            => _seekingProgress = true;

        private void trackBarProgress_MouseUp(object sender, MouseEventArgs e)
        {
            _audio.Seek((double)trackBarProgress.Value / trackBarProgress.MaxValue);
            _seekingProgress = false;
        }

        // НОВОЕ
        private void btnSettings_Click(object sender, EventArgs e)
        {
            using var form = new SettingsForm(_settings, _visual);
            form.ShowDialog(this);
            _visual.ApplySettings(_settings);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _timer.Stop();
            _audio.Dispose();
            base.OnFormClosed(e);
        }
    }
}