using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MusicVisualizer
{
    public class VisualizerPanel : Panel
    {
        private float[] _mag = Array.Empty<float>();
        private float _time = 0f;
        private float _bass = 0f;
        private float _energy = 0f;
        private float _prevBass = 0f;

        // Particles
        private readonly List<Particle> _particles = new();
        private const int MAX_PARTICLES = 220;
        private const float SPAWN_THRESHOLD = 0.24f; // минимальный бас для спауна

        private const int BARS = 128;
        private const int SECTORS = 180;

        private float[] _barSmooth = new float[128]; // размер пересоздаётся в ApplySettings

        // Переиспользуемые GDI-объекты
        private readonly SolidBrush _sectorBrush = new SolidBrush(Color.White);
        private readonly SolidBrush _particleBrush = new SolidBrush(Color.White);
        private readonly Pen _glowPen = new Pen(Color.White, 1f);
        private readonly Pen _barGlowPen = new Pen(Color.White, 1f) { StartCap = LineCap.Round, EndCap = LineCap.Round };
        private readonly Pen _barPen = new Pen(Color.White, 1f) { StartCap = LineCap.Round, EndCap = LineCap.Round };

        private readonly Random _rng = new Random();

        // ── НАСТРОЙКИ ────────────────────────────────────────────────────────
        private VisualizerSettings _cfg = new VisualizerSettings();

        public void ApplySettings(VisualizerSettings s)
        {
            _cfg = s;
            _barSmooth = new float[s.Bars]; // убери проверку if, всегда пересоздавай
            BackColor = Color.FromArgb(s.BackgroundR, s.BackgroundG, s.BackgroundB);
        }

        public VisualizerPanel()
        {
            BackColor = Color.FromArgb(8, 8, 15);
            DoubleBuffered = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        // ── Структура частицы ─────────────────────────────────────────────────

        private struct Particle
        {
            public float X, Y;
            public float VX, VY;
            public float Life;     // 1 → 0
            public float MaxLife;
            public float Size;
            public float Hue;
        }

        // ── Публичный метод обновления ────────────────────────────────────────

        public void UpdateMagnitudes(float[] mag, float dt)
        {
            if (mag != null && mag.Length > 0)
            {
                float[] cleanMag = new float[mag.Length];
                Array.Copy(mag, cleanMag, mag.Length);

                // ОБНУЛЯЕМ DC: самый первый бин = частота 0 Гц
                cleanMag[0] = 0f;

                // Иногда DC протекает и во второй бин (особенно на плохих звуковухах)
                if (cleanMag.Length > 1)
                    cleanMag[1] = 0f;

                _mag = cleanMag;
            }
            else
            {
                _mag = Array.Empty<float>();
            }

            _time += dt;

            float rawBass = Average(_mag, 0, Math.Max(1, (int)(_mag.Length * 0.10f)));
            float rawEnergy = Average(_mag, 0, _mag.Length);

            if (rawBass > 0.001f)
                rawBass = Math.Clamp(_cfg.BassBoost > 0 ? rawBass * _cfg.BassBoost : rawBass * 2.5f, 0f, 1.5f);

            if (rawEnergy > 0.001f)
                rawEnergy = Math.Clamp(rawEnergy * 2.2f, 0f, 1.5f);

            _bass = Lerp(_bass, rawBass, 0.35f);
            _energy = Lerp(_energy, rawEnergy, 0.25f);

            // Логарифмический маппинг бинов
            // ── Логарифмический маппинг бинов (УСИЛЕННЫЙ ДЛЯ ВЫСОКИХ ЧАСТОТ) ──
            if (_mag.Length > 0)
            {
                // Раньше было 0.60f, теперь захватываем 85% спектра
                // Это критически важно для видимости высоких частот (тарелки, сибилянты, хай-хэты).
                int usableBins = (int)(_mag.Length * 0.90f);

                int bars = _cfg.Bars;
                if (_barSmooth.Length != bars)
                    _barSmooth = new float[bars];
                for (int i = 0; i < bars; i++)
                {
                    float t = (float)i / bars;

                    // Раньше было Pow(t, 0.5f). 
                    // 0.7f — это "золотая середина": низы по-прежнему широкие, но верха не сжаты в 2 пикселя.
                    float logT = MathF.Pow(t, 0.7f);

                    int binFrom = (int)(logT * usableBins);
                    float tNext = (float)(i + 1) / bars;
                    float logTNext = MathF.Pow(tNext, 0.7f);
                    int binTo = (int)(logTNext * usableBins);
                    binTo = Math.Max(binFrom + 1, Math.Min(binTo, _mag.Length));

                    float val = Average(_mag, binFrom, binTo);

                    // Усиливаем высокие частоты (последние 60% баров), чтобы они "зажигали" не хуже баса.
                    // Если нормализованный индекс полосы > 0.4f, умножаем громкость.
                    if (i > bars * 0.4f)
                    {
                        // Коэффициент нарастает плавно от 1.0 до 1.7 (можно увеличить до 2.0f)
                        float highFreqBoost = 1.0f + _cfg.HighFreqBoost * ((float)i / bars);
                        val *= highFreqBoost;
                    }

                    // Оставляем небольшой пол (минимальная высота), чтобы тихие верха не пропадали совсем.
                    // Это создаст эффект "шума" на радаре даже на тихой музыке.
                    val = Math.Max(val, 0.01f);

                    _barSmooth[i] = Lerp(_barSmooth[i], Math.Clamp(val, 0f, 1f), _cfg.BarSmoothing > 0 ? _cfg.BarSmoothing : 0.45f);
                }
            }

            // Спаун частиц при сильном басе
            if (_cfg.ParticlesEnabled && _bass > _cfg.SpawnThreshold && _particles.Count < _cfg.MaxParticles)
            {
                float cx = Width / 2f;
                float cy = Height / 2f;
                float maxR = Math.Min(Width, Height) * _cfg.MaxRadiusRatio;
                float minR = maxR * _cfg.BallSizeRatio;
                float ballR = minR * (0.72f + _bass * 0.32f + _energy * 0.15f);

                int spawnCount = (int)((_bass - _cfg.SpawnThreshold) / (1f - _cfg.SpawnThreshold) * 8) + 1;
                spawnCount = Math.Min(spawnCount, _cfg.MaxParticles - _particles.Count);

                for (int s = 0; s < spawnCount; s++)
                {
                    float angle = (float)_rng.NextDouble() * MathF.PI * 2f;
                    float speed = (float)(_rng.NextDouble() * 1.8 + 0.8) * (1f + _bass * 2.5f);
                    float scatter = (float)(_rng.NextDouble() - 0.5) * 0.6f;

                    _particles.Add(new Particle
                    {
                        X = cx + MathF.Cos(angle) * ballR,
                        Y = cy + MathF.Sin(angle) * ballR,
                        VX = MathF.Cos(angle + scatter) * speed,
                        VY = MathF.Sin(angle + scatter) * speed,
                        Life = 1f,
                        MaxLife = (float)(_rng.NextDouble() * 0.6 + 0.5),
                        Size = (float)(_rng.NextDouble() * 3.5 + 1.2),
                        Hue = (float)(_rng.NextDouble() * 360f)
                    });
                }
            }

            // Обновляем частицы
            for (int i = _particles.Count - 1; i >= 0; i--)
            {
                var p = _particles[i];
                p.X += p.VX * dt * 60f;
                p.Y += p.VY * dt * 60f;
                p.VX *= 0.97f;
                p.VY *= 0.97f;
                p.Life -= dt / p.MaxLife;

                if (p.Life <= 0f)
                    _particles.RemoveAt(i);
                else
                    _particles[i] = p;
            }

            Invalidate();
        }

        // ── Отрисовка ─────────────────────────────────────────────────────────

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            int W = Width, H = Height;
            float cx = W / 2f, cy = H / 2f;

            g.Clear(Color.FromArgb(_cfg.BackgroundR, _cfg.BackgroundG, _cfg.BackgroundB));

            if (_mag.Length == 0) return;

            // Увеличенный круг: 0.48 вместо 0.42
            float maxR = Math.Min(W, H) * _cfg.MaxRadiusRatio;
            float minR = maxR * _cfg.BallSizeRatio;
            float ballR = minR * (0.72f + _bass * 0.32f + _energy * 0.15f);

            DrawBackground(g, cx, cy, maxR);
            DrawParticles(g);
            DrawFilledBall(g, cx, cy, ballR);
            DrawBallEdgeGlow(g, cx, cy, ballR);
            DrawBars(g, cx, cy, ballR, maxR);
        }

        // ── Фоновый ореол ─────────────────────────────────────────────────────

        private void DrawBackground(Graphics g, float cx, float cy, float maxR)
        {
            float bgR = maxR * 1.6f;
            float h = (_time * 12f + _cfg.HueShift) % 360f;
            int a = Math.Clamp((int)((0.07f + _bass * 0.09f) * 255 * _cfg.GlowIntensity), 0, 255);

            using var path = MakeCirclePath(cx, cy, bgR);
            using var brush = new PathGradientBrush(path)
            {
                CenterColor = ColorFromHsl(h, 0.35f * _cfg.Saturation, 0.18f * _cfg.Brightness, a),
                SurroundColors = new[] { Color.Transparent }
            };
            g.FillEllipse(brush, cx - bgR, cy - bgR, bgR * 2, bgR * 2);
        }


        // ── Частицы ───────────────────────────────────────────────────────────

        private void DrawParticles(Graphics g)
        {
            foreach (var p in _particles)
            {
                float ease = p.Life * p.Life;  // квадратичное затухание
                int a = Math.Clamp((int)(ease * 220), 0, 255);
                float sz = p.Size * (0.4f + p.Life * 0.6f);

                _particleBrush.Color = ColorFromHsl((p.Hue + _cfg.HueShift) % 360f, 0.65f * _cfg.Saturation, 0.85f * _cfg.Brightness, a);
                g.FillEllipse(_particleBrush, p.X - sz / 2f, p.Y - sz / 2f, sz, sz);
            }
        }

        // ── Заполненный шар с равномерными секторами ──────────────────────────

        private void DrawFilledBall(Graphics g, float cx, float cy, float ballR)
        {
            int sectors = _cfg.Sectors > 0 ? _cfg.Sectors : 180;
            float step = MathF.PI * 2f / sectors;
            float gap = step * 0.06f;

            for (int i = 0; i < sectors; i++)
            {
                float a1 = i * step - MathF.PI / 2f + gap;
                float a2 = (i + 1) * step - MathF.PI / 2f - gap;
                float norm = i / (float)sectors;

                _sectorBrush.Color = PastelAngleColor(norm, _time, 205);
                var pts = SectorPoints(cx, cy, ballR, a1, a2, 4);
                g.FillPolygon(_sectorBrush, pts);
            }

            float hiR = ballR * 0.72f;
            int hiA = Math.Clamp((int)((0.28f + _bass * 0.14f) * 255), 0, 255);
            using var hiPath = MakeCirclePath(cx, cy, hiR);
            using var hiBrush = new PathGradientBrush(hiPath)
            {
                CenterColor = Color.FromArgb(hiA, 255, 255, 255),
                SurroundColors = new[] { Color.Transparent }
            };
            g.FillEllipse(hiBrush, cx - hiR, cy - hiR, hiR * 2, hiR * 2);
        }

        // ── Свечение по краю шара ─────────────────────────────────────────────

        private void DrawBallEdgeGlow(Graphics g, float cx, float cy, float ballR)
        {
            if (!_cfg.GlowEnabled) return;
            int glowRings = _cfg.GlowRings > 0 ? _cfg.GlowRings : 8;
            for (int ring = 1; ring <= glowRings; ring++)
            {
                float rr = ballR + ring * (ballR * 0.055f);
                float ra = (0.12f - ring * 0.013f) * (0.55f + _bass * 0.5f) * _cfg.GlowIntensity;
                if (ra <= 0) continue;

                float rH = ((_time * 20f + ring * 35f + _cfg.HueShift) % 360f + 360f) % 360f;
                int a = Math.Clamp((int)(ra * 255), 0, 255);

                _glowPen.Color = ColorFromHsl(rH, 0.55f * _cfg.Saturation, 0.80f * _cfg.Brightness, a);
                _glowPen.Width = ballR * 0.07f * (1f - ring / (float)(glowRings + 1));
                g.DrawEllipse(_glowPen, cx - rr, cy - rr, rr * 2, rr * 2);
            }
        }

        // ── Радиальные лучи ───────────────────────────────────────────────────

        private void DrawBars(Graphics g, float cx, float cy, float ballR, float maxR)
        {
            int bars = Math.Min(_cfg.Bars, _barSmooth.Length);
            for (int i = 0; i < bars; i++)
            {
                float val = _barSmooth[i];
                float norm = i / (float)bars;
                float angle = norm * MathF.PI * 2f - MathF.PI / 2f;
                float innerR = ballR + _bass * 4f;
                float span = maxR - innerR;
                float outerR = innerR + val * span * 0.92f + span * 0.02f;

                float cosA = MathF.Cos(angle), sinA = MathF.Sin(angle);
                float x1 = cx + cosA * innerR, y1 = cy + sinA * innerR;
                float x2 = cx + cosA * outerR, y2 = cy + sinA * outerR;

                var col = PastelFreqColor(norm, 185);

                _barGlowPen.Color = Color.FromArgb(Math.Clamp((int)(val * 50 + 12), 0, 255), col);
                _barGlowPen.Width = 5f + val * 7f;
                g.DrawLine(_barGlowPen, x1, y1, x2, y2);

                _barPen.Color = col;
                _barPen.Width = 1.4f + val * 1.8f;
                g.DrawLine(_barPen, x1, y1, x2, y2);
            }
        }

        // ── Палитры ───────────────────────────────────────────────────────────

        private Color PastelFreqColor(float norm, int alpha)
        {
            float[] hs = { 280f, 320f, 355f, 30f, 170f, 255f, 280f };
            float[] ss = { .70f, .65f, .70f, .65f, .55f, .58f, .70f };
            float[] ls = { .80f, .82f, .83f, .85f, .78f, .82f, .80f };
            return InterpolateHslStops(hs, ss, ls, norm, _cfg.HueShift, alpha);
        }

        private Color PastelAngleColor(float norm, float time, int alpha)
        {
            float[] hs = { 280f, 320f, 355f, 30f, 170f, 255f, 280f, 280f };
            float[] ss = { .60f, .58f, .62f, .58f, .50f, .55f, .60f, .60f };
            float[] ls = { .82f, .84f, .85f, .86f, .80f, .83f, .82f, .82f };
            return InterpolateHslStops(hs, ss, ls, norm, time * 20f + _cfg.HueShift, alpha);
        }

        private Color InterpolateHslStops(float[] hs, float[] ss, float[] ls,
                                                  float norm, float hShift, int alpha)
        {
            float t = norm * (hs.Length - 1);
            int i = Math.Min((int)t, hs.Length - 2);
            float f = t - i;
            float h = (hs[i] + (hs[i + 1] - hs[i]) * f + hShift) % 360f;
            float s = Math.Clamp((ss[i] + (ss[i + 1] - ss[i]) * f) * _cfg.Saturation, 0f, 1f);
            float l = Math.Clamp((ls[i] + (ls[i + 1] - ls[i]) * f) * _cfg.Brightness, 0f, 1f);
            return ColorFromHsl(h, s, l, alpha);
        }

        // ── Геометрия ─────────────────────────────────────────────────────────

        private static PointF[] SectorPoints(float cx, float cy, float r,
                                              float a1, float a2, int segs)
        {
            var pts = new PointF[segs + 2];
            pts[0] = new PointF(cx, cy);
            for (int i = 0; i <= segs; i++)
            {
                float a = a1 + (a2 - a1) * i / segs;
                pts[i + 1] = new PointF(cx + MathF.Cos(a) * r, cy + MathF.Sin(a) * r);
            }
            return pts;
        }

        private static GraphicsPath MakeCirclePath(float cx, float cy, float r)
        {
            var p = new GraphicsPath();
            p.AddEllipse(cx - r, cy - r, r * 2, r * 2);
            return p;
        }

        // ── Утилиты ───────────────────────────────────────────────────────────

        private static float Average(float[] arr, int from, int to)
        {
            if (arr == null || arr.Length == 0) return 0f;
            int end = Math.Min(to, arr.Length);
            int n = end - from;
            if (n <= 0) return 0f;
            float sum = 0f;
            for (int i = from; i < end; i++) sum += arr[i];
            return sum / n;
        }

        private static float Lerp(float a, float b, float t) =>
            a + (b - a) * Math.Clamp(t, 0f, 1f);

        private static Color ColorFromHsl(float h, float s, float l, int alpha)
        {
            h = ((h % 360f) + 360f) % 360f;
            float c = (1f - MathF.Abs(2f * l - 1f)) * s;
            float x = c * (1f - MathF.Abs((h / 60f) % 2f - 1f));
            float m = l - c / 2f;
            float r, g, b;
            if (h < 60) { r = c; g = x; b = 0; }
            else if (h < 120) { r = x; g = c; b = 0; }
            else if (h < 180) { r = 0; g = c; b = x; }
            else if (h < 240) { r = 0; g = x; b = c; }
            else if (h < 300) { r = x; g = 0; b = c; }
            else { r = c; g = 0; b = x; }
            return Color.FromArgb(
                Math.Clamp(alpha, 0, 255),
                Math.Clamp((int)((r + m) * 255), 0, 255),
                Math.Clamp((int)((g + m) * 255), 0, 255),
                Math.Clamp((int)((b + m) * 255), 0, 255));
        }

        // ── Освобождение ресурсов ─────────────────────────────────────────────

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _sectorBrush.Dispose();
                _particleBrush.Dispose();
                _glowPen.Dispose();
                _barGlowPen.Dispose();
                _barPen.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}