using System;
using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/drawable/9 slice sprite")]
	[Description("en", "Display and resize 9slice sprite")]
	[Description("ja", "9スライススプライトを生成し、伸び縮みさせます")]
	public class NineSliceSpriteExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
		{
			game.Print("Press ESC to return");
			Root.Add(sprite);
			Root.Add(nineslice);
			Root.Add(t1);
			Root.Add(t2);
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();

			// sprites location
			sprite.Location = new Vector(game.Width / 4 - 128, 64);
			nineslice.Location = new Vector(game.Width / 4 + 32, 64);

			// text location
			t1.Location = new Vector(sprite.Location.X, sprite.Location.Y - 24);
			t2.Location = new Vector(nineslice.Location.X, nineslice.Location.Y - 24);

			sprite.Width = nineslice.Width = (int)(64 + 64 * Math.Abs(Math.Sin(Time.Now * 2)));
			sprite.Height = nineslice.Height = (int)(64 + 256 * Math.Abs(Math.Sin(Time.Now * 2)));
		}

		private Sprite sprite = Sprite.LoadFrom("./rect.png");
		private NineSliceSprite nineslice = NineSliceSprite.LoadFrom("./rect.png", 16, 16, 16, 16);
		private TextDrawable t1 = new TextDrawable("Sprite", Font.GetDefault(18), Color.Lime);
		private TextDrawable t2 = new TextDrawable("9-slice Sprite", Font.GetDefault(18), Color.Lime);
	}

}
