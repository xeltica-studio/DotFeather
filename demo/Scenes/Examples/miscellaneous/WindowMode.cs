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
            game.Print("Window Mode");
            game.Print("[1]: No Frame");
            game.Print("[2]: Resizable");
            game.Print("[3]: Fixed");
            game.Print("[4]: Toggle FullScreen");
            game.Print("[ESC]: Escape");
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
    }

}
