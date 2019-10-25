namespace DotFeather.Example
{
    [ExampleScene("/audio/wav sfx")]
    [Description("en", "Play some short SFXs")]
    [Description("ja", "短い効果音をいくつか再生します")]
    public class WavExampleScene : Scene
    {
        public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
        {
			var head = ExampleOS.Text("SFX Example", 48);
			head.Location = Vector.One * 16;
			var body = ExampleOS.Text(@"[SPACE]: Replay

[ESC]: Quit", 16);
			body.Location = new Vector(16, 32 + head.Height);
			Root.Add(head);
			Root.Add(body);

			player.PlayOneShotAsync(sfx);
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
			if (DFKeyboard.Space.IsKeyUp)
				player.PlayOneShotAsync(sfx);

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
        }

		AudioPlayer player = new AudioPlayer();
		WaveAudioSource sfx = new WaveAudioSource("sfx.wav");
    }

}
