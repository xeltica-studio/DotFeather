using OpenTK.Input;
using OpenTK.Windowing.Common.Input;
using OpenTK.Windowing.GraphicsLibraryFramework;

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

		internal static void Update(Vector scroll)
		{
			var game = GameBase.Current?.window;
			if (game == null) return;

			IsLeft = game.IsMouseButtonDown(MouseButton.Left);
			IsRight = game.IsMouseButtonDown(MouseButton.Right);
			IsMiddle = game.IsMouseButtonDown(MouseButton.Middle);

			IsLeftDown = game.IsMouseButtonPressed(MouseButton.Left);
			IsRightDown = game.IsMouseButtonPressed(MouseButton.Right);
			IsMiddleDown = game.IsMouseButtonPressed(MouseButton.Middle);

			IsLeftUp = game.IsMouseButtonReleased(MouseButton.Left);
			IsRightUp = game.IsMouseButtonReleased(MouseButton.Right);
			IsMiddleUp = game.IsMouseButtonReleased(MouseButton.Middle);

			Scroll = scroll - prevScroll;
			prevScroll = scroll;
		}

		private static Vector prevScroll;
	}
}
