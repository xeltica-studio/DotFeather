using System.Linq;

namespace DotFeather.Demo
{
    [DemoScene("/input/keyboard")]
    [Description("en", "Display keyboard states")]
    [Description("ja", "キーボードのステートを表示します")]
    public class KeyboardExampleScene : Scene
    {
        public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
        {
			var head = DemoOS.Text("Keyboard State", 48);
			head.Location = Vector.One * 16;
			log.Location = new Vector(16, 32 + head.Height);
			Root.Add(head);
			Root.Add(log);
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
			log.Text = $@"Pressing: {string.Join(",", DFKeyboard.AllPressedKeys.Select(d => d.ToString()))}
Pressed: {string.Join(",", DFKeyboard.AllDownKeys.Select(d => d.ToString()))}
Released: {string.Join(",", DFKeyboard.AllUpKeys.Select(d => d.ToString()))}";
        }

		TextDrawable log = DemoOS.Text("", 16);
    }
}
