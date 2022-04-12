

using System;
using Silk.NET.Input;

namespace DotFeather
{
	/// <summary>
	/// This class gets the mouse cursor position, mouse button status, etc. This class can not be inherited.
	/// </summary>
	public static class DFMouse
	{
		/// <summary>
		/// Get mouse cursor coordinates.
		/// </summary>
		/// <value>The position.</value>
		public static VectorInt Position { get; internal set; }

		/// <summary>
		/// Get or set whether left button pressed.
		/// </summary>
		public static bool IsLeft => DF.InputContext.Mice[0].IsButtonPressed(MouseButton.Left);

		/// <summary>
		/// Get or set whether right button pressed.
		/// </summary>
		public static bool IsRight => DF.InputContext.Mice[0].IsButtonPressed(MouseButton.Left);

		/// <summary>
		/// Get or set whether middle button pressed.
		/// </summary>
		public static bool IsMiddle => DF.InputContext.Mice[0].IsButtonPressed(MouseButton.Left);

		/// <summary>
		/// Get or set whether left button pressed down.
		/// </summary>
		public static bool IsLeftDown { get; internal set; }

		/// <summary>
		/// Get or set whether right button pressed down.
		/// </summary>
		public static bool IsRightDown { get; internal set; }

		/// <summary>
		/// Get or set whether middle button pressed down.
		/// </summary>
		public static bool IsMiddleDown { get; internal set; }

		/// <summary>
		/// Get or set whether left button released up.
		/// </summary>
		public static bool IsLeftUp { get; internal set; }

		/// <summary>
		/// Get or set whether right button released up.
		/// </summary>
		public static bool IsRightUp { get; internal set; }

		/// <summary>
		/// Get or set whether middle button released up.
		/// </summary>
		public static bool IsMiddleUp { get; internal set; }

		/// <summary>
		/// Get mouse wheel scroll amount.
		/// </summary>
		/// <value></value>
		public static Vector Scroll { get; internal set; }

		internal static void Init(IMouse mouse)
		{
			mouse.Click += (_, btn, pos) => {
				Click?.Invoke(new DFMouseClickEventArgs(GetButtonId(btn), (VectorInt)Vector.From(pos)));
			};
			mouse.DoubleClick += (_, btn, pos) => {
				DoubleClick?.Invoke(new DFMouseClickEventArgs(GetButtonId(btn), (VectorInt)Vector.From(pos)));
			};
			mouse.MouseDown += (_, btn) =>
			{
				switch (btn)
				{
					case MouseButton.Left:
						IsLeftDown = true;
						break;
					case MouseButton.Right:
						IsRightDown = true;
						break;
					case MouseButton.Middle:
						IsMiddleDown = true;
						break;
				}
				ButtonDown?.Invoke(new DFMouseClickEventArgs(GetButtonId(btn), VectorInt.From(mouse.Position)));
			};
			mouse.MouseUp += (_, btn) =>
			{
				switch (btn)
				{
					case MouseButton.Left:
						IsLeftUp = true;
						break;
					case MouseButton.Right:
						IsRightUp = true;
						break;
					case MouseButton.Middle:
						IsMiddleUp = true;
						break;
				}
				ButtonUp?.Invoke(new DFMouseClickEventArgs(GetButtonId(btn), VectorInt.From(mouse.Position)));
			};
			mouse.MouseMove += (_, pos) => {
				Move?.Invoke(new DFMouseEventArgs((VectorInt)Vector.From(pos)));

				if (0 <= pos.X && 0 <= pos.Y && pos.X <= DF.Window.Width && pos.Y <= DF.Window.Height)
				{
					// 画面内
					if (!IsEnter) Enter?.Invoke();
					IsEnter = true;
				}
				else
				{
					// 画面外
					if (IsEnter) Leave?.Invoke();
					IsEnter = false;
				}
			};
		}

		private static int GetButtonId(MouseButton button) => button switch
		{
			MouseButton.Middle => 1,
			MouseButton.Right => 2,
			_ => (int)button,
		};

		private static bool IsEnter = false;

		public static event Action<DFMouseClickEventArgs>? Click;
		public static event Action<DFMouseClickEventArgs>? DoubleClick;
		public static event Action<DFMouseClickEventArgs>? ButtonUp;
		public static event Action<DFMouseClickEventArgs>? ButtonDown;
		public static event Action<DFMouseEventArgs>? Move;
		public static event Action? Enter;
		public static event Action? Leave;
	}
}
