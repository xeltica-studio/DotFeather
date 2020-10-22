#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較
using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace DotFeather
{
	/// <summary>
	/// <see cref="Texture2D"/> オブジェクトをバッファ上に描画する機能を提供します。
	/// </summary>
	public static class TextureDrawer
	{
		/// <summary>
		/// テクスチャを描画します。
		/// </summary>
		public static void Draw(GameBase game, Texture2D texture, Vector location, Vector scale, float angle, Color? color = null, float? width = null, float? height = null)
		{
			var w = width ?? texture.Size.X;
			var h = height ?? texture.Size.Y;

			w *= scale.X;
			h *= scale.Y;

			var (left, top) = location;
			var right = left + w;
			var bottom = top + h;

			if (left > game.ActualWidth || top > game.ActualHeight || right < 0 || bottom < 0)
				return;

			var hw = game.ActualWidth / 2;
			var hh = game.ActualHeight / 2;

			var v0 = (left, top).ToViewportPoint(hw, hh);
			var v1 = (right, top).ToViewportPoint(hw, hh);
			var v2 = (left, bottom).ToViewportPoint(hw, hh);
			var v3 = (right, bottom).ToViewportPoint(hw, hh);

			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
			GL.BlendEquation(BlendEquationMode.FuncAdd);
			GL.Enable(EnableCap.Texture2D);
			GL.BindTexture(TextureTarget.Texture2D, texture.Handle);

			using (new GLContext(PrimitiveType.Quads))
			{
				Vertex(1, 1, v3, color);
				Vertex(0, 1, v2, color);
				Vertex(0, 0, v0, color);
				Vertex(1, 0, v1, color);
			}

			GL.Disable(EnableCap.Texture2D);
			GL.Disable(EnableCap.Blend);
		}

		private static void Vertex(double tcx, double tcy, (float x, float y) vx, Color? color)
		{
			var col = color ?? Color.White;

			GL.TexCoord2(tcx, tcy);
			GL.Color4(col.R, col.G, col.B, col.A);
			GL.Vertex2(vx.x, vx.y);
		}
	}
}
