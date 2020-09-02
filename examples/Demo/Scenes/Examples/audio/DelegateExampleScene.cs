using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DotFeather.Demo
{
	[DemoScene("/audio/delegate")]
	[Description("en", "Generate waveform by code and play")]
	[Description("ja", "波形をコードで生成し再生します")]
	public class DelegateExampleScene : Scene
	{
		public DelegateExampleScene()
		{
			for (var i = 0; i < 256; i++)
				waveTable.AddLast(1);
			source = new DelegateAudioSource((sampleCount, _) =>
			{
				var s = GenerateSine(sampleCount, freq, 44100);
				lock (l)
				{
					waveTable.AddLast(s);
					waveTable.RemoveFirst();
				}
				return (s, s);
			});
			visualizer.Location = (16, 96);
		}

		public override void OnStart(Dictionary<string, object> args)
		{
			Title = "Delegate Example";
			audio.Play(source);
			Root.Add(visualizer);
		}

		public override void OnRender()
		{
			visualizer.Clear();
			visualizer.Rect(0, 0, 512, 256, Color.FromArgb(64, 64, 64));
			int? p = null;
			int x = 0;
			visualizer.Line(0, 128, 512, 128, Color.FromArgb(48, 48, 48));
			lock (l)
			{
				foreach (var sample in waveTable.ToArray())
				{
					var y2 = (int)(sample / 32767f * 128 + 128);
					if (p is int ps)
					{
						var y1 = ps;
						visualizer.Line(x - 2, y1, x, y2, Color.Lime);
					}
					p = y2;
					x += 2;
				}
			}
		}

		public override void OnUpdate()
		{
			Cls();
			Print($@"Playing {freq}Hz Sine Wave
[←]:Down Frequency [→]: Up Frequency
PRESS ESC TO RETURN");

			if (DFKeyboard.Right)
			{
				freq += 10;
			}
			else if (DFKeyboard.Left)
			{
				freq -= 10;
			}

			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		public override void OnDestroy()
		{
			audio.Stop();
			audio.Dispose();
		}

		private short GenerateSine(int sample, float freq, float sampleRate) => (short)(MathF.Sin(2 * MathF.PI * sample * freq / sampleRate) * 32000);

		private float freq = 440;
		private readonly LinkedList<short> waveTable = new LinkedList<short>();
		private readonly Graphic visualizer = new Graphic();
		private readonly AudioPlayer audio = new AudioPlayer();
		private readonly IAudioSource source;
		private readonly object l = new object();
	}
}
