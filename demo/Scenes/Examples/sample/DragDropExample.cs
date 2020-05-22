namespace DotFeather.Demo
{
	[DemoScene("/sample3")]
	[Description("en", "Drag and drop example")]
	[Description("ja", "ドラッグアンドドロップの例")]
	public class Sample4ExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{
			game.FileDrop += FileDrop!;
			this.game = game;
			game?.Print("Drop some files");
			game?.Print("Press [ESC] to return");
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		public override void OnDestroy(Router router)
		{
			router.Game.FileDrop -= FileDrop!;
		}

		private void FileDrop(object sender, DFFileDroppedEventArgs e)
		{
			Title = $"Dropped {e.Pathes.Length} file{(e.Pathes.Length > 1 ? "s" : "")}";
			game?.Print($"Dropped file: \n{string.Join("\n", e.Pathes)}\n");
		}

		private GameBase? game;
	}
}
