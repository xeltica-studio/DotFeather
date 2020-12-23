#pragma warning disable CS4014

namespace DotFeather.Demo
{
	[DemoScene("/audio/wav sfx")]
	[Description("en", "Play some short SFXs")]
	[Description("ja", "短い効果音をいくつか再生します")]
	public class WavExampleScene : Scene
	{
		public override void OnStart(System.Collections.Generic.Dictionary<string, object> args)
		{
			Print("SFX Example");
			Print(@"[SPACE]: Replay

[ESC]: Quit");
			player.PlayOneShotAsync(sfx);
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Space.IsKeyUp)
				player.PlayOneShotAsync(sfx);

			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		readonly AudioPlayer player = new();
		readonly WaveAudioSource sfx = new("sfx.wav");
	}
}
