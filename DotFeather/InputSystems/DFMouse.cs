using System.Drawing;
using OpenTK.Input;


namespace DotFeather.InputSystems
{
	/// <summary>
	/// マウス カーソルの位置、マウスボタンの状態などを取得するクラスです。このクラスは継承できません。
	/// </summary>
	public sealed class DFMouse
	{
		/// <summary>
		/// マウスカーソルの座標を取得します。
		/// </summary>
		/// <value>The position.</value>
		public Point Position { get; internal set; }

		public bool IsLeftClicked => Mouse.GetState().LeftButton == ButtonState.Pressed;
		public bool IsRightClicked => Mouse.GetState().RightButton == ButtonState.Pressed;
		public bool IsMiddleClicked => Mouse.GetState().MiddleButton == ButtonState.Pressed;

		public (float x, float y) Scroll
		{
			get
			{
				var s = Mouse.GetState().Scroll;
				return (s.X, s.Y);
			}
		}
	}
}