using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DotFeather.Demo
{
	[DemoScene("/graphics/container")]
	[Description("en", "Add some elements into the container and control it")]
	[Description("ja", "エレメントをコンテナーにいくつか追加し、制御するサンプル")]
	public class ContainerExampleScene : Scene
	{
		public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
		{
			ichigo = Texture2D.LoadFrom("ichigo.png");
			Root.Add(container);

			var random = new System.Random(300);

			container.Add(new TextDrawable("O", 32, FontStyle.Normal, Color.White));

			// container.Add(canvas);

			for (var i = 0; i < 8; i++)
			{
				container.Add(new Sprite(ichigo)
				{
					Location = random.NextVector(game.Width, game.Height),
					Scale = Vector.One + random.NextVectorFloat() * 7,
					Color = random.NextColor(),
				});
			}

			game.Print("Scroll to move");
			game.Print("Press ↑ to scale up");
			game.Print("Press ↓ to scale down");
			game.Print("Press ESC to return");
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			if (DFKeyboard.Up) container.Scale += Vector.One * 0.25f * Time.DeltaTime;
			if (DFKeyboard.Down) container.Scale -= Vector.One * 0.25f * Time.DeltaTime;
			container.Location += DFMouse.Scroll * new Vector(-1, 1);
			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		public override void OnDestroy(Router router)
		{
			ichigo.Dispose();
		}

		private Texture2D ichigo;
		private readonly Container container = new Container();
	}
}
