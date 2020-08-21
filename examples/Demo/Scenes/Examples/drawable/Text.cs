using System.Drawing;
using static DotFeather.ComponentFactory;

namespace DotFeather.Demo
{
	[DemoScene("/drawable/text")]
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
			if (time > 0.125f)
			{
				Root.Add(
					Text($"test{count}", $"Test {count}", DFFont.GetDefault(Random.Next(8, 48)), Random.NextColor())
						.With(Random.NextVector(Window.Width, Window.Height))
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
