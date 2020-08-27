using System.Collections.Generic;

namespace DotFeather
{
	/// <summary>
	/// Defines the specifications of sound sources that can be handled by the DotFeather API.
	/// </summary>
	public interface IAudioSource
	{
		/// <summary>
		/// Enumerate samples.
		/// </summary>
		IEnumerable<(short left, short right)> EnumerateSamples(int? loopStart);
		/// <summary>
		/// Get samples of this <see cref="IAudioSource"/>. Return <c>null</c> if unspecified.
		/// </summary>
		int? Samples { get; }
		/// <summary>
		/// Get the number of channels.
		/// </summary>
		int Channels { get; }
		/// <summary>
		/// Get the number of quantization bits.
		/// </summary>
		int Bits { get; }
		/// <summary>
		/// Get the sampling frequency.
		/// </summary>
		int SampleRate { get; }
	}
}
