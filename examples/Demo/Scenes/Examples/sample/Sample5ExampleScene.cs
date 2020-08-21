// using System.Collections.Generic;
// using System.Drawing;

// namespace DotFeather.Demo
// {
// 	[DemoScene("/sample5")]
// 	[Description("en", "Relative and absolute location of objects")]
// 	[Description("ja", "相対座標と絶対座標を取得する例")]
// 	public class LocationOfObjectExampleScene : Scene
// 	{
// 		public override void OnStart(Dictionary<string, object> args)
// 		{
// 			container.Add(text);
// 			text.Location = Vector.One * 32;
// 			Root.Add(container);
// 			Print("Press [ESC] to exit");
// 			Print("Press [SHIFT] to pause animating");
// 		}

// 		public override void OnUpdate()
// 		{
// 			text.Text = $@"Container: {(VectorInt)container.Location}
// Relative: {(VectorInt)text.Location}
// Absolute: {(VectorInt)text.AbsoluteLocation}";
// 			if (!DFKeyboard.ShiftLeft)
// 			{
// 				container.Location += Vector.One * 32 * way * Time.DeltaTime;
// 				if (container.Location.X > 256)
// 					way = -1;
// 				if (container.Location.X < 0)
// 					way = 1;
// 			}

// 			if (DFKeyboard.Escape.IsKeyUp)
// 				Router.ChangeScene<LauncherScene>();
// 		}

// 		private readonly Container container = new Container();
// 		private readonly TextDrawable text = new TextDrawable("", DFFont.GetDefault(16), Color.White);
// 		private int way = 1;
// 	}
// }
