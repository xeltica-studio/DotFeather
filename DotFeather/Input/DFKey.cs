using OpenTK.Input;

namespace DotFeather
{
	/// <summary>
	/// DotFeather APIにおいて、キーボードのキーを表します。ユーザーがインスタンスを初期化するものではありません。
	/// </summary>
	public struct DFKey
	{
		private readonly Key source;
		internal DFKey(Key key)
		{
			source = key;
		}

		/// <summary>
		/// キーが押されているかどうかを取得します。
		/// </summary>
		/// <value><c>true</c> であれば押されています。<c>false</c> であれば押されていません。</value>
		public bool IsPressed => Keyboard.GetState()[source];
	}

}
