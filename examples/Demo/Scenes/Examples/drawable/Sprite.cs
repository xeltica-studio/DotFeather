using System.Collections;
using System.Drawing;
using static DotFeather.ComponentFactory;

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
			var sprite = Sprite("ichigo", "./ichigo.png");
			var renderer = sprite.GetComponent<SpriteRenderer>();
			Print("Generated sprite.");
			yield return new WaitForSeconds(0.5f);

			Root.Add(sprite);
			Print("Added it to the root container.");
			yield return new WaitForSeconds(0.5f);

			sprite.Transform.Location = new Vector(256, 256);
			Print("Moved it to (256, 256).");
			yield return new WaitForSeconds(2);

			sprite.Transform.Scale = new Vector(2, 8);
			Print("Changed its scale, now the X is 2 times and the Y is 8 times.");
			yield return new WaitForSeconds(2);

			renderer.TintColor = Color.Blue;
			Print("Set the sprite's tint color to blue.");
			yield return new WaitForSeconds(2);

			sprite.Transform.Scale = Vector.One;
			renderer.TintColor = null;

			renderer.Size = (256, 192);
			Print("Set its width and height.");
			yield return new WaitForSeconds(2);

			Print("Press ESC to return");
		}
	}
}
