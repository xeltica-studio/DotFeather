using System;

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
					new TextElement($"Test {count}", DFFont.GetDefault(random.Next(8, 48)), random.NextColor())
					{
						Location = random.NextVector(Window.Width, Window.Height)
					}
				);
				time = 0;
				count++;
			}
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		private float time;
		private int count;
		private readonly Random random = new Random();
	}
}
