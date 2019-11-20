namespace DotFeather.Demo
{
    [DemoScene("/drawable/9 slice sprite")]
    [Description("en", "Display and resize 9slice sprite")]
    [Description("ja", "9スライススプライトを生成し、伸び縮みさせます")]
    public class NineSliceSpriteExampleScene : Scene
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
