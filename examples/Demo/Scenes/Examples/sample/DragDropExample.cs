namespace DotFeather.Demo
{
	[DemoScene("/sample3")]
	[Description("en", "Drag and drop example")]
	[Description("ja", "ドラッグアンドドロップの例")]
	public class Sample4ExampleScene : Scene
	{
		public override void OnStart(System.Collections.Generic.Dictionary<string, object> args)
		{
			Window.FileDropped += FileDrop!;
			Print("Drop some files");
			Print("Press [ESC] to return");
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		public override void OnDestroy()
		{
			Window.FileDropped -= FileDrop!;
		}

		private void FileDrop(DFFileDroppedEventArgs e)
		{
			Title = e.Path;
			Print($"Dropped file is {e.Path}");
		}
	}
}
