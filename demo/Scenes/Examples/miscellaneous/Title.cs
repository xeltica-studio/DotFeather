using System.Collections;

namespace DotFeather.Demo
{
    [DemoScene("/miscellaneous/window title")]
    [Description("en", "Switch title")]
    [Description("ja", "タイトルを切り替えます")]
    public class TitleExampleScene : Scene
    {
        public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
        {
            var head = DemoOS.Text("Title", 48);
            head.Location = Vector.One * 16;
            log.Location = new Vector(16, 32 + head.Height);
            Root.Add(head);
            Root.Add(log);

            CoroutineRunner.Start(Main());
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
            if (DFKeyboard.Escape.IsKeyUp)
                router.ChangeScene<LauncherScene>();
        }

        IEnumerator Main()
        {
            yield return SetTitle("Cupcake");
            yield return SetTitle("Donut");
            yield return SetTitle("Eclair");
            yield return SetTitle("Froyo");
            yield return SetTitle("Gingerbread");
            yield return SetTitle("Honeycomb");
            yield return SetTitle("Ice Cream Sandwich");
            yield return SetTitle("Jelly Bean");
            log.Text += "Press [ESC] to return";
        }

        IEnumerator SetTitle(string title)
        {
            yield return new WaitForSeconds(1);
            Title = title;
            log.Text += $"Changed title to '{title}'\n";
        }

        TextDrawable log = DemoOS.Text("", 16);
    }

}
