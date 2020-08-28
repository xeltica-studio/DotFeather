using System;
using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/graphics/9 slice sprite")]
	[Description("en", "Display and resize 9slice sprite")]
	[Description("ja", "9スライススプライトを生成し、伸び縮みさせます")]
	public class NineSliceSpriteExampleScene : Scene
	{
		public override void OnStart(System.Collections.Generic.Dictionary<string, object> args)
		{
			Print("Press ESC to return");

			Root =
				new Element("root",
					sprite = new Sprite("rect.png"),
					nineslice = new NineSliceSprite("rect.png", 16, 16, 16, 16),
					t1 = new TextElement("Sprite", 18, DFFontStyle.Normal, Color.Lime),
					t2 = new TextElement("9-slice Sprite", 18, DFFontStyle.Normal, Color.Lime)
				);
		}

		public override void OnUpdate()
		{
			sprite.Location = (DF.Window.Width / 4 - 128, 64);
			nineslice.Location = (DF.Window.Width / 4 + 32, 64);

			t1.Location = (sprite.Location.X, sprite.Location.Y - 24);
			t2.Location = (nineslice.Location.X, nineslice.Location.Y - 24);

			sprite.Width = nineslice.Width = (int)(64 + 64 * Math.Abs(Math.Sin(Time.Now * 2)));
			sprite.Height = nineslice.Height = (int)(64 + 256 * Math.Abs(Math.Sin(Time.Now * 2)));

			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

#pragma warning disable
		private static Sprite sprite;
		private static NineSliceSprite nineslice;
		private static TextElement t1;
		private static TextElement t2;
#pragma warning restore
	}

}
