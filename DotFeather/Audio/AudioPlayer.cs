using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DotFeather.Helpers;
using OpenTK;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;

namespace DotFeather.Audio
{
    public class AudioPlayer : IDisposable
    {
        public AudioPlayer()
        {
			context = new AudioContext();
			Gain = 1;
        }

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

        public bool IsPlaying { get; private set; }

        public void Play(IAudioSource source, int? loop = default)
		{
			if (cts != default)
			{
				cts.Cancel();
			}
			cts = new CancellationTokenSource();
			#pragma warning disable CS4104
            PlayAsync(source, loop, cts.Token);
		}

		public void Play()
		{
			IsPlaying = true;
		}

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

					do
					{
						AL.GetSource(alSrc, ALGetSourcei.BuffersProcessed, out processedCount);
						await Task.Delay(20);
					}
					while(processedCount == 0 && !ct.IsCancellationRequested);

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

        public void Dispose()
        {
            context.Dispose();
        }

        private float gain;
		private AudioContext context;
		private CancellationTokenSource cts;
    }
}
