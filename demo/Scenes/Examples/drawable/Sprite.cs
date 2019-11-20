using System.Collections;
using System.Drawing;

namespace DotFeather.Demo
{
    [DemoScene("/drawable/sprite")]
    [Description("en", "Generate, display and move sprites")]
    [Description("ja", "スプライトを生成して表示し、動かします")]
    public class SpriteExampleScene : Scene
    {
        public override void OnStart(Router router, GameBase game, System.Collections.Generic.Dictionary<string, object> args)
        {
            game.StartCoroutine(Main(game));
        }

        public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
        {
            if (DFKeyboard.Escape.IsKeyUp)
                router.ChangeScene<LauncherScene>();
        }

        IEnumerator Main(GameBase game)
        {
            var sprite = Sprite.LoadFrom("./ichigo.png");
            game.Print("Generated sprite.");
            yield return new WaitForSeconds(0.5f);

            Root.Add(sprite);
            game.Print("Added it to the root container.");
            yield return new WaitForSeconds(0.5f);

            sprite.Location = new Vector(256, 256);
            game.Print("Moved it to (256, 256).");
            yield return new WaitForSeconds(2);

            sprite.Scale = new Vector(2, 8);
            game.Print("Changed its scale, now the X is 2 times and the Y is 8 times.");
            yield return new WaitForSeconds(2);

            sprite.Color = Color.Blue;
            game.Print("Set the sprite's tint color to blue.");
            yield return new WaitForSeconds(2);

            sprite.Scale = Vector.One;
            sprite.Color = null;

            sprite.Width = 256;
            sprite.Height = 192;
            game.Print("Set its width and height.");
            yield return new WaitForSeconds(2);

            game.Print("Press ESC to return");
        }
    }

}
