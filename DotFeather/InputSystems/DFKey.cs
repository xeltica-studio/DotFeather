using OpenTK.Input;

namespace DotFeather
{
	/// <summary>
	/// キーボードのキーを表します。
	/// </summary>
	public class DFKey
	{
		internal DFKey() { }

        /// <summary>
        /// キーが押されているかどうかを示す値を取得します。
        /// </summary>
        /// <value><c>true</c> であれば押されています。<c>false</c> であれば押されていません。</value>
        public bool IsPressed { get; internal set; }

        /// <summary>
        /// キーがこのフレームで押されたかどうかを示す値を取得します。
        /// </summary>
        /// <returns><c>true</c> であればたった今押されました。<c>false</c> であればそうでありません。</returns>
        public bool IsKeyDown { get; internal set; }

        /// <summary>
        /// キーがこのフレームで離されたかどうかを示す値を取得します。
        /// </summary>
        /// <returns><c>true</c> であればたった今離されました。<c>false</c> であればそうでありません。</returns>
        public bool IsKeyUp { get; internal set; }

        /// <summary>
        /// キーが押されているかどうかを取得します。
        /// </summary>
        /// <value><c>true</c> であれば押されています。<c>false</c> であれば押されていません。</value>
        public static implicit operator bool(DFKey key) => key.IsPressed;
	}

}
