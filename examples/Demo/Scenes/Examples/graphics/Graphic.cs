using System;
using System.Collections.Generic;
using System.Linq;

namespace DotFeather.Demo
{
	[DemoScene("/graphics/graphic")]
	[Description("en", "Create graphic screen and draw shapes")]
	[Description("ja", "グラフィック面を作成し図形描画を行います")]
	public class GraphicExampleScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			Root.Add(canvas);
		}

		public override void OnUpdate()
		{
			DF.Console.Cls();

			Print("Left click to draw: " + mode);
			Print("Right click to clear all");
			Print("Press C to switch the shape");
			Print("Scroll to move");
			Print("Press ↑ to scale up");
			Print("Press ↓ to scale down");
			Print("Press ESC to return");

			if (DFKeyboard.Up) canvas.Scale += Vector.One * Time.DeltaTime;
			if (DFKeyboard.Down) canvas.Scale -= Vector.One * Time.DeltaTime;
			if (DFKeyboard.C.IsKeyDown)
			{
				mode = (mode + 1) % 6;
			}
			canvas.Location += DFMouse.Scroll * (-1, 1);
			if (DFMouse.IsLeftDown)
			{
				var v0 = (VectorInt)((DFMouse.Position - canvas.AbsoluteLocation) / canvas.AbsoluteScale);
				var (v1, v2, v3) = (v0, v0 + (64, 24), v0 + (24, 64));
				var lineWidth = random.Next(16);
				switch (mode)
				{
					case 0:
						canvas.Line(v1, v2, random.NextColor(), lineWidth);
						break;
					case 1:
						canvas.Rect(v1, v2, random.NextColor(), lineWidth, random.NextColor());
						break;
					case 2:
						canvas.Ellipse(v1, v2, random.NextColor(), lineWidth, random.NextColor());
						break;
					case 3:
						canvas.Pixel(v1, random.NextColor());
						break;
					case 4:
						canvas.Triangle(v1, v2, v3, random.NextColor(), lineWidth, random.NextColor());
						break;
					case 5:
						var v = Enumerable.Repeat(5, 15).Select(_ => random.NextVectorInt(DF.Window.Width, DF.Window.Height)).ToArray();
						canvas.Polygon(random.NextColor(), lineWidth, random.NextColor(), v);
						break;
				}
			}
			if (DFMouse.IsRightDown)
			{
				canvas.Clear();
			}
			if (DFKeyboard.Escape.IsKeyUp)
				Router.ChangeScene<LauncherScene>();
		}

		private readonly Graphic canvas = new();
		private readonly Random random = new();
		private int mode = 0;
	}
}
