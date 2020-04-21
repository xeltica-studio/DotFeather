#pragma warning disable CS4014

namespace DotFeather.Demo
{
	[DemoScene("/audio/wav sfx")]
	[Description("en", "Play some short SFXs")]
	[Description("ja", "短い効果音をいくつか再生します")]
	public class WavExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{
			game.Print("SFX Example");
			game.Print(@"[SPACE]: Replay

[ESC]: Quit");
			player.PlayOneShotAsync(sfx);
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Space.IsKeyUp)
				player.PlayOneShotAsync(sfx);

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		readonly AudioPlayer player = new AudioPlayer();
		readonly WaveAudioSource sfx = new WaveAudioSource("sfx.wav");
	}
}
