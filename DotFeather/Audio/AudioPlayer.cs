using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;

namespace DotFeather
{
	/// <summary>
	/// オーディオソースの再生機能を提供します。
	/// </summary>
	public class AudioPlayer : IDisposable
	{
		/// <summary>
		/// <see cref="AudioPlayer"/> の新しいインスタンスを初期化します。
		/// </summary>
		public AudioPlayer()
		{
			context = new AudioContext();
			Gain = 1;
		}

		/// <summary>
		/// 音量を取得または設定します。
		/// </summary>
		/// <value>0.0〜1.0の範囲での音量。</value>
		public float Gain
		{
			get => gain;
			set
			{
				// 0...1の範囲に矯正
				gain = Math.Max(0, Math.Min(1, value));
				AL.Listener(ALListenerf.Gain, gain);
			}
		}

		/// <summary>
		/// ピッチを取得または設定します。
		/// </summary>
		/// <value>デフォルトを 1 とした、ピッチの倍率。</value>
		public float Pitch { get; set; } = 1;

		/// <summary>
		/// 再生中かどうかを示す値を取得または設定します。
		/// </summary>
		/// <value>再生中である場合は <c>true</c>。それ以外の場合は <c>false</c>。</value>
		public bool IsPlaying { get; private set; }

		/// <summary>
		/// 再生を開始します。
		/// </summary>
		/// <param name="source">再生する <see cref="IAudioSource"/> 。</param>
		/// <param name="loop">ループを開始するサンプル位置。ループしない場合は <c>null</c> 。</param>
		public void Play(IAudioSource source, int? loop = default)
		{
			if (cts != default)
			{
				cts.Cancel();
			}
			cts = new CancellationTokenSource();
			#pragma warning disable CS4014
			PlayAsync(source, loop, cts.Token);
		}

		/// <summary>
		/// 再生を停止します。
		/// </summary>
		/// <param name="time">秒単位のフェードアウト時間。 0 を指定するとすぐに停止します。</param>
		public void Stop(float time = 0)
		{
			if (cts == default)
				return;
			if (time == 0)
			{
				cts.Cancel();
			}
			else
			{
				Task.Run(async () =>
				{
					var firstGain = Gain;
					Stopwatch w = new Stopwatch();
					w.Start();
					while (Gain > 0)
					{
						var current = (w.ElapsedMilliseconds / 1000f) / time;
						Gain = DFMath.Lerp(current, firstGain, 0);
						await Task.Delay(1);
					}
					cts.Cancel();
					w.Stop();
					while (IsPlaying)
						await Task.Delay(10);
					Gain = 1;
				});
			}
		}

		/// <summary>
		/// 指定した <see cref="IAudioSource"/> をインスタントに再生します。
		/// </summary>
		/// <param name="source">再生する  <see cref="IAudioSource"/> 。</param>
		/// <returns></returns>
		public async Task PlayOneShotAsync(IAudioSource source)
		{
			var buf = source.EnumerateSamples(null).GetEnumerator();
			if (!(source.Samples is int samples))
				throw new ArgumentException("PlayOneShot requires AudioSource which has determined length.");
			var buffer = new short[samples];
			FillBuffer(buffer, buf, default);
			using(var alSrc = new ALSource())
			using(var alBuf = new ALBuffer())
			{
				AL.BufferData(alBuf, ALFormat.Stereo16, buffer, buffer.Length, source.SampleRate);
				AL.BindBufferToSource(alSrc, alBuf);
				AL.SourcePlay(alSrc);
				while (AL.GetSourceState(alSrc) == ALSourceState.Playing)
					await Task.Delay(10).ConfigureAwait(false);
			};
		}

		/// <summary>
		/// Dispose します。
		/// </summary>
		public void Dispose()
		{
			context.Dispose();
		}

		private async Task PlayAsync(IAudioSource source, int? loop = default, CancellationToken ct = default)
		{
			var enumerator = source.EnumerateSamples(loop).GetEnumerator();
			var arr = new short[source.SampleRate * 2];
			var alBuffers = new ALBuffer[2];

			using (var alSrc = new ALSource())
			using (alBuffers[0] = new ALBuffer())
			using (alBuffers[1] = new ALBuffer())
			{
				var isFinished = !FillBuffer(arr, enumerator, ct);
				AL.BufferData(alBuffers[0], ALFormat.Stereo16, arr, arr.Length * sizeof(short), source.SampleRate);
				if (!isFinished)
				{
					isFinished = !FillBuffer(arr, enumerator, ct);
					AL.BufferData(alBuffers[1], ALFormat.Stereo16, arr, arr.Length * sizeof(short), source.SampleRate);
				}
				AL.SourceQueueBuffer(alSrc, alBuffers[0]);
				AL.SourceQueueBuffer(alSrc, alBuffers[1]);
				AL.SourcePlay(alSrc);
				var t = Environment.TickCount;
				IsPlaying = true;
				while (!ct.IsCancellationRequested)
				{
					int processedCount, queuedCount;

					AL.Source(alSrc, ALSourcef.Pitch, Pitch);
					do
					{
						AL.GetSource(alSrc, ALGetSourcei.BuffersProcessed, out processedCount);
						await Task.Delay(20);
					}
					while (processedCount == 0 && !ct.IsCancellationRequested);

					while (processedCount > 0 && !ct.IsCancellationRequested)
					{
						int buffer = AL.SourceUnqueueBuffer(alSrc);
						if (!isFinished)
						{
							isFinished = !FillBuffer(arr, enumerator, ct);
							AL.BufferData(buffer, ALFormat.Stereo16, arr, arr.Length * sizeof(short), source.SampleRate);
							AL.SourceQueueBuffer(alSrc, buffer);
						}
						processedCount--;
					}

					AL.GetSource(alSrc, ALGetSourcei.BuffersQueued, out queuedCount);
					if (queuedCount > 0)
					{
						AL.GetSource(alSrc, ALGetSourcei.SourceState, out var state);
						if ((ALSourceState)state != ALSourceState.Playing)
							AL.SourcePlay(alSrc);
					}
					else
						break;
					await Task.Delay(10).ConfigureAwait(false);
				}
				 IsPlaying = false;
			};
		}

		private ALFormat GetALFormat(IAudioSource source)
		{
			switch (source.Channels)
			{
				case 1:
					return ALFormat.Mono16;
				case 2:
					return ALFormat.Stereo16;
				default:
					throw new ArgumentException(nameof(source));
			}
		}

		private bool FillBuffer(short[] buffer, IEnumerator<(short l, short r)> enumerator, CancellationToken ct)
		{
			var res = true;
			for (int i = 0; i < buffer.Length; i += 2)
			{
				if (ct.IsCancellationRequested)
					break;
				(buffer[i], buffer[i + 1]) = res ? enumerator.Current : (default, default);
				if (!enumerator.MoveNext())
					res = false;
			}
			return res;
		}

		private float gain;
		private AudioContext context;
		private CancellationTokenSource cts;
	}
}
