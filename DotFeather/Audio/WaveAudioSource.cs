using System;
using System.Collections.Generic;
using System.IO;

namespace DotFeather
{
	/// <summary>
	/// Wave ファイルフォーマットを表現するオーディオソースです。
	/// </summary>
	public class WaveAudioSource : IAudioSource
	{
		/// <summary>
		/// 合計サンプル数を取得または設定します。
		/// </summary>
		public int? Samples => store.Length;

		/// <summary>
		/// チャンネル数を取得または設定します。
		/// </summary>
		public int Channels => channels;

		/// <summary>
		/// 量子化ビット数を取得または設定します。
		/// </summary>
		public int Bits => bits;

		/// <summary>
		/// サンプリング周波数を取得または設定します。
		/// </summary>
		public int SampleRate => sampleRate;

		/// <summary>
		/// パスを指定して、 <see cref="WaveAudioSource"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="path">ファイルパス。</param>
		public WaveAudioSource(string path)
		{
			store = LoadWave(File.OpenRead(path), out channels, out bits, out sampleRate);
		}

		/// <summary>
		/// サンプルを列挙します。
		/// </summary>
		/// <param name="loopStart">ループ開始位置。ループしない場合は <c>null</c> 。</param>
		/// <returns>サンプルのイテレーター。</returns>
		public IEnumerable<(short left, short right)> EnumerateSamples(int? loopStart)
		{
			int currentSample = 0;
			while (true)
			{
				var Sample = bits == 16 ? (PullDelegate)Pull16 : Pull;
				switch (channels)
				{
					case 1:
						var sample = Sample(ref currentSample);
						yield return (sample, sample);
						break;
					case 2:
						var right = Sample(ref currentSample);
						yield return (Sample(ref currentSample), right);
						break;
				}
				if (currentSample >= store.Length)
				{
					// ループ処理
					if (loopStart is int loop)
					{
						currentSample = loop * channels * bits / 8;
					}
					else
					{
						break;
					}
				}
			}
		}

		private short Pull(ref int currentSample) => (short)(store[currentSample++] * 128);
		private short Pull16(ref int currentSample) => (short)(store[currentSample++] | (store[currentSample++] << 8));

		private static byte[] LoadWave(Stream stream, out int channels, out int bits, out int rate)
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
				string fmt = "";
				var size = 0;
				while (true)
				{
					fmt = new string(reader.ReadChars(4));
					size = reader.ReadInt32();
					if (fmt == "fmt ")
						break;
					reader.ReadBytes(size);
				}

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

				string data = null;
				while (true)
				{
					data = new string(reader.ReadChars(4));
					size = reader.ReadInt32();
					if (data == "data")
						break;
					reader.ReadBytes(size);
				}

				channels = fileChannels;
				bits = bitsPerSample;
				rate = sampleRate;

				return reader.ReadBytes(size);
			}
		}

		private int? loopStart;
		private readonly byte[] store;
		private readonly int channels;
		private readonly int bits;
		private readonly int sampleRate;

		private delegate short PullDelegate(ref int currentSample);
	}
}
