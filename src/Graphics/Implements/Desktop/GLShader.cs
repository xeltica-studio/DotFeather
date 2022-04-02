using System;
using System.IO;
using DotFeather;
using Silk.NET.OpenGL;

namespace DotFeather.Internal
{
	/// <summary>
	/// シェーダーのカプセル化オブジェクト。
	/// https://github.com/dotnet/Silk.NET/tree/main/examples/CSharp/OpenGL%20Tutorials/Tutorial%201.3%20-%20Abstractions
	/// </summary>
    class GLShader : IDisposable
    {
        public GLShader(string vertexShader, string fragmentShader)
        {
            uint vertex = LoadShader(ShaderType.VertexShader, vertexShader);
            uint fragment = LoadShader(ShaderType.FragmentShader, fragmentShader);

            _handle = DF.GL.CreateProgram();

            DF.GL.AttachShader(_handle, vertex);
            DF.GL.AttachShader(_handle, fragment);
            DF.GL.LinkProgram(_handle);

            DF.GL.DetachShader(_handle, vertex);
            DF.GL.DetachShader(_handle, fragment);
            DF.GL.DeleteShader(vertex);
            DF.GL.DeleteShader(fragment);
        }

        public void Use()
        {
            DF.GL.UseProgram(_handle);
        }

        public void SetUniform(string name, int value)
        {
            int location = DF.GL.GetUniformLocation(_handle, name);
            if (location == -1)
            {
                throw new Exception($"{name} uniform not found on shader.");
            }
            DF.GL.Uniform1(location, value);
        }

        public void SetUniform(string name, float value)
        {
            int location = DF.GL.GetUniformLocation(_handle, name);
            if (location == -1)
            {
                throw new Exception($"{name} uniform not found on shader.");
            }
            DF.GL.Uniform1(location, value);
        }

        public void Dispose()
        {
            DF.GL.DeleteProgram(_handle);
        }

        private static uint LoadShader(ShaderType type, string path)
        {
            string src = File.ReadAllText(path);
            uint handle = DF.GL.CreateShader(type);
            DF.GL.ShaderSource(handle, src);
            DF.GL.CompileShader(handle);
            string infoLog = DF.GL.GetShaderInfoLog(handle);
            if (!string.IsNullOrWhiteSpace(infoLog))
            {
                throw new Exception($"Error compiling shader of type {type}, failed with error {infoLog}");
            }

            return handle;
        }

        private readonly uint _handle;
    }
}
