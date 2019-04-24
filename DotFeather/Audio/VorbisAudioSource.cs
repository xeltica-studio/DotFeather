using System;
using System.Collections.Generic;
using NVorbis;

namespace DotFeather
{
	/// <summary>
	/// Ogg Vorbis 形式のデータを表現するオーディオソースです。
	/// </summary>
	public class VorbisAudioSource : IAudioSource, IDisposable
	{
		/// <summary>
		/// 合計サンプル数を取得または設定します。
		/// </summary>
		/// <returns></returns>
		public int? Samples => (int)reader.TotalSamples;

		/// <summary>
		/// チャンネル数を取得または設定します。
		/// </summary>
		public int Channels => reader.Channels;

		/// <summary>
		///  量子化ビット数を取得または設定します。
		/// </summary>
		public int Bits => 16;

		/// <summary>
		/// サンプリング周波数を取得または設定します。
		/// </summary>
		public int SampleRate => reader.SampleRate;

		/// <summary>
		/// ファイル名を指定して、 <see cref="VorbisAudioSource"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="path">ファイルパス。</param>
		public VorbisAudioSource(string path)
		{
			reader = new NVorbis.VorbisReader(path);
		}

		/// <summary>
		/// サンプルを列挙します。
		/// </summary>
		/// <param name="loopStart">ループ開始位置。ループしない場合は <c>null</c> 。</param>
		/// <returns>サンプルのイテレーター。</returns>
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
		/// このオブジェクトを破棄します、
		/// </summary>
		public void Dispose()
		{
			reader.Dispose();
		}

		private readonly VorbisReader reader;
	}
}
