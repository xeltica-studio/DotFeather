namespace DotFeather.Demo
{
	[DemoScene("/graphics/sprite animator")]
	[Description("en", "Usage of SpriteAnimator component")]
	[Description("ja", "Sprite Animator コンポーネントの使用例")]
	public class SpriteAniamtorExampleScene : Scene
	{
		public override void OnStart(System.Collections.Generic.Dictionary<string, object> _)
		{
			qbox = Texture2D.LoadAndSplitFrom("qbox.png", 8, 1, (16, 16));
			Root.Add(
				new Element("Question Box")
					.Translate((128, 128))
					.With(new SpriteRenderer())
					.With(new SpriteAnimator(qbox, true, -1, 8))
			);
			DF.Console.Print("Press ESC to return");
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape.IsKeyDown)
				DF.Router.ChangeScene<LauncherScene>();
		}

		public override void OnDestroy()
		{
			if (qbox != null)
				foreach (var t in qbox)
					t.Dispose();
		}

		private Texture2D[]? qbox;
	}
}
