namespace DotFeather.Demo
{
    [DemoScene("/input/mouse")]
    [Description("en", "Display mouse states")]
    [Description("ja", "マウスのステートを表示します")]
    public class MouseExampleScene : Scene
    {
        public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
        {
			var head = DemoOS.Text("Mouse State", 48);
			head.Location = Vector.One * 16;
			log.Location = new Vector(16, 32 + head.Height);
			Root.Add(head);
			Root.Add(log);
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
			log.Text = $@"Left: {Left()}
Middle: {Middle()}
Right: {Right()}
Scroll: {DFMouse.Scroll}
Pos: {DFMouse.Position}";
        }

		public string Left()
		{
			return DFMouse.IsLeftDown ? "Pressed" :
				   DFMouse.IsLeftUp ? "Released" :
				   DFMouse.IsLeft ? "Pressing" : "";
		}

		public string Middle()
		{
			return DFMouse.IsMiddleDown ? "Pressed" :
				   DFMouse.IsMiddleUp ? "Released" :
				   DFMouse.IsMiddle ? "Pressing" : "";
		}

		public string Right()
		{
			return DFMouse.IsRightDown ? "Pressed" :
				   DFMouse.IsRightUp ? "Released" :
				   DFMouse.IsRight ? "Pressing" : "";
		}

		TextDrawable log = DemoOS.Text("", 16);
    }

}
