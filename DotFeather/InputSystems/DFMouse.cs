using System;
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
		/// 左ボタンが押されているかどうかを示す値を取得または設定します。
		/// </summary>
		public bool IsLeft { get; private set; }

		/// <summary>
		/// 右ボタンが押されているかどうかを示す値を取得または設定します。
		/// </summary>
		public bool IsRight { get; private set; }

		/// <summary>
		/// 中ボタンが押されているかどうかを示す値を取得または設定します。
		/// </summary>
		public bool IsMiddle { get; private set; }

		/// <summary>
		/// 左ボタンがたった今押されたかどうかを示す値を取得または設定します。
		/// </summary>
		public bool IsLeftDown { get; private set; }

		/// <summary>
		/// 右ボタンがたった今押されたかどうかを示す値を取得または設定します。
		/// </summary>
		public bool IsRightDown { get; private set; }

		/// <summary>
		/// 中ボタンがたった今押されたかどうかを示す値を取得または設定します。
		/// </summary>
		public bool IsMiddleDown { get; private set; }

		/// <summary>
		/// 左ボタンがたった今離されたかどうかを示す値を取得または設定します。
		/// </summary>
		public bool IsLeftUp { get; private set; }

		/// <summary>
		/// 右ボタンがたった今離されたかどうかを示す値を取得または設定します。
		/// </summary>
		public bool IsRightUp { get; private set; }

		/// <summary>
		/// 中ボタンがたった今離されたかどうかを示す値を取得または設定します。
		/// </summary>
		public bool IsMiddleUp { get; private set; }

		#pragma warning disable CS1591 // Exceptionally, Obsolete APIs don't have to have XML comments

		[Obsolete("Use IsLeft instead.")]
		public bool IsLeftClicked => IsLeft;

		[Obsolete("Use IsRight instead.")]
		public bool IsRightClicked => IsRight;

		[Obsolete("Use IsMiddle instead.")]
		public bool IsMiddleClicked => IsMiddle;

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

		internal void Update()
		{
			// previous values
			bool pl = IsLeft, pr = IsRight, pm = IsMiddle;

			IsLeft = Mouse.GetState().LeftButton == ButtonState.Pressed;
			IsRight = Mouse.GetState().RightButton == ButtonState.Pressed;
			IsMiddle = Mouse.GetState().MiddleButton == ButtonState.Pressed;

			IsLeftDown = IsLeft && !pl;
			IsRightDown = IsRight && !pr;
			IsMiddleDown = IsMiddle && !pm;
			
			IsLeftUp = !IsLeft && pl;
			IsRightUp = !IsRight && pr;
			IsMiddleUp = !IsMiddle && pm;
		}
	}
}
