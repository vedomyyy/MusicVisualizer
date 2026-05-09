using System;
using NAudio.Wave;

namespace MusicVisualizer
{
    /// Воспроизведение аудио + захват FFT-магнитуд в реальном времени.

    public class AudioEngine : IDisposable
    {
        private AudioFileReader? _reader;
        private WaveOutEvent? _output;
        private SampleTap? _tap;

        private const int FFT_SIZE = 1024;

        // Скользящий максимум для авто-нормализации
        private float _peakSmooth = 1f;

        private volatile float[] _magnitudes = new float[FFT_SIZE / 2];
        public float[] Magnitudes => _magnitudes;

        public TimeSpan? TotalTime => _reader?.TotalTime;
        public TimeSpan CurrentTime => _reader?.CurrentTime ?? TimeSpan.Zero;
        public double Progress => _reader == null ? 0 : (double)_reader.Position / _reader.Length;

        public float Volume
        {
            get => _reader?.Volume ?? 1f;
            set { if (_reader != null) _reader.Volume = Math.Clamp(value, 0f, 1f); }
        }

        // ── Открыть файл ─────────────────────────────────────────────────────

        public void Open(string path)
        {
            Stop();
            DisposeInternals();

            _reader = new AudioFileReader(path);
            _tap = new SampleTap(_reader, FFT_SIZE, ProcessFFT);
            _output = new WaveOutEvent();
            _output.Init(_tap);
        }

        public void Play() => _output?.Play();
        public void Pause() => _output?.Pause();

        public void Stop()
        {
            _output?.Stop();
            _reader?.Seek(0, System.IO.SeekOrigin.Begin);
        }

        public void Seek(double fraction)
        {
            if (_reader == null) return;
            _reader.Position = (long)(_reader.Length * Math.Clamp(fraction, 0, 1));
        }

        // ── FFT ──────────────────────────────────────────────────────────────

        private void ProcessFFT(double[] samples)
        {
            var buf = (double[])samples.Clone();

            // Окно Хэннинга — убирает спектральную утечку
            var window = new FftSharp.Windows.Hanning();
            window.ApplyInPlace(buf);

            // FFT
            System.Numerics.Complex[] spectrum = FftSharp.FFT.Forward(buf);
            double[] mag = FftSharp.FFT.Magnitude(spectrum);

            int n = mag.Length; // FFT_SIZE / 2
            var res = new float[n];

            // Частота каждого бина: binHz = i * sampleRate / FFT_SIZE
            int sampleRate = _reader?.WaveFormat.SampleRate ?? 44100;

            // 1. Перцептивное взвешивание: компенсируем спад высоких частот.
            //    Простая A-weighting аппроксимация: усиливаем средние/высокие,
            //    немного режем самый низ (DC и суббас дают ложные выбросы).
            for (int i = 0; i < n; i++)
            {
                double hz = (double)i * sampleRate / FFT_SIZE;

                // Убираем DC и суббас < 30 Гц — они дают ложный «12 часов» всплеск
                if (hz < 30.0)
                {
                    res[i] = 0f;
                    continue;
                }

                // Мягкое перцептивное выравнивание:
                // +6 дБ на октаву начиная с ~200 Гц (компенсирует спад воздуха)
                double weight = 1.0 + Math.Log10(Math.Max(hz, 200.0) / 200.0) * 1.8;

                res[i] = (float)(mag[i] * weight);
            }

            // 2. Авто-нормализация через скользящий пик.
            //    Пик быстро растёт, медленно падает — не «дёргается» при тишине.
            float peak = 0f;
            for (int i = 0; i < n; i++)
                if (res[i] > peak) peak = res[i];

            // Быстрый подъём, медленный спуск
            if (peak > _peakSmooth)
                _peakSmooth = peak;
            else
                _peakSmooth = _peakSmooth * 0.995f + peak * 0.005f;

            float scale = 1f / Math.Max(_peakSmooth, 0.001f);

            // 3. Финальное приведение к 0..1 + мягкое сжатие через sqrt
            //    sqrt делает тихие части заметнее, громкие — не зашкаливают.
            for (int i = 0; i < n; i++)
                res[i] = Math.Clamp(MathF.Sqrt(res[i] * scale), 0f, 1f);

            _magnitudes = res;
        }

        // ── Очистка ──────────────────────────────────────────────────────────

        private void DisposeInternals()
        {
            _output?.Dispose(); _output = null;
            _tap = null;
            _reader?.Dispose(); _reader = null;
        }

        public void Dispose() => DisposeInternals();
    }
}