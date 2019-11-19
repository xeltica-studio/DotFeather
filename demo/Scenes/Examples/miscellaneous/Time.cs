namespace DotFeather.Demo
{
    [DemoScene("/miscellaneous/Time")]
    [Description("en", "Display time information")]
    [Description("ja", "時間情報を表示します")]
    public class TimeExampleScene : Scene
    {
        public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
        {
            var head = DemoOS.Text("Time", 48);
            head.Location = Vector.One * 16;
            log.Location = new Vector(16, 32 + head.Height);
            Root.Add(head);
            Root.Add(log);
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
            log.Text = $@"Time: {Time.Now}
DeltaTime: {Time.DeltaTime}
Fps: {Time.Fps}
Press [ESC] to return";

            if (DFKeyboard.Escape.IsKeyUp)
                router.ChangeScene<LauncherScene>();
        }

        TextDrawable log = DemoOS.Text("", 16);
    }

}
