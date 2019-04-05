using System;
using System.Collections.Generic;
using System.IO;

namespace DotFeather.Audio
{
    public class WaveAudioSource : IAudioSource
    {
        public int? Samples => store.Length / channels;
        public int Channels => channels;
        public int Bits => bits;
        public int SampleRate => sampleRate;

		public WaveAudioSource(string path)
		{
			store = LoadWave(File.OpenRead(path), out channels, out bits, out sampleRate);
		}

		public IEnumerator<(short left, short right)> EnumerateSamples(int? loopStart)
		{
            int currentSample = 0;
			while (true)
			{
                var Sample = sampleRate == 16 ? (PullDelegate)Pull16 : Pull;
                switch (channels)
                {
                    case 1:
                        var sample = Sample(ref currentSample);
                        yield return (sample, sample);
                        break;
                    case 2:
                        yield return (Sample(ref currentSample), Sample(ref currentSample));
                        break;
                }
                if (currentSample >= store.Length)
                {
                    // ループ処理
                    if (loopStart is int loop)
                    {
                        currentSample = loop * channels;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        protected short Pull(ref int currentSample) => store[currentSample++];
        protected short Pull16(ref int currentSample) => (short)(store[currentSample++] << 8 + store[currentSample++]);

        protected int? loopStart;
        protected readonly byte[] store;
        protected readonly int channels;
        protected readonly int bits;
        protected readonly int sampleRate;

        protected static byte[] LoadWave(Stream stream, out int channels, out int bits, out int rate)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            using (BinaryReader reader = new BinaryReader(stream))
            {
                // RIFF header
                string riff = new string(reader.ReadChars(4));
                if (riff != "RIFF")
                    throw new NotSupportedException("Specified stream is not a wave file.");

                int riffChunkSize = reader.ReadInt32();

                string format = new string(reader.ReadChars(4));
                if (format != "WAVE")
                    throw new NotSupportedException("Specified stream is not a wave file.");

                // WAVE header
                string fmt = new string(reader.ReadChars(4));
                if (fmt != "fmt ")
                    throw new NotSupportedException("Specified wave file is not supported.");

                reader.ReadInt32();
                reader.ReadInt16();
                int fileChannels = reader.ReadInt16();
                int sampleRate = reader.ReadInt32();
                reader.ReadInt32();
                reader.ReadInt16();
                int bitsPerSample = reader.ReadInt16();

                if (bitsPerSample != 8 && bitsPerSample != 16)
                    throw new NotSupportedException("DotFeather only supports 8bit or 16bit per sample.");

                if (fileChannels < 1 || 2 < fileChannels)
                    throw new NotSupportedException("DotFeather only supports 1ch or 2ch audio.");

                string data = new string(reader.ReadChars(4));
                if (data != "data")
                    throw new NotSupportedException("Specified wave file is not supported.");

                _ = reader.ReadInt32();

                channels = fileChannels;
                bits = bitsPerSample;
                rate = sampleRate;

                return reader.ReadBytes((int)reader.BaseStream.Length);
            }
        }

        protected delegate short PullDelegate(ref int currentSample);
    }
}
