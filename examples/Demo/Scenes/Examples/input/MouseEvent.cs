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
			DFMouse.Click += OnClick;
			DFMouse.ButtonDown += OnButtonDown;
			DFMouse.ButtonUp += OnButtonUp;
			DFMouse.Move += OnMove;
			DFMouse.Enter += OnEnter;
			DFMouse.Leave += OnLeave;
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Escape)
			{
				DF.Router.ChangeScene<LauncherScene>();
			}
		}

		public override void OnDestroy()
		{
			DFMouse.Click -= OnClick;
			DFMouse.ButtonDown -= OnButtonDown;
			DFMouse.ButtonUp -= OnButtonUp;
			DFMouse.Move -= OnMove;
			DFMouse.Enter -= OnEnter;
			DFMouse.Leave -= OnLeave;
		}

		private void OnClick(DFMouseButtonEventArgs e) => DF.Console.Print($"Click pos={e.Position} id={e.ButtonId}");
		private void OnButtonDown(DFMouseButtonEventArgs e) => DF.Console.Print($"ButtonDown pos={e.Position} id={e.ButtonId}");
		private void OnButtonUp(DFMouseButtonEventArgs e) => DF.Console.Print($"ButtonUp pos={e.Position} id={e.ButtonId}");
		private void OnMove(DFMouseEventArgs e) => DF.Console.Print($"Move pos={e.Position}");
		private void OnEnter() => DF.Console.Print("Enter");
		private void OnLeave() => DF.Console.Print("Leave");
	}
}
