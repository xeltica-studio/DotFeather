#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較
using System;
using DotFeather.Models;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace DotFeather.Helpers
{
	public static class TextureDrawer
	{
		public static void Draw(GameBase game, Texture2D texture, Vector location, Vector scale, float angle, System.Drawing.Color? color = null)
		{
			var hw = game.Width / 2;
			var hh = game.Height / 2;

			// Culling
			var left = location.X;
			var top = location.Y;
			var right = left + texture.Size.Width;
			var bottom = top + texture.Size.Height;

			if (left > game.Width || top > game.Height ||
				right < 0 || bottom < 0)
			{
				return;
			}

			var verts = new[]
			{
				(location.X, location.Y)
					.ToViewportPoint(hw, hh),
				((location.X + texture.Size.Width) * scale.X, location.Y)
					.ToViewportPoint(hw, hh),
				(location.X, (location.Y + texture.Size.Height) * scale.Y)
					.ToViewportPoint(hw, hh),
				((location.X + texture.Size.Width) * scale.X, (location.Y + texture.Size.Height) * scale.Y)
					.ToViewportPoint(hw, hh)
			};


			GL.Enable(EnableCap.Texture2D);
			GL.BindTexture(TextureTarget.Texture2D, texture.Handle);
			GL.Enable(EnableCap.AlphaTest);
			GL.AlphaFunc(AlphaFunction.Notequal, 0);

			if (angle != 0)
			{
				GL.Rotate(angle, Vector3d.UnitZ);
			}

			using (new GLContext(PrimitiveType.Quads))
			{
				GL.Rotate(180, new Vector3d(0, 0, 1));
				Vertex(1, 1, verts[3], color);
				Vertex(0, 1, verts[2], color);
				Vertex(0, 0, verts[0], color);
				Vertex(1, 0, verts[1], color);
			}
		}

		static void Vertex(double tcx, double tcy, (float x, float y) vx, System.Drawing.Color? color)
		{
			var col = color is System.Drawing.Color c ? c.ToGL() : Color.White;

			GL.TexCoord2(tcx, tcy);
			GL.Color4(col);
			GL.Vertex2(vx.x, vx.y);
		}
	}
}
