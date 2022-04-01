using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotFeather
{
	/// <summary>
	/// Provides audio source playback functionality.
	/// </summary>
	public class AudioPlayer : IDisposable
	{
		/// <summary>
		/// Initialize a new instance of <see cref="AudioPlayer"/> .
		/// </summary>
		public AudioPlayer()
		{
			Debug.NotImpl("AudioPlayer.ctor");
			Gain = 1;
		}

		/// <summary>
		/// Get or set volume.
		/// </summary>
		/// <value>Volume range in 0.0 ~ 1.0.</value>
		public float Gain
		{
			get => gain;
			set
			{
				// 0...1の範囲に矯正
				Debug.NotImpl("AudioPlayer.Gain set");
			}
		}

		/// <summary>
		/// Get or set pitch of this player.
		/// </summary>
		/// <value>Pitch ratio value. Default is 1.</value>
		public float Pitch { get; set; } = 1;

		/// <summary>
		/// Get whether this player is playing。
		/// </summary>
		public bool IsPlaying { get; private set; }

		/// <summary>
		/// Get current playing time of this player in milliseconds.
		/// </summary>
		public int Time { get; private set; }

		/// <summary>
		/// Get current playing time of this player in samples.
		/// </summary>
		public int TimeInSamples { get; private set; }

		/// <summary>
		/// Get length of loaded audio in milliseconds.
		/// </summary>
		public int Length { get; private set; }

		/// <summary>
		/// Get length of loaded audio in samples.
		/// </summary>
		public int LengthInSamples { get; private set; }

		/// <summary>
		/// Start playing.
		/// </summary>
		/// <param name="source">A <see cref="IAudioSource"/> to play.</param>
		/// <param name="loop">Sample number of loop point. To disable loop, specify<c>null</c>.</param>
		public async Task PlayAsync(IAudioSource source, int? loop = default)
		{
			cts?.Cancel();
			cts = new CancellationTokenSource();
			await PlayAsync(source, loop, cts.Token);
		}

		/// <summary>
		/// Start playing.
		/// </summary>
		/// <param name="source">A <see cref="IAudioSource"/> to play.</param>
		/// <param name="loop">Sample number of loop point. To disable loop, specify<c>null</c>.</param>
		public void Play(IAudioSource source, int? loop = default)
		{
#pragma warning disable CS4014
			PlayAsync(source, loop);
		}

		/// <summary>
		/// Stop playing.
		/// </summary>
		/// <param name="time">Fade-out time. Specify 0 to stop soon.</param>
		public void Stop(float time = 0)
		{
			if (time == 0)
			{
				cts?.Cancel();
			}
			else
			{
				Task.Run(async () =>
				{
					var firstGain = Gain;
					Stopwatch w = new();
					w.Start();
					while (Gain > 0)
					{
						var current = (w.ElapsedMilliseconds / 1000f) / time;
						Gain = DFMath.Lerp(current, firstGain, 0);
						await Task.Delay(1);
					}
					cts?.Cancel();
					w.Stop();
					while (IsPlaying)
						await Task.Delay(10);
					Gain = 1;
				});
			}
			Time = TimeInSamples = 0;
		}

		/// <summary>
		/// Play specified <see cref="IAudioSource"/> instantly.
		/// </summary>
		/// <param name="source"><see cref="IAudioSource"/> to play.</param>
		/// <returns></returns>
		public async Task PlayOneShotAsync(IAudioSource source)
		{
			var buf = source.EnumerateSamples(null).GetEnumerator();
			if (source.Samples is not int samples)
				throw new ArgumentException("PlayOneShot requires AudioSource which has determined length.");
			var buffer = new short[samples];
			FillBuffer(buffer, buf, default);
			using (var alSrc = new ALSource())
			using (var alBuf = new ALBuffer())
			{
				Debug.NotImpl("AudioPlayer.PlayOneShotAsync");
			};
		}

		/// <summary>
		/// Dispose.
		/// </summary>
		public void Dispose()
		{
			Debug.NotImpl("AudioPlayer.Dispose");
		}

		private async Task PlayAsync(IAudioSource source, int? loop = default, CancellationToken ct = default)
		{
			var enumerator = source.EnumerateSamples(loop).GetEnumerator();
			var arr = new short[source.SampleRate / 2 * 2];
			var alBuffers = new ALBuffer[2];
			TimeInSamples = Time = 0;

			LengthInSamples = source.Samples ?? 0;
			Length = (int)(LengthInSamples / (float)source.SampleRate * 1000);

			Debug.NotImpl("AudioPlayer.PlayAsync");
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
		private CancellationTokenSource? cts;
	}
}
