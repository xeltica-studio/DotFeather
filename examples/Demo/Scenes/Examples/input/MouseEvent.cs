using System.Collections.Generic;

namespace DotFeather.Demo
{
	[DemoScene("/input/mouse-event")]
	[Description("en", "Receive and Output Mouse Event")]
	[Description("ja", "マウスイベントを受け取り、出力します。")]
	public class MouseEventExampleScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			DFMouse.Click += e =>
			{
				DF.Console.Print($"Click pos={e.Position} id={e.ButtonId}");
			};
			DFMouse.DoubleClick += e =>
			{
				DF.Console.Print($"DoubleClick pos={e.Position} id={e.ButtonId}");
			};
			DFMouse.ButtonDown += e =>
			{
				DF.Console.Print($"ButtonDown pos={e.Position} id={e.ButtonId}");
			};
			DFMouse.ButtonUp += e =>
			{
				DF.Console.Print($"ButtonUp pos={e.Position} id={e.ButtonId}");
			};
			DFMouse.Move += e =>
			{
				DF.Console.Print($"Move pos={e.Position}");
			};
			DFMouse.Enter += () =>
			{
				DF.Console.Print("Enter");
			};
			DFMouse.Leave += () =>
			{
				DF.Console.Print("Leave");
			};
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape)
			{
				DF.Router.ChangeScene<LauncherScene>();
			}
		}
	}
}
