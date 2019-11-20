namespace DotFeather.Demo
{
    [DemoScene("/drawable/tilemap")]
    [Description("en", "Generate tilemap and scroll")]
    [Description("ja", "タイルマップを作成しスクロールします")]
    public class TilemapExampleScene : Scene
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
