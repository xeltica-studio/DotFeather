using System;
using System.Drawing;

namespace DotFeather.Models
{
	/// <summary>
	/// テクスチャのハンドルを持ちます。
	/// </summary>
	public struct Texture2D
	{
        /// <summary>
        /// このテクスチャの OpenGL ハンドルを取得します。
        /// </summary>
		public int Handle { get; }

        /// <summary>
        /// このテクスチャのサイズを取得します。
        /// </summary>
		public Size Size { get; }

		internal Texture2D(int handle, Size size)
		{
			Handle = handle;
			Size = size;
		}
	}
}
