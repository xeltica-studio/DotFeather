using System.Collections;
using System.Drawing;

namespace DotFeather.Demo
{
	[DemoScene("/graphics/sprite")]
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
			var sprite = new Sprite("./ichigo.png");
			Print("Generated sprite.");
			yield return new WaitForSeconds(0.5f);

			Root.Add(sprite);
			Print("Added it to the root container.");
			yield return new WaitForSeconds(0.5f);

			sprite.Location = (256, 256);
			Print("Moved it to (256, 256).");
			yield return new WaitForSeconds(2);

			sprite.Scale = (2, 8);
			Print("Changed its scale, now the X is 2 times and the Y is 8 times.");
			yield return new WaitForSeconds(2);

			sprite.TintColor = Color.Blue;
			Print("Set the sprite's tint color to blue.");
			yield return new WaitForSeconds(2);

			sprite.Scale = (1, 1);
			sprite.TintColor = null;

			sprite.Size = (256, 192);
			Print("Set its width and height.");
			yield return new WaitForSeconds(2);

			Print("Press ESC to return");
		}
	}
}
