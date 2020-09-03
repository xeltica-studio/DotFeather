using System;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace DotFeather.Internal
{
	public class DesktopPrimitiveDrawer : IPrimitiveDrawer
	{
		public void Draw(Vector originLocation, Vector originScale, VectorInt[] vertices, ShapeType type, Color color, int lineWidth = 0, Color? lineColor = null)
		{
			if (vertices.Length == 0)
				return;

			var glType = ToGLType(type);

			var hw = DF.Window.ActualWidth / 2;
			var hh = DF.Window.ActualHeight / 2;

			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

			if (color.A > 0)
			{
				using (new GLContext(glType))
				{
					if (type == ShapeType.Line) GL.LineWidth(lineWidth);
					foreach (var vc in vertices)
					{
						var dest = originLocation + vc * originScale;
						// Convert device point to viewport point
						var vpp = dest.ToDeviceCoord().ToViewportPoint(hw, hh);
						Vertex(color, vpp);
					}
				}
			}

			if (lineWidth > 0 && lineColor is Color lc)
			{
				using (new GLContext(PrimitiveType.Lines))
				{
					GL.LineWidth(lineWidth);
					Vector? prevVertex = null;
					Vector? first = null;
					foreach (var vc in vertices)
					{
						var dest = originLocation + vc * originScale;
						// Convert device point to viewport point
						var vp = dest.ToDeviceCoord().ToViewportPoint(hw, hh);
						if (first == null)
							first = vp;

						if (prevVertex is Vector pv)
						{
							var pVp = pv;
							Vertex(lc, pVp);
							Vertex(lc, vp);
						}
						prevVertex = vp;
					}
					Vertex(lc, prevVertex ?? Vector.One);
					Vertex(lc, first ?? Vector.One);
				}
			}

			GL.Disable(EnableCap.Blend);
		}

		private void Vertex(Color col, Vector vec)
		{
			GL.Color4(col);
			GL.Vertex2(vec.X, vec.Y);
		}

		private PrimitiveType ToGLType(ShapeType type)
		{
			return type switch
			{
				ShapeType.Pixel => PrimitiveType.Points,
				ShapeType.Line => PrimitiveType.Lines,
				ShapeType.Rect => PrimitiveType.Quads,
				ShapeType.Triangle => PrimitiveType.Triangles,
				ShapeType.Polygon => PrimitiveType.Polygon,
				_ => throw new ArgumentException(),
			};
		}
	}
}
