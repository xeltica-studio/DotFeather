using System;
using OpenTK;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace DotFeather
{
	public class Drawable : IDrawable
	{
		readonly Color color;

		public Vector2[] Buffer { get; }

		public PrimitiveType Primitive { get; }

		//private readonly float[] colorArray;

		public Drawable(Color c, PrimitiveType primitive, params PointF[] vertexs)
		{
			color = c;

			Buffer = vertexs.Select(v => new Vector2(v.X, v.Y)).ToArray();
			Primitive = primitive;
			//colorArray = Enumerable.Repeat(new[]{ c.R, c.G, c.B }, Buffer.Length).SelectMany(b => b).Cast<float>().ToArray();
		}

		public virtual void Draw(GameBase game)
		{
			if (Buffer == null)
				throw new InvalidOperationException("Buffer is null(It seems be a bug.)");
			//unsafe
			//{
			//	var colors = Enumerable.Repeat(color, Buffer.Length).ToArray();

			//	fixed (PointF* _ = Buffer)
			//	fixed (Color* __ = colors)
			//	{
			//		GL.VertexPointer(2, VertexPointerType.Float, 0, Buffer);
			//		GL.ColorPointer(2, ColorPointerType.Float, 0, colors);
			//		GL.DrawArrays(Primitive, 0, Buffer.Length);
			//	}
			//}
			GL.Begin(Primitive);
			var hw = game.Width / 2;
			var hh = game.Height /2;
			foreach (var dp in Buffer)
			{
				// Convert device point to viewport point
				var vp = new Vector2((dp.X - hw) / hw, -(dp.Y - hh) / hh);
				GL.Color4(color);
				GL.Vertex2(vp);
			}
			GL.End();
		}
	}

}
