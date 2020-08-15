using System.Collections;
using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/drawable/sprite")]
	[Description("en", "Generate, display and move sprites")]
	[Description("ja", "スプライトを生成して表示し、動かします")]
	public class SpriteExampleScene : Scene
	{
		public override void OnStart(System.Collections.Generic.Dictionary<string, object> args)
		{
			CoroutineRunner.Start(Main());
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		IEnumerator Main()
		{
			var sprite = Sprite.LoadFrom("./ichigo.png");
			Print("Generated sprite.");
			yield return new WaitForSeconds(0.5f);

			Root.Add(sprite);
			Print("Added it to the root container.");
			yield return new WaitForSeconds(0.5f);

			sprite.Location = new Vector(256, 256);
			Print("Moved it to (256, 256).");
			yield return new WaitForSeconds(2);

			sprite.Scale = new Vector(2, 8);
			Print("Changed its scale, now the X is 2 times and the Y is 8 times.");
			yield return new WaitForSeconds(2);

			sprite.Color = Color.Blue;
			Print("Set the sprite's tint color to blue.");
			yield return new WaitForSeconds(2);

			sprite.Scale = Vector.One;
			sprite.Color = null;

			sprite.Width = 256;
			sprite.Height = 192;
			Print("Set its width and height.");
			yield return new WaitForSeconds(2);

			Print("Press ESC to return");
		}
	}
}
