namespace DotFeather.Demo
{
	[DemoScene("/audio/ogg vorbis")]
	[Description("en", "Play a BGM")]
	[Description("ja", "BGM を再生します")]
	public class OggVorbisExampleScene : Scene
	{
		public override void OnStart(System.Collections.Generic.Dictionary<string, object> args)
		{
			Title = "Ogg Vorbis playback example";
			DF.Console.Print("Ogg Vorbis playback Example");
			audio.Play(bgm);
		}

		public override void OnUpdate()
		{
			ConsoleCursor += VectorInt.Up * 2;
			Print($@"Location: {audio.Time / 1000f:0.000} / {audio.Length / 1000f:0.000}
[↑] Volume Up
[↓] Volume Down
[←] Pitch Down
[→] Pitch Up
PRESS ESC TO RETURN");

			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();

			if (DFKeyboard.Up.IsKeyDown)
				audio.Gain++;

			if (DFKeyboard.Down.IsKeyDown)
				audio.Gain--;

			if (DFKeyboard.Left.IsKeyDown)
				audio.Pitch *= .5f;

			if (DFKeyboard.Right.IsKeyDown)
				audio.Pitch *= 2;
		}

		public override void OnDestroy()
		{
			audio.Stop();
			audio.Dispose();
		}

		private readonly AudioPlayer audio = new();
		private readonly IAudioSource bgm = new VorbisAudioSource("kagerou.ogg");
	}

}
