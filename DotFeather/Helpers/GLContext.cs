using System;
using OpenTK.Graphics.OpenGL;
namespace DotFeather
{
	public sealed class GLContext : IDisposable
	{
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
