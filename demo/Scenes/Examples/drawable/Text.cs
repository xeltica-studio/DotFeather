namespace DotFeather.Demo
{
    [DemoScene("/drawable/text")]
    [Description("en", "Draw text on the screen.")]
    [Description("ja", "画面上にテキストを描画します。")]
    public class TextExampleScene : Scene
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
