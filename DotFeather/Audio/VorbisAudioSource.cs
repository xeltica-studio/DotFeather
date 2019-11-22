using System;
using System.Collections.Generic;
using NVorbis;

namespace DotFeather
{
	/// <summary>
	/// An audio source that represents data in Ogg Vorbis format.
	/// </summary>
	public class VorbisAudioSource : IAudioSource, IDisposable
	{
		/// <summary>
		/// Get the total number of samples.
		/// </summary>
		/// <returns></returns>
		public int? Samples => (int)reader.TotalSamples;

		/// <summary>
		/// Get channels.
		/// </summary>
		public int Channels => reader.Channels;

		/// <summary>
		/// Get sample bits.
		/// </summary>
		public int Bits => 16;

		/// <summary>
		/// Get sample rate.
		/// </summary>
		public int SampleRate => reader.SampleRate;

		/// <summary>
		/// Initialize a new instance of <see cref="VorbisAudioSource"/> class with specified file path.
		/// </summary>
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

		/// <summary>
		/// Dispose this object.
		/// </summary>
		public void Dispose()
		{
			reader.Dispose();
		}

		private readonly VorbisReader reader;
	}
}
