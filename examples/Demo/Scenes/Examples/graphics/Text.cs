using System.Drawing;
using static DotFeather.ComponentFactory;

namespace DotFeather.Demo
{
	[DemoScene("/graphics/text")]
	[Description("en", "Draw text on the screen.")]
	[Description("ja", "画面上にテキストを描画します。")]
	public class TextExampleScene : Scene
	{
		public override void OnStart(System.Collections.Generic.Dictionary<string, object> args)
		{
			Print("Press ESC to return");
		}

		public override void OnUpdate()
		{
			time += Time.DeltaTime;
			if (time > 0.0625f)
			{
				Root.Add(
					Text($"test{count}", $"Test {count}", DFFont.GetDefault(Random.Next(8, 48)), Random.NextColor())
						.TranslateTo(Random.NextVector(Window.Width, Window.Height))
				);
				time = 0;
				count++;
			}
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		private float time;
		private int count;
	}
}
