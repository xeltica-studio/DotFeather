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
		public static void Draw(GameBase game, Texture2D texture, Vector location, Vector scale, float angle, System.Drawing.Color? color = null, float? width = null, float? height = null)
		{
			var hw = game.Width / 2;
			var hh = game.Height / 2;

			var w = width ?? texture.Size.X;
			var h = height ?? texture.Size.Y;

			w *= scale.X;
			h *= scale.Y;

			var left = location.X;
			var top = location.Y;
			var right = left + w;
			var bottom = top + h;

			if (left > game.Width || top > game.Height || right < 0 || bottom < 0)
			{
				return;
			}

			var verts = new[]
			{
				(location.X, location.Y)
					.ToViewportPoint(hw, hh),
				(location.X + w, location.Y)
					.ToViewportPoint(hw, hh),
				(location.X, location.Y + h)
					.ToViewportPoint(hw, hh),
				(location.X + w, location.Y + h)
					.ToViewportPoint(hw, hh)
			};

			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
			GL.BlendEquation(BlendEquationMode.FuncAdd);
			GL.Enable(EnableCap.Texture2D);
			GL.BindTexture(TextureTarget.Texture2D, texture.Handle);

			using (new GLContext(PrimitiveType.Quads))
			{
				Vertex(1, 1, verts[3], color);
				Vertex(0, 1, verts[2], color);
				Vertex(0, 0, verts[0], color);
				Vertex(1, 0, verts[1], color);
			}

			GL.Disable(EnableCap.Texture2D);
			GL.Disable(EnableCap.Blend);
		}

		private static void Vertex(double tcx, double tcy, (float x, float y) vx, System.Drawing.Color? color)
		{
			var col = color ?? Color.White;

			GL.TexCoord2(tcx, tcy);
			GL.Color4(col.R, col.G, col.B, col.A);
			GL.Vertex2(vx.x, vx.y);
		}
	}
}
