using OpenTK.Input;

namespace DotFeather.InputSystems
{
	/// <summary>
	/// キーボードのキーを表します。
	/// </summary>
	public struct DFKey
	{
		internal DFKey(Key key)
		{
			source = key;
		}

		/// <summary>
		/// キーが押されているかどうかを取得します。
		/// </summary>
		/// <value><c>true</c> であれば押されています。<c>false</c> であれば押されていません。</value>
		public bool IsPressed => Keyboard.GetState()[source];

        private readonly Key source;
    }

}
