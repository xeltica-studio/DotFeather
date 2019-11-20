namespace DotFeather.Demo
{
    [DemoScene("/drawable/graphic")]
    [Description("en", "Create graphic screen and draw shapes")]
    [Description("ja", "グラフィック面を作成し図形描画を行います")]
    public class GraphicExampleScene : Scene
    {
        public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
        {
            game.Print("Press ESC to return");
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
            if (DFKeyboard.Escape.IsKeyUp)
                router.ChangeScene<LauncherScene>();
        }
    }

}
