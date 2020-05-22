using System;
using OpenToolkit.Graphics.OpenGL;
namespace DotFeather
{
	/// <summary>
	/// <see cref="GL.Begin(PrimitiveType)"/> および <see cref="GL.End()"/> を <c>using</c> 句で扱えるようにした構造体です。
	/// </summary>
	public struct GLContext : IDisposable
	{
		/// <summary>
		/// <see cref="GLContext"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="p"></param>
		public GLContext(PrimitiveType p)
		{
			GL.Begin(p);
			disposedValue = false;
		}

		/// <summary>
		/// コンテキストを解放します。
		/// </summary>
		public void Dispose()
		{
			if (!disposedValue)
			{
				GL.End();
				disposedValue = true;
			}
		}

		private bool disposedValue;
	}
}
