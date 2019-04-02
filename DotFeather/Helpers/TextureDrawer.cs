#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較
using DotFeather.Models;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace DotFeather.Helpers
{
	internal static class TextureDrawer
	{
		internal static void Draw(Texture2D texture, Vector location, Vector scale, float angle)
		{
			var verts = new []
			{
				(location.X, location.Y),
				(location.X + texture.Size.Width, location.Y),
				(location.X * scale.X, (location.Y + texture.Size.Height) * scale.Y),
				((location.X + texture.Size.Width) * scale.X, (location.Y + texture.Size.Height) * scale.Y)
			};

			GL.Enable(EnableCap.Texture2D);
			GL.BindTexture(TextureTarget.Texture2D, texture.Handle);

			if (angle != 0)
			{
				GL.Rotate(angle, Vector3d.UnitZ);
			}

			using (new GLContext(PrimitiveType.Quads))
			{
				GL.Rotate(180, new Vector3d(0, 0, 1));
				Vertex(1, 1, verts[3]);
				Vertex(0, 1, verts[2]);
				Vertex(0, 0, verts[0]);
				Vertex(1, 0, verts[1]);
			}
		}

		static void Vertex(double tcx, double tcy, (float x, float y) vx)
		{
			GL.TexCoord2(tcx, tcy);
			GL.Color4(Color.White);
			GL.Vertex2(vx.x, vx.y);
		}
	}
}
