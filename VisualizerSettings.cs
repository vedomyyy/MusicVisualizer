using System;
using System.IO;
using System.Text.Json;

namespace MusicVisualizer
{
    public class VisualizerSettings
    {
        // Цвет
        public float HueShift { get; set; } = 0f;
        public float Saturation { get; set; } = 1.0f;
        public float Brightness { get; set; } = 1.0f;
        public int BackgroundR { get; set; } = 8;
        public int BackgroundG { get; set; } = 8;
        public int BackgroundB { get; set; } = 15;

        // Геометрия
        public float BallSizeRatio { get; set; } = 0.38f;
        public float MaxRadiusRatio { get; set; } = 0.48f;
        public int Bars { get; set; } = 128;

        // Физика
        public float BarSmoothing { get; set; } = 0.45f;
        public float BassBoost { get; set; } = 2.5f;
        public float HighFreqBoost { get; set; } = 1.2f;

        // Частицы
        public bool ParticlesEnabled { get; set; } = true;
        public int MaxParticles { get; set; } = 220;
        public float SpawnThreshold { get; set; } = 0.24f;

        // Свечение
        public bool GlowEnabled { get; set; } = true;
        public float GlowIntensity { get; set; } = 1.0f;

        public int Sectors { get; set; } = 180;
        public int GlowRings { get; set; } = 8;

        private static readonly string _path = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MusicVisualizer", "settings.json");

        public static VisualizerSettings Load()
        {
            try
            {
                if (File.Exists(_path))
                    return JsonSerializer.Deserialize<VisualizerSettings>(File.ReadAllText(_path))
                           ?? new VisualizerSettings();
            }
            catch { }
            return new VisualizerSettings();
        }

        public void Save()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_path)!);
                File.WriteAllText(_path, JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch { }
        }
    }
}