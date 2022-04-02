using System;
using Silk.NET.OpenGL;

namespace DotFeather.Internal
{
	/// <summary>
	/// BO のカプセル化オブジェクト。
	/// https://github.com/dotnet/Silk.NET/tree/main/examples/CSharp/OpenGL%20Tutorials/Tutorial%201.3%20-%20Abstractions
	/// </summary>
	/// <typeparam name="T">バッファの型。</typeparam>
    public class GLBufferObject<T> : IDisposable where T : unmanaged
    {
        public unsafe GLBufferObject(Span<T> data, BufferTargetARB bufferType)
        {
            this.bufferType = bufferType;

            handle = DF.GL.GenBuffer();
            Bind();
            fixed (void* d = data)
            {
                DF.GL.BufferData(bufferType, (nuint) (data.Length * sizeof(T)), d, BufferUsageARB.StaticDraw);
            }
        }

        public void Bind()
        {
            DF.GL.BindBuffer(bufferType, handle);
        }

        public void Dispose()
        {
            DF.GL.DeleteBuffer(handle);
        }

        private readonly uint handle;
        private readonly BufferTargetARB bufferType;
    }
}
