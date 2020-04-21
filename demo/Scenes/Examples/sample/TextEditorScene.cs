using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace DotFeather.Demo
{
	[DemoScene("/sample4")]
	[Description("en", @"Simple Text Editor")]
	[Description("ja", @"簡易テキストエディタ")]
	public class TextEditorScene : Scene
	{
		public override void OnStart(Router router, GameBase game, Dictionary<string, object> args)
		{
			game.Print("DotFeather Text Editor");
			game.Print("Press [ESC] to exit");

			// flush text buffer
			DFKeyboard.GetString();
			Root.Add(editorView);
		}

		public override void OnUpdate(Router router, GameBase game, DFEventArgs e)
		{
			editorView.Text = buf.ToString() + '_';
			if ((DFKeyboard.BackSpace.ElapsedFrameCount == 1 || DFKeyboard.BackSpace.ElapsedTime > 0.5f && DFKeyboard.BackSpace.ElapsedFrameCount % 3 == 0) && buf.Length > 0) buf.Length--;
			if (DFKeyboard.Enter.ElapsedFrameCount == 1 || DFKeyboard.Enter.ElapsedTime > 0.5f && DFKeyboard.Enter.ElapsedFrameCount % 3 == 0) buf.Append('\n');

			if (DFKeyboard.HasChar()) buf.Append(DFKeyboard.GetString());

			if (DFKeyboard.Escape.IsKeyUp)
				router.ChangeScene<LauncherScene>();
		}

		private readonly StringBuilder buf = new StringBuilder();
		private readonly TextDrawable editorView = new TextDrawable("", Font.GetDefault(16), Color.White)
		{
			Location = new Vector(8, 64),
		};
	}
}
