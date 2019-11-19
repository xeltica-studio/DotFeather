using System.Collections;

namespace DotFeather.Demo
{
    [DemoScene("/miscellaneous/window mode")]
    [Description("en", "Change window mode")]
    [Description("ja", "ウィンドウのモードを切り替えます")]
    public class WindowModeExampleScene : Scene
    {
        public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
        {
            var head = DemoOS.Text("Window Mode", 48);
            head.Location = Vector.One * 16;
            log.Location = new Vector(16, 32 + head.Height);
            Root.Add(head);
            Root.Add(log);

            Log("[1]: No Frame");
            Log("[2]: Resizable");
            Log("[3]: Fixed");
            Log("[4]: Toggle FullScreen");
            Log("[ESC]: Escape");
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
            if (DFKeyboard.Escape.IsKeyUp)
                router.ChangeScene<LauncherScene>();
            else if (DFKeyboard.Number1.IsKeyUp)
                game.WindowMode = WindowMode.NoFrame;
            else if (DFKeyboard.Number2.IsKeyUp)
                game.WindowMode = WindowMode.Resizable;
            else if (DFKeyboard.Number3.IsKeyUp)
                game.WindowMode = WindowMode.Fixed;
            else if (DFKeyboard.Number4.IsKeyUp)
                game.IsFullScreen ^= true;
        }

        void Log(string title)
        {
            log.Text += $"Changed title to '{title}'\n";
        }

        TextDrawable log = DemoOS.Text("", 16);
    }

}
