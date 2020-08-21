// using System.Collections.Generic;

// namespace DotFeather.Demo
// {
// 	[DemoScene("/drawable/graphic")]
// 	[Description("en", "Create graphic screen and draw shapes")]
// 	[Description("ja", "グラフィック面を作成し図形描画を行います")]
// 	public class GraphicExampleScene : Scene
// 	{
// 		public override void OnStart(Dictionary<string, object> args)
// 		{
// 			Print("Press ESC to return");
// 			Root.Add(g);
// 		}

// 		public override void OnUpdate()
// 		{
// 			VectorInt Rnd() => Random.NextVectorInt(Window.Width, Window.Height);
// 			time += Time.DeltaTime;
// 			if (time > 0.125f)
// 			{
// 				switch (Random.Next(5))
// 				{
// 					case 0:
// 						g.Line(Rnd(), Rnd(), Random.NextColor());
// 						break;
// 					case 1:
// 						g.Rect(Rnd(), Rnd(), Random.NextColor(), Random.Next(4), Random.NextColor());
// 						break;
// 					case 2:
// 						g.Ellipse(Rnd(), Rnd(), Random.NextColor(), Random.Next(4), Random.NextColor());
// 						break;
// 					case 3:
// 						g.Pixel(Rnd(), Random.NextColor());
// 						break;
// 					case 4:
// 						g.Triangle(Rnd(), Rnd(), Rnd(), Random.NextColor(), Random.Next(4), Random.NextColor());
// 						break;
// 				}
// 				time = 0;
// 			}
// 			if (DFKeyboard.Escape.IsKeyUp)
// 				Router.ChangeScene<LauncherScene>();
// 		}

// 		private float time;
// 		private readonly Graphic g = new Graphic();
// 	}
// }
