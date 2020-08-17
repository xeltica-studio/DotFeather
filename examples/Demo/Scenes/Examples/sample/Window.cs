using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DotFeather.Demo
{
	[DemoScene("/window")]
	[Description("en", "Window State")]
	[Description("ja", "Window State")]
	public class WindowScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			DF.Window.Mode = WindowMode.Resizable;
		}

		public override void OnUpdate()
		{
			var w = DF.Window;

			Cls();
			Print($"Location {w.Location}");
			Print($"Size {w.Size}");
			Print($"ActualSize {w.ActualSize}");
			Print($"IsFullScreen {w.IsFullScreen}");
			Print($"IsFocused {w.IsFocused}");
			Print($"DPI {w.Dpi}");
			Print($"Title {w.Title}");

			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}
	}
}
