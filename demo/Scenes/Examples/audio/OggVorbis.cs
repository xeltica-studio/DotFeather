namespace DotFeather.Demo
{
	[DemoScene("/audio/ogg vorbis")]
	[Description("en", "Play a BGM")]
	[Description("ja", "BGM を再生します")]
	public class OggVorbisExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{
			Title = "Ogg Vorbis playback example";
			game.Print("Ogg Vorbis playback Example");
			audio.Play(bgm);
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			game.ConsoleCursor += VectorInt.Up * 2;
			game.Print($@"Location: {audio.Time / 1000f:0.000} / {audio.Length / 1000f:0.000}
PRESS ESC TO RETURN");

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		public override void OnDestroy(Router router)
		{
			audio.Stop();
			audio.Dispose();
		}

		private AudioPlayer audio = new AudioPlayer();
		private IAudioSource bgm = new VorbisAudioSource("kagerou.ogg");
	}

}
