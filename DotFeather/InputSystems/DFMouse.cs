using System.Drawing;
using OpenTK.Input;


namespace DotFeather
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

		/// <summary>
		/// 左クリックされているかどうかを示す値を取得または設定します。
		/// </summary>
		/// <returns>左クリックされている場合は <c>true</c>。それ以外の場合は <c>false</c>。</returns>
		public bool IsLeftClicked => Mouse.GetState().LeftButton == ButtonState.Pressed;

		/// <summary>
		/// 右クリックされているかどうかを示す値を取得または設定します。
		/// </summary>
		/// <returns>右クリックされている場合は <c>true</c>。それ以外の場合は <c>false</c>。</returns>
		public bool IsRightClicked => Mouse.GetState().RightButton == ButtonState.Pressed;

		/// <summary>
		/// 中クリックされているかどうかを示す値を取得または設定します。
		/// </summary>
		/// <returns>中クリックされている場合は <c>true</c>。それ以外の場合は <c>false</c>。</returns>
		public bool IsMiddleClicked => Mouse.GetState().MiddleButton == ButtonState.Pressed;

		/// <summary>
		/// マウスホイールのスクロール量を取得します。
		/// </summary>
		/// <value></value>
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
