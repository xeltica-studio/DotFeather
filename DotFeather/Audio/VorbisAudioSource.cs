using System;
using System.Collections.Generic;
using NVorbis;

namespace DotFeather.Audio
{
    public class VorbisAudioSource : IAudioSource, IDisposable
    {
        public int? Samples => (int)reader.TotalSamples;

        public int Channels => reader.Channels;

        public int Bits => 16;

        public int SampleRate => reader.SampleRate;

        public VorbisAudioSource(string path)
        {
			reader = new NVorbis.VorbisReader(path);
        }

        public IEnumerable<(short left, short right)> EnumerateSamples(int? loopStart)
        {
			var buf = new float[2];
			reader.DecodedPosition = 0;
			short ToShort(float data) => (short)(data * short.MaxValue);
			do
			{
				while (reader.ReadSamples(buf, 0, Channels) > 0)
				{
					yield return (ToShort(buf[0]), ToShort(buf[Channels == 1 ? 0 : 1]));
				}
				if (loopStart is int a)
				{
					reader.DecodedPosition = a;
				}
			} while (loopStart is int);
        }

        public void Dispose()
        {
			reader.Dispose();
        }

        private readonly VorbisReader reader;
    }
}
