using System;
using System.Drawing;
using System.Numerics;
using Silk.NET.OpenGL;

namespace DotFeather.Internal
{
	internal class DesktopPrimitiveDrawer : IPrimitiveDrawer
	{
        private static readonly string VertexShaderSource = @"
			#version 330 core
			layout (location = 0) in vec2 vPos;

			void main()
			{
				gl_Position = vec4(vPos.x, vPos.y, 0.0, 1.0);
			}
        ";

        private static readonly string FragmentShaderSource = @"
			#version 330 core
			uniform vec4 uTintColor;

			out vec4 FragColor;

			void main()
			{
				FragColor = uTintColor;
			}
        ";

		public DesktopPrimitiveDrawer()
		{
			DF.Window.Start += () => {
				// --- 頂点シェーダー ---
				var vsh = gl.CreateShader(GLEnum.VertexShader);
				gl.ShaderSource(vsh, VertexShaderSource);
				gl.CompileShader(vsh);

				// --- フラグメントシェーダー ---
				var fsh = gl.CreateShader(GLEnum.FragmentShader);
				gl.ShaderSource(fsh, FragmentShaderSource);
				gl.CompileShader(fsh);

				// --- シェーダーを紐付ける ---
				shader = gl.CreateProgram();
				gl.AttachShader(shader, vsh);
				gl.AttachShader(shader, fsh);
				gl.LinkProgram(shader);
				gl.DetachShader(shader, vsh);
				gl.DetachShader(shader, fsh);

				gl.DeleteShader(vsh);
				gl.DeleteShader(fsh);
			};
		}

		public unsafe void Draw(Vector originLocation, Vector originScale, VectorInt[] vertices, ShapeType type, Color color, int lineWidth = 0, Color? lineColor = null)
		{
			if (vertices.Length == 0)
				return;

			var hw = DF.Window.ActualWidth / 2;
			var hh = DF.Window.ActualHeight / 2;

			DF.GL.Enable(EnableCap.Blend);
			DF.GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

			var v = stackalloc float[vertices.Length * 2];

			for (int i = 0; i < vertices.Length; i++)
			{
				var dest = originLocation + vertices[i] * originScale;
				var (x, y) = dest.ToDeviceCoord().ToViewportPoint(hw, hh);
				v[i * 2 + 0] = x;
				v[i * 2 + 1] = y;
			}

			if (color.A > 0)
			{
				if (type == ShapeType.Line) DF.GL.LineWidth(lineWidth);

				// --- VAO ---
				var vao = gl.GenVertexArray();
				gl.BindVertexArray(vao);

				// --- VBO ---
				var vbo = gl.GenBuffer();
				gl.BindBuffer(GLEnum.ArrayBuffer, vbo);
				gl.BufferData(GLEnum.ArrayBuffer, (uint)vertices.Length * 2 * sizeof(float), v, GLEnum.StaticDraw);

				// --- レンダリング ---
				gl.UseProgram(shader);

				gl.VertexAttribPointer(0, 2, GLEnum.Float, false, 2 * sizeof(float), (void*)(0 * sizeof(float)));
				gl.EnableVertexAttribArray(0);
				var uTintColor = gl.GetUniformLocation(shader, "uTintColor");
				gl.Uniform4(uTintColor, new Vector4(color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f));

				if (type == ShapeType.Rect)
				{
					// --- EBO ---
					var ebo = gl.GenBuffer();
					gl.BindBuffer(GLEnum.ElementArrayBuffer, ebo);
					var indices = stackalloc uint[]
					{
						0, 1, 2,
						0, 2, 3,
					};
					uint indicesSize = 3 * 2;
					gl.BufferData(GLEnum.ElementArrayBuffer, indicesSize * sizeof(uint), indices, GLEnum.StaticDraw);
					gl.DrawElements(GLEnum.Triangles, indicesSize, GLEnum.UnsignedInt, null);

					gl.DeleteBuffer(ebo);
				}
				else
				{
					gl.DrawArrays(ToGLType(type), 0, (uint)vertices.Length);
				}

				// --- 不要なデータを開放 ---
				gl.DeleteBuffer(vbo);
				gl.DeleteVertexArray(vao);

			}

			if (lineWidth > 0 && lineColor is Color lc)
			{
				DF.GL.LineWidth(lineWidth);

				// --- VAO ---
				var vao = gl.GenVertexArray();
				gl.BindVertexArray(vao);

				// --- VBO ---
				var vbo = gl.GenBuffer();
				gl.BindBuffer(GLEnum.ArrayBuffer, vbo);
				gl.BufferData(GLEnum.ArrayBuffer, (uint)vertices.Length * 2 * sizeof(float), v, GLEnum.StaticDraw);

				// --- レンダリング ---
				gl.UseProgram(shader);

				gl.VertexAttribPointer(0, 2, GLEnum.Float, false, 2 * sizeof(float), (void*)(0 * sizeof(float)));
				gl.EnableVertexAttribArray(0);
				var uTintColor = gl.GetUniformLocation(shader, "uTintColor");
				gl.Uniform4(uTintColor, new Vector4(lc.R / 255f, lc.G / 255f, lc.B / 255f, lc.A / 255f));

				gl.DrawArrays(PrimitiveType.LineLoop, 0, (uint)vertices.Length);

				// --- 不要なデータを開放 ---
				gl.DeleteBuffer(vbo);
				gl.DeleteVertexArray(vao);
			}

			DF.GL.Disable(EnableCap.Blend);
		}

		private static PrimitiveType ToGLType(ShapeType type)
		{
			return type switch
			{
				ShapeType.Pixel => PrimitiveType.Points,
				ShapeType.Line => PrimitiveType.Lines,
				ShapeType.Rect => PrimitiveType.TriangleStrip,
				ShapeType.Triangle => PrimitiveType.Triangles,
				ShapeType.Polygon => PrimitiveType.TriangleStrip,
				_ => throw new ArgumentException(null, nameof(type)),
			};
		}
		private static GL gl => DF.GL;

		private uint shader;
	}
}
