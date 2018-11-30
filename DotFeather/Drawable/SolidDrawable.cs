using System;
using OpenTK;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace DotFeather
{
	public class SolidDrawable : IDrawable
	{
		readonly Color color;

		public Vector2[] Buffer { get; }

		public PrimitiveType Primitive { get; }

		//private readonly float[] colorArray;

		public SolidDrawable(Color c, PrimitiveType primitive, params PointF[] vertexs)
		{
			color = c;

			Buffer = vertexs.Select(v => new Vector2(v.X, v.Y)).ToArray();
			Primitive = primitive;
		}

		public virtual void Draw(GameBase game)
		{
			if (Buffer == null)
				throw new InvalidOperationException("Buffer is null(It seems be a bug.)");

			var hw = game.Width / 2;
			var hh = game.Height / 2;

			GL.Begin(Primitive);
			foreach (var dp in Buffer)
			{
				// Convert device point to viewport point
				var vp = dp.ToViewportPoint(hw, hh);
				GL.Color4(color);
				GL.Vertex2(vp);
			}
			GL.End();
		}
	}

}
