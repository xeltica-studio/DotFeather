using System.Collections.Generic;
using OpenTK.Audio.OpenAL;

namespace DotFeather
{
	/// <summary>
	/// DotFeather API で取り扱える音源の仕様を定義します。
	/// </summary>
	public interface IAudioSource
	{
		/// <summary>
		/// サンプルを列挙します。
		/// </summary>
		IEnumerable<(short left, short right)> EnumerateSamples(int? loopStart);
		/// <summary>
		/// この <see cref="IAudioSource"/> のサンプル数を取得します。特定不可能な場合 <c>null</c> を返します。
		/// </summary>
		int? Samples { get; }
		/// <summary>
		/// チャンネル数を取得します。
		/// </summary>
		int Channels { get; }
		/// <summary>
		/// 量子化ビット数を取得します。
		/// </summary>
		int Bits { get; }
		/// <summary>
		/// サンプリング周波数を取得します。
		/// </summary>
		int SampleRate { get; }
	}
}
