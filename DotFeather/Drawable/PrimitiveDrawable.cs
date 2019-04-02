﻿using System;
using OpenTK;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace DotFeather.Drawable
{
	internal class PrimitiveDrawable : IDrawable
	{
		readonly Color color;

		public Vector2[] Buffer { get; }

		public PrimitiveType Primitive { get; }

		public int ZOrder { get; set; }
		public string Name { get; set; }
		public Vector Location { get; set; }
		public float Angle { get; set; }
		public Vector Scale { get; set; }

		public PrimitiveDrawable(Color c, PrimitiveType primitive, params PointF[] vertexs)
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

			using (new GLContext(Primitive))
			{
				foreach (var dp in Buffer)
				{
					var vec = dp + new Vector2(Location.X, Location.Y);
					// Convert device point to viewport point
					var vp = vec.ToViewportPoint(hw, hh);
					GL.Color4(color);
					GL.Vertex2(vp);
				}
			}
		}
	}

}
