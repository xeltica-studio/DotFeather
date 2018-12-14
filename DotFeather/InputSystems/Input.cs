using OpenTK;

namespace DotFeather.InputSystems
{
	public static class Input
	{
		/// <summary>
		/// キーボードの値を読み取ります。
		/// </summary>
		public static DFKeyboard Keyboard { get; } = new DFKeyboard();

		/// <summary>
		/// マウスの値を読み取ります。
		/// </summary>
		/// <value>The mouse.</value>
		public static DFMouse Mouse { get; } = new DFMouse();
	}

}
