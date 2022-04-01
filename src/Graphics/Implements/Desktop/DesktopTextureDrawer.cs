#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較
using System;
using System.Drawing;
using Silk.NET.OpenGL;

namespace DotFeather.Internal
{
	/// <summary>
	/// <see cref="Texture2D"/> オブジェクトをバッファ上に描画する機能を提供します。
	/// </summary>
	internal class DesktopTextureDrawer : ITextureDrawer
	{
        private static readonly string VertexShaderSource = @"
			#version 330 core //Using version GLSL version 3.3
			layout (location = 0) in vec4 vPos;

			void main()
			{
				gl_Position = vec4(vPos.x, vPos.y, vPos.z, 1.0);
			}
        ";

        private static readonly string FragmentShaderSource = @"
			#version 330 core
			out vec4 FragColor;
			void main()
			{
				FragColor = vec4(1.0f, 1.0f, 1.0f, 1.0f);
			}
        ";

		/// <summary>
		/// テクスチャを描画します。
		/// </summary>
		public unsafe void Draw(Texture2D texture, Vector location, Vector scale, Color? color = null, float? width = null, float? height = null, float angle = 0)
		{
			location = location.ToDeviceCoord();
			scale = scale.ToDeviceCoord();

			var w = width ?? texture.Size.X;
			var h = height ?? texture.Size.Y;

			w *= scale.X;
			h *= scale.Y;

			var (left, top) = location;
			var right = left + w;
			var bottom = top + h;

			if (left > DF.Window.ActualWidth || top > DF.Window.ActualHeight || right < 0 || bottom < 0)
				return;

			var hw = DF.Window.ActualWidth / 2;
			var hh = DF.Window.ActualHeight / 2;
			Debug.Info(texture.Size.ToString());

			var (x0, y0) = (right, top).ToViewportPoint(hw, hh);
			var (x1, y1) = (right, bottom).ToViewportPoint(hw, hh);
			var (x2, y2) = (left, bottom).ToViewportPoint(hw, hh);
			var (x3, y3) = (left, top).ToViewportPoint(hw, hh);

			// TODO 無駄が多いのでキャッシュする

			// --- VAO ---
			var vao = gl.GenVertexArray();
			gl.BindVertexArray(vao);

			// --- VBO ---
			var vbo = gl.GenBuffer();
			gl.BindBuffer(GLEnum.ArrayBuffer, vbo);
            var vertices = stackalloc float[]
			{
				x0, y0, 0,
				x1, y1, 0,
				x2, y2, 0,
				x3, y3, 0,
			};
			uint verticesSize = 3 * 4;
			gl.BufferData(GLEnum.ArrayBuffer, verticesSize * sizeof(float), vertices, GLEnum.StaticDraw);

			// --- EBO ---
			var ebo = gl.GenBuffer();
			gl.BindBuffer(GLEnum.ElementArrayBuffer, ebo);
			var indices = stackalloc uint[]
			{
				0, 1, 3,
				1, 2, 3,
			};
			uint indicesSize = 3 * 2;
			gl.BufferData(GLEnum.ElementArrayBuffer, indicesSize * sizeof(uint), indices, GLEnum.StaticDraw);

			// --- EBI ---
			var ebi = "えび";

			// --- 頂点シェーダー ---
			var vsh = gl.CreateShader(GLEnum.VertexShader);
			gl.ShaderSource(vsh, VertexShaderSource);
			gl.CompileShader(vsh);

			// --- フラグメントシェーダー ---
            var fsh = gl.CreateShader(GLEnum.FragmentShader);
			gl.ShaderSource(fsh, FragmentShaderSource);
			gl.CompileShader(fsh);

			// --- シェーダーを紐付ける ---
			var program = gl.CreateProgram();
			gl.AttachShader(program, vsh);
			gl.AttachShader(program, fsh);
			gl.LinkProgram(program);

			// --- 不要なデータを開放 ---
			gl.DetachShader(program, vsh);
			gl.DetachShader(program, fsh);
			gl.DeleteShader(vsh);
			gl.DeleteShader(fsh);
			gl.VertexAttribPointer(0, 3, GLEnum.Float, false, 3 * sizeof(float), null);
			gl.EnableVertexAttribArray(0);

			// --- レンダリング ---
			gl.BindVertexArray(vao);
			gl.UseProgram(program);
			gl.DrawElements(GLEnum.Triangles, indicesSize, GLEnum.UnsignedInt, null);

			gl.DeleteBuffer(vbo);
			gl.DeleteBuffer(ebo);
			gl.DeleteVertexArray(vao);
			gl.DeleteProgram(program);

			Debug.FixMe("DesktopTextureDrawer.Draw", "Missing Texture");
		}

		public unsafe int GenerateTexture(byte[] bmp, int width, int height)
		{
			fixed (byte* b = bmp)
			{
				var texture = gl.GenTexture();
				gl.BindTexture(GLEnum.Texture2D, texture);

				gl.TexParameter(GLEnum.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
				gl.TexParameter(GLEnum.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
				gl.TexImage2D(GLEnum.Texture2D, 0, (int)GLEnum.Rgba, (uint)width, (uint)height, 0, GLEnum.Rgba, GLEnum.UnsignedByte, b);
				return (int)texture;
			}
		}

		private static GL gl => (DF.Window as DesktopWindow)!.gl;
	}
}
