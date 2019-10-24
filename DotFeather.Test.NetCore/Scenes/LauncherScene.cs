using System.Drawing;

namespace DotFeather.Example
{
    public class LauncherScene : Scene
    {
		const string SYSTEM_FONT_PATH = "./font.ttf";
		const string VERSION = "1.0";
        public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
        {
            BackgroundColor = Color.FromArgb(255, 32, 32, 32);
			var titleText = Text("DotFeather", 56);
			var sampleProgramText = Text($"Example {VERSION}", 24);
			titleText.Location = new Vector(24, 24);
			sampleProgramText.Location = new Vector(24 + titleText.Width + 8, 50);

			Root.Add(titleText);
			Root.Add(sampleProgramText);
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
            Title = ExampleOS.Path != null ? $"DotFeather Example - {ExampleOS.Path}" : "DotFeather Example";
        }

		private TextDrawable Text(string text, int size, Color? color = null)
		{
			return new TextDrawable(text, new Font(SYSTEM_FONT_PATH, size), color ?? Color.White);
		}
    }
}