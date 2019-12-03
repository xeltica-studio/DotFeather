using System.Collections;
using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/drawable/animated tile")]
	[Description("en", "Example of animated tile")]
	[Description("ja", "アニメーションするタイルの例")]
	public class AnimatedTileExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{
			qboxes = Texture2D.LoadAndSplitFrom("qbox.png", 8, 1, VectorInt.One * 16);
			var tile = new Tile(qboxes, 0.125f);
			var map = new Tilemap(Vector.One * 16);
			Root.Add(map);
			map[8, 12] = tile;
			game.Print("Press ESC to return");
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		public override void OnDestroy(Router router)
		{
			foreach (var qbox in qboxes!) qbox.Dispose();
			base.OnDestroy(router);
		}

		Texture2D[]? qboxes;
	}
}
