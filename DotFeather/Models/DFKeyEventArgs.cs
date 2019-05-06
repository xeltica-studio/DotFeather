using System;

namespace DotFeather
{
    /// <summary>
    /// キーボードイベントの引数です。
    /// </summary>
    public class DFKeyEventArgs : EventArgs
	{
		/// <summary>
		/// 押されたキーを取得します。
		/// </summary>
		/// <value>押されたキー。</value>
		public DFKeyCode Key { get; }

		/// <summary>
		/// Alt キーが押されたかどうかを示す値を取得します。
		/// </summary>
		/// <value>Alt キーが押された場合は <c>true</c>。それ以外の場合は <c>false</c>。</value>
		public bool AltPressed { get; }

        /// <summary>
        /// Ctrl キーが押されたかどうかを示す値を取得します。
        /// </summary>
        /// <value>Ctrl キーが押された場合は <c>true</c>。それ以外の場合は <c>false</c>。</value>
        public bool CtrlPressed { get; }

        /// <summary>
        /// Shift キーが押されたかどうかを示す値を取得します。
        /// </summary>
        /// <value>Shift キーが押された場合は <c>true</c>。それ以外の場合は <c>false</c>。</value>
        public bool ShiftPressed { get; }

		internal DFKeyEventArgs(OpenTK.Input.KeyboardKeyEventArgs e)
		{
			Key = e.Key.ToDF();
			AltPressed = e.Alt;
			CtrlPressed = e.Control;
			ShiftPressed = e.Shift;
		}
	}
}
