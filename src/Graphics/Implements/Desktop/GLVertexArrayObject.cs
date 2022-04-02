using System;
using Silk.NET.OpenGL;

namespace DotFeather.Internal
{
	/// <summary>
	/// VAO のカプセル化オブジェクト。
	/// https://github.com/dotnet/Silk.NET/tree/main/examples/CSharp/OpenGL%20Tutorials/Tutorial%201.3%20-%20Abstractions
	/// </summary>
	/// <typeparam name="TVertex">頂点の型</typeparam>
	/// <typeparam name="TIndex">インデックスの型</typeparam>
	class GLVertexArrayObject<TVertex, TIndex> : IDisposable
        where TVertex : unmanaged
        where TIndex : unmanaged
    {
        public GLVertexArrayObject(GLBufferObject<TVertex> vbo, GLBufferObject<TIndex> ebo)
        {
            //Setting out handle and binding the VBO and EBO to this VAO.
            _handle = DF.GL.GenVertexArray();
            Bind();
            vbo.Bind();
            ebo.Bind();
        }

        public static unsafe void VertexAttributePointer(uint index, int count, VertexAttribPointerType type, uint vertexSize, int offSet)
        {
            DF.GL.VertexAttribPointer(index, count, type, false, vertexSize * (uint)sizeof(TVertex), (void*) (offSet * sizeof(TVertex)));
            DF.GL.EnableVertexAttribArray(index);
        }

        public void Bind()
        {
            DF.GL.BindVertexArray(_handle);
        }

        public void Dispose()
        {
            DF.GL.DeleteVertexArray(_handle);
        }

        private readonly uint _handle;
    }
}
