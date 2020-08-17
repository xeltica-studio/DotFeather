using System;

namespace DotFeather.Demo
{
	[DemoScene("/audio/delegate")]
	[Description("en", "Generate waveform by code and play")]
	[Description("ja", "波形をコードで生成し再生します")]
	public class DelegateExampleScene : Scene
	{
		public DelegateExampleScene()
		{
			source = new DelegateAudioSource((sampleCount, _) =>
			{
				var s = GenerateSine(sampleCount, freq, 44100);
				return (s, s);
			});
		}

		public override void OnStart(System.Collections.Generic.Dictionary<string, object> args)
		{
			Title = "Delegate Example";
			audio.Play(source);
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

		private short GenerateSine(int sample, float freq, float sampleRate) => (short)(MathF.Sin(2 * MathF.PI * sample * freq / sampleRate) * 10000);

		private float freq = 440;
		private readonly AudioPlayer audio = new AudioPlayer();
		private readonly IAudioSource source;
	}
}
