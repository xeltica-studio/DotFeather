using System;
using OpenTK.Graphics.OpenGL;
namespace DotFeather.Helpers
{
	/// <summary>
	/// <see cref="GL.Begin(PrimitiveType)"/> および <see cref="GL.End()"/> を <c>using</c> 句で扱えるようにしたクラスです。このクラスは継承できません。
	/// </summary>
	public sealed class GLContext : IDisposable
	{
		/// <summary>
		/// <see cref="GLContext"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="p"></param>
		public GLContext(PrimitiveType p)
		{
			GL.Begin(p);
		}
		#region IDisposable Support
		private bool disposedValue;

		void Dispose(bool _)
		{
			if (!disposedValue)
			{
				GL.End();
				disposedValue = true;
			}
		}

		~GLContext()
		{
			Dispose(false);
		}

		public void Dispose()
		{
			Dispose(true);
		}
		#endregion
	}
}
