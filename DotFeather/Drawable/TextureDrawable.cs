using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace DotFeather
{
	/// <summary>
	/// テクスチャを描画します。
	/// </summary>
	public class TextureDrawable : IDrawable
	{
		public Texture2D Texture { get; }

		public Point Location { get; }

		public TextureDrawable(Texture2D texture, int x, int y)
		{
			Texture = texture;
			Location = new Point(x, y);
		}

		public void Draw(GameBase game)
		{
			var hw = game.Width / 2;
			var hh = game.Height / 2;

			var v1 = new Vector2(Location.X, Location.Y).ToViewportPoint(hw, hh);
			var v2 = new Vector2(Location.X + Texture.Size.Width, Location.Y).ToViewportPoint(hw, hh);
			var v3 = new Vector2(Location.X, Location.Y + Texture.Size.Height).ToViewportPoint(hw, hh);
			var v4 = new Vector2(Location.X + Texture.Size.Width, Location.Y + Texture.Size.Height).ToViewportPoint(hw, hh);
			using (new GLContext(PrimitiveType.Quads))
			{
				GL.TexCoord2(1.0, 1.0);
				GL.Vertex3(v2.X, v2.X, 0);

				GL.TexCoord2(0.0, 1.0);
				GL.Vertex3(v1.X, v1.Y, 0);

				GL.TexCoord2(0.0, 0.0);
				GL.Vertex3(v3.X, v3.Y, 0);

				GL.TexCoord2(1.0, 0.0);
				GL.Vertex3(v4.X, v4.Y, 0);
			}
		}
	}
}
