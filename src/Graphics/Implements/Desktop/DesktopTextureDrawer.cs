﻿#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較
using System.Drawing;
using System.Numerics;
using Silk.NET.OpenGL;

namespace DotFeather.Internal
{
	/// <summary>
	/// <see cref="Texture2D"/> オブジェクトをバッファ上に描画する機能を提供します。
	/// </summary>
	internal class DesktopTextureDrawer : ITextureDrawer
	{
        private static readonly string VertexShaderSource = @"
			#version 330 core
			layout (location = 0) in vec2 vPos;
			layout (location = 1) in vec2 vUv;

			out vec2 fUv;

			void main()
			{
				gl_Position = vec4(vPos.x, vPos.y, 0.0, 1.0);
				fUv = vUv;
			}
        ";

        private static readonly string FragmentShaderSource = @"
			#version 330 core
			in vec2 fUv;

			uniform sampler2D uTexture0;
			uniform vec4 uTintColor;

			out vec4 FragColor;

			void main()
			{
				FragColor = texture(uTexture0, fUv) * uTintColor;
			}
        ";

		public DesktopTextureDrawer()
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

		/// <summary>
		/// テクスチャを描画します。
		/// </summary>
		public unsafe void Draw(Texture2D texture, Vector location, Vector scale, Color? color = null, float? width = null, float? height = null, float angle = 0)
		{
			if (texture.IsDestroyed)
			{
				LogHelper.Warn("This texture (Handle ID: " + texture.Handle + ") is destroyed");
				return;
			}
			location = location.ToDeviceCoord();
			scale = scale.ToDeviceCoord();

			var w = width ?? texture.Size.X;
			var h = height ?? texture.Size.Y;

			w *= scale.X;
			h *= scale.Y;

			var (left, top) = location;
			var right = left + w;
			var bottom = top + h;

			// カリング
			if (left > DF.Window.ActualWidth || top > DF.Window.ActualHeight || right < 0 || bottom < 0)
				return;

			var hw = DF.Window.ActualWidth / 2;
			var hh = DF.Window.ActualHeight / 2;

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
				x0, y0, 1f, 0f,
				x1, y1, 1f, 1f,
				x2, y2, 0f, 1f,
				x3, y3, 0f, 0f,
			};
			uint verticesSize = 4 * 4;
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

			// --- レンダリング ---
			gl.Enable(GLEnum.Blend);
			gl.BlendFunc(GLEnum.SrcAlpha, GLEnum.OneMinusSrcAlpha);
			gl.VertexAttribPointer(0, 2, GLEnum.Float, false, 4 * sizeof(float), (void*)(0 * sizeof(float)));
			gl.EnableVertexAttribArray(0);
			gl.VertexAttribPointer(1, 2, GLEnum.Float, false, 4 * sizeof(float), (void*)(2 * sizeof(float)));
			gl.EnableVertexAttribArray(1);
			gl.BindVertexArray(vao);

			gl.UseProgram(shader);
			gl.ActiveTexture(GLEnum.Texture0);
			gl.BindTexture(GLEnum.Texture2D, (uint)texture.Handle);
			var uTexture0 = gl.GetUniformLocation(shader, "uTexture0");
			gl.Uniform1(uTexture0, 0);
			var uTintColor = gl.GetUniformLocation(shader, "uTintColor");
			var c = color ?? Color.White;
			gl.Uniform4(uTintColor, new Vector4(c.R / 255f, c.G / 255f, c.B / 255f, c.A / 255f));
			gl.DrawElements(GLEnum.Triangles, indicesSize, GLEnum.UnsignedInt, null);

			// --- 不要なデータを開放 ---
			gl.DeleteBuffer(vbo);
			gl.DeleteBuffer(ebo);
			gl.DeleteVertexArray(vao);
		}

		public unsafe int GenerateTexture(byte[] bmp, int width, int height)
		{
			fixed (byte* b = bmp)
			{
				var texture = gl.GenTexture();
				gl.ActiveTexture(GLEnum.Texture0);
				gl.BindTexture(GLEnum.Texture2D, texture);

				gl.TexParameter(GLEnum.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
				gl.TexParameter(GLEnum.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
				gl.TexImage2D(GLEnum.Texture2D, 0, (int)GLEnum.Rgba, (uint)width, (uint)height, 0, GLEnum.Rgba, GLEnum.UnsignedByte, b);
				return (int)texture;
			}
		}

		private static GL gl => DF.GL;

		private uint shader;
	}
}
