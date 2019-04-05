using System.Collections.Generic;
using OpenTK.Audio.OpenAL;

namespace DotFeather.Audio
{
	/// <summary>
	/// DotFeather API で取り扱える音源の仕様を定義します。
	/// </summary>
	public interface IAudioSource
	{
		/// <summary>
		/// サンプルを列挙します。
		/// </summary>
		/// <returns></returns>
		IEnumerator<(short left, short right)> EnumerateSamples();
		/// <summary>
		/// 再生を開始します。
		/// </summary>
		/// <param name="loopSample">ループを開始するサンプル位置。<c>null</c>ならばループしない。</param>
		void Play(int? loopSample = null);
		/// <summary>
		/// 再生を一時停止します。
		/// </summary>
		void Pause();
		/// <summary>
		/// 再生を停止します。
		/// </summary>
		void Stop();
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