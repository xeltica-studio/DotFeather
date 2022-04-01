

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
		public static bool IsLeft { get; private set; }

		/// <summary>
		/// Get or set whether right button pressed.
		/// </summary>
		public static bool IsRight { get; private set; }

		/// <summary>
		/// Get or set whether middle button pressed.
		/// </summary>
		public static bool IsMiddle { get; private set; }

		/// <summary>
		/// Get or set whether left button pressed down.
		/// </summary>
		public static bool IsLeftDown { get; private set; }

		/// <summary>
		/// Get or set whether right button pressed down.
		/// </summary>
		public static bool IsRightDown { get; private set; }

		/// <summary>
		/// Get or set whether middle button pressed down.
		/// </summary>
		public static bool IsMiddleDown { get; private set; }

		/// <summary>
		/// Get or set whether left button released up.
		/// </summary>
		public static bool IsLeftUp { get; private set; }

		/// <summary>
		/// Get or set whether right button released up.
		/// </summary>
		public static bool IsRightUp { get; private set; }

		/// <summary>
		/// Get or set whether middle button released up.
		/// </summary>
		public static bool IsMiddleUp { get; private set; }

		/// <summary>
		/// Get mouse wheel scroll amount.
		/// </summary>
		/// <value></value>
		public static Vector Scroll { get; private set; }

		internal static void Update(bool left, bool right, bool middle, Vector scroll)
		{
			// previous values
			bool pl = IsLeft, pr = IsRight, pm = IsMiddle;

			IsLeft = left;
			IsRight = right;
			IsMiddle = middle;

			IsLeftDown = IsLeft && !pl;
			IsRightDown = IsRight && !pr;
			IsMiddleDown = IsMiddle && !pm;

			if (IsLeftDown) System.Console.WriteLine("mouse left");
			if (IsRightDown) System.Console.WriteLine("mouse right");
			if (IsMiddleDown) System.Console.WriteLine("mouse middle");

			IsLeftUp = !IsLeft && pl;
			IsRightUp = !IsRight && pr;
			IsMiddleUp = !IsMiddle && pm;

			Scroll = scroll - prevScroll;
			prevScroll = scroll;
		}

		private static Vector prevScroll;
	}
}
