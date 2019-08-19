
namespace DotFeather
{
	/// <summary>
	/// ユーザーからのインプットを受け付ける静的クラスです。
	/// </summary>
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
