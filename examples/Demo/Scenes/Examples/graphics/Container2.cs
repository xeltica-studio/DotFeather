using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DotFeather.Demo
{
	[DemoScene("/graphics/container2")]
	[Description("en", "Add some elements into the container and control it")]
	[Description("ja", "エレメントをコンテナーにいくつか追加し、制御するサンプル")]
	public class Container2ExampleScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			ichigo = Texture2D.LoadFrom("ichigo.png");
			var con = new Container();
			Root.Add(container);

			container.Add(con);
			con.Location = (128, 128);

			for (var i = 0; i < 8; i++)
				con.Add(new Sprite(ichigo)
				{
					Location = (i * ichigo.Size.X, 0),
				});
			Print("Scroll to move");
			Print("Press ↑ to scale up");
			Print("Press ↓ to scale down");
			Print("Press ESC to return");
		}

		public override void OnUpdate()
		{
			if (DFKeyboard.Up) container.Scale += Vector.One * 0.25f * Time.DeltaTime;
			if (DFKeyboard.Down) container.Scale -= Vector.One * 0.25f * Time.DeltaTime;
			container.Location += DFMouse.Scroll * (-1, 1);
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		public override void OnDestroy()
		{
			ichigo.Dispose();
		}

		private Texture2D ichigo;
		private readonly Container container = new Container();
	}
}
