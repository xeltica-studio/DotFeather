using System.Collections.Generic;
using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/sample1")]
	[Description("en", @"""Hello, world!""")]
	[Description("ja", @"""Hello, world!""")]
	public class Sample1ExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
		{
			game.Print("Hello, world!");
			game.Print("Press [ESC] to exit");
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}
	}

	[DemoScene("/sample5")]
	[Description("en", "Relative and absolute location of objects")]
	[Description("ja", "相対座標と絶対座標を取得する例")]
	public class Sample5ExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
		{
			container.Add(text);
			text.Location = Vector.One * 32;
			Root.Add(container);
			game.Print("Press [ESC] to exit");
			game.Print("Press [SHIFT] to pause animating");
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			text.Text = $@"Container: {(VectorInt)container.Location}
Relative: {(VectorInt)text.Location}
Absolute: {(VectorInt)text.AbsoluteLocation}";
			if (!DFKeyboard.ShiftLeft)
			{
				container.Location += Vector.One * 32 * way * e.DeltaTime;
				if (container.Location.X > 256)
					way = -1;
				if (container.Location.X < 0)
					way = 1;
			}

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		private Container container = new Container();
		private TextDrawable text = new TextDrawable("", Font.GetDefault(16), Color.White);
		private int way = 1;
	}
}
