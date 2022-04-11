

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
		public static bool IsLeft { get; internal set; }

		/// <summary>
		/// Get or set whether right button pressed.
		/// </summary>
		public static bool IsRight { get; internal set; }

		/// <summary>
		/// Get or set whether middle button pressed.
		/// </summary>
		public static bool IsMiddle { get; internal set; }

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
	}
}
