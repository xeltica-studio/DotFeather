namespace DotFeather.Example
{
    [ExampleScene("/audio/ogg vorbis")]
    [Description("en", "Play a BGM")]
    [Description("ja", "BGM を再生します")]
    public class OggVorbisExampleScene : Scene
    {
        public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
        {
			Title = "Ogg Vorbis playback example";
			head = ExampleOS.Text("Ogg Vorbis playback Example", 32);
			head.Location = Vector.One * 16;
			audio.Play(bgm);

			body = ExampleOS.Text("", 16);
			body.Location = new Vector(16, head.Location.Y + head.Height + 16);

			Root.Add(head);
			Root.Add(body);
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
			body!.Text = $@"Location: {audio.Time / 1000f:0.000} / {audio.Length / 1000f:0.000}



PRESS ESC TO RETURN";

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
	    }

		public override void OnDestroy(Router router)
		{
			audio.Stop();
			audio.Dispose();
		}

		private TextDrawable? head, body;
		private AudioPlayer audio = new AudioPlayer();
		private IAudioSource bgm = new VorbisAudioSource("kagerou.ogg");
    }

}
