using System;
using System.Drawing;

namespace DotFeather
{
	/// <summary>
	/// テクスチャのハンドルを持ちます。
	/// </summary>
	public struct Texture2D
	{
		public int Handle { get; }

		public Size Size { get; }

		internal Texture2D(int handle, Size size)
		{
			Handle = handle;
			Size = size;
		}
	}
}
