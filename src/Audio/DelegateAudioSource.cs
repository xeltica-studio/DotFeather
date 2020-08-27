using System.Collections.Generic;

namespace DotFeather
{
	/// <summary>
	/// An audio source to generate waveform with delegate.
	/// </summary>
	public class DelegateAudioSource : IAudioSource
	{
		/// <summary>
		/// Get the total number of samples.
		/// </summary>
		/// <returns></returns>
		public int? Samples => null;

		/// <summary>
		/// Get channels.
		/// </summary>
		public int Channels => 2;

		/// <summary>
		/// Get sample bits.
		/// </summary>
		public int Bits => 16;

		/// <summary>
		/// Get sample rate.
		/// </summary>
		public int SampleRate => 44100;

		/// <summary>
		/// Initialize a new instance of <see cref="DelegateAudioSource"/> class with specified file path.
		/// </summary>
		public DelegateAudioSource(AudioGeneratorDelegate d)
		{
			audioGenerator = d;
		}

		public IEnumerable<(short left, short right)> EnumerateSamples(int? loopStart)
		{
			while (true)
			{
				var generated = audioGenerator(sampleCount++, loopStart);
				if (generated == null) break;
				yield return generated.Value;
			}
		}

		private int sampleCount = 0;

		private readonly AudioGeneratorDelegate audioGenerator;
	}

	public delegate (short left, short right)? AudioGeneratorDelegate(int sampleCount, int? loopStart);
}
