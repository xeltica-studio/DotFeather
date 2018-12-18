#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較

using System;
using System.Linq;
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace DotFeather.Drawable
{
	/// <summary>
	/// テクスチャを描画します。
	/// </summary>
	public class TextureDrawable : IDrawable
	{
		public Texture2D Texture { get; }

		public Point Location { get; }

		public float Angle { get; }

		public Vector Scale { get; }

		public TextureDrawable(Texture2D texture, int x, int y, float angle = default, Vector scale = default)
		{
			Texture = texture;
			Location = new Point(x, y);
			Angle = angle;
			Scale = scale != default ? scale : new Vector(1, 1);
		}

		public void Draw(GameBase game)
		{
			var hw = game.Width / 2;
			var hh = game.Height / 2;

			var verts = new (float x, float y)[]
			{
				(Location.X, Location.Y),
				(Location.X + Texture.Size.Width, Location.Y),
				(Location.X * Scale.X, (Location.Y + Texture.Size.Height) * Scale.Y),
				((Location.X + Texture.Size.Width) * Scale.X, (Location.Y + Texture.Size.Height) * Scale.Y)
			};

			GL.Enable(EnableCap.Texture2D);
			GL.BindTexture(TextureTarget.Texture2D, Texture.Handle);

			if (Angle != 0)
			{
				GL.Rotate(Angle, Vector3d.UnitZ);
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

		void Vertex(double tcx, double tcy, (float x, float y) vx)
		{
			GL.TexCoord2(tcx, tcy);
			GL.Color4(Color.White);
			GL.Vertex2(vx.x, vx.y);
		}
	}
}