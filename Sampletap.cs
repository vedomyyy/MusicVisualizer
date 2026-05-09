using System;
using NAudio.Wave;

namespace MusicVisualizer
{
    public class SampleTap : ISampleProvider
    {
        private readonly ISampleProvider _source;
        private readonly int _fftSize;
        private readonly Action<double[]> _callback;
        private readonly double[] _ring;
        private int _pos;

        public NAudio.Wave.WaveFormat WaveFormat => _source.WaveFormat;

        public SampleTap(ISampleProvider source, int fftSize, Action<double[]> callback)
        {
            _source = source;
            _fftSize = fftSize;
            _callback = callback;
            _ring = new double[fftSize];
        }

        public int Read(float[] buffer, int offset, int count)
        {
            int read = _source.Read(buffer, offset, count);
            int channels = _source.WaveFormat.Channels;   // через _source напрямую

            for (int i = 0; i < read; i += channels)
            {
                double mono = 0;
                for (int c = 0; c < channels; c++)
                    mono += buffer[offset + i + c];
                _ring[_pos++] = mono / channels;

                if (_pos >= _fftSize)
                {
                    _pos = 0;
                    var snap = (double[])_ring.Clone();
                    System.Threading.ThreadPool.QueueUserWorkItem(_ => _callback(snap));
                }
            }
            return read;
        }
    }
}