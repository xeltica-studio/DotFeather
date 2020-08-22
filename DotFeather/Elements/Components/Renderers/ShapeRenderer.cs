using System;
using OpenTK;
using System.Linq;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using static DotFeather.MiscUtility;

namespace DotFeather
{
	/// <summary>
	/// Provide rendering primitive shapes.
	/// </summary>
	public class ShapeRenderer : Component
	{
		private ShapeRenderer(Color c, PrimitiveType type, int lineWidth, Color? lineColor, params VectorInt[] vertices)
		{
			color = c;
			this.lineWidth = lineWidth;
			this.lineColor = lineColor;

			this.vertices = vertices;
			this.type = type;
		}

		public static ShapeRenderer CreatePixel(VectorInt p, Color color)
			=> new ShapeRenderer(color, PrimitiveType.Points, 0, null, p);

		public static ShapeRenderer CreatePixel(int x, int y, Color color)
			=> CreatePixel((x, y), color);

		public static ShapeRenderer CreateLine(VectorInt start, VectorInt end, Color color, int lineWidth = 1)
			=> new ShapeRenderer(color, PrimitiveType.Lines, lineWidth, null, start, end);

		public static ShapeRenderer CreateLine(int sx, int sy, int ex, int ey, Color color, int lineWidth = 1)
			=> CreateLine((sx, sy), (ex, ey), color, lineWidth);

		public static ShapeRenderer CreateRect(VectorInt start, VectorInt end, Color color, int lineWidth = 0, Color? lineColor = null)
			=> new ShapeRenderer(color, PrimitiveType.Quads, lineWidth, lineColor,
				(start.X, start.Y),
				(start.X, end.Y),
				(end.X, end.Y),
				(end.X, start.Y)
			);

		public static ShapeRenderer CreateRect(int sx, int sy, int ex, int ey, Color color, int lineWidth = 0, Color? lineColor = null)
			=> CreateRect((sx, sy), (ex, ey), color, lineWidth, lineColor);

		public static ShapeRenderer CreateTriangle(VectorInt v1, VectorInt v2, VectorInt v3, Color color, int lineWidth = 0, Color? lineColor = null)
			=> new ShapeRenderer(color, PrimitiveType.Triangles, lineWidth, lineColor, v1, v2, v3);

		public static ShapeRenderer CreateTriangle(int x1, int y1, int x2, int y2, int x3, int y3, Color color, int lineWidth = 0, Color? lineColor = null)
			=> CreateTriangle((x1, y1), (x2, y2), (x3, y3), color, lineWidth, lineColor);

		public static ShapeRenderer CreateEllipse(VectorInt v1, VectorInt v2, Color color, int lineWidth = 0, Color? lineColor = null)
			=> CreateEllipse(v1.X, v1.Y, v2.X, v2.Y, color, lineWidth, lineColor);

		public static ShapeRenderer CreateEllipse(int x1, int y1, int x2, int y2, Color color, int lineWidth = 0, Color? lineColor = null)
		{
			if (x1 > x2) Swap(ref x1, ref x2);
			if (y1 > y2) Swap(ref y1, ref y2);

			var (width, height) = (x2 - x1, y2 - y1);
			var count = Math.Min(360, (width + height) / 10);
			var vertices = new VectorInt[count];

			for (var i = 0; i < count; i++)
			{
				var rad = DFMath.ToRadian(i * (360f / count));
				var (rw, rh) = (width / 2, height / 2);
				var (ox, oy) = (x1 + rw, y1 + rh);
				vertices[i] = ((int)(Math.Cos(rad) * rw + ox), (int)(Math.Sin(rad) * rh + oy));
			}
			return new ShapeRenderer(color, PrimitiveType.Polygon, lineWidth, lineColor, vertices);
		}

		public static ShapeRenderer CreatePolygon(Color color, int lineWidth = 0, Color? lineColor = null, params VectorInt[] vertices)
			=> new ShapeRenderer(color, PrimitiveType.Polygon, lineWidth, lineColor, vertices);

		public override void OnRender()
		{
			if (Transform == null || vertices.Length == 0)
				return;

			var hw = DF.Window.ActualWidth / 2;
			var hh = DF.Window.ActualHeight / 2;

			GL.Enable(EnableCap.Blend);
			GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

			if (color.A > 0)
			{
				using (new GLContext(type))
				{
					if (type == PrimitiveType.Lines) GL.LineWidth(lineWidth);
					foreach (var vc in vertices)
					{
						var dest = Transform.GlobalLocation + vc * Transform.GlobalScale;
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
						var dest = Transform.GlobalLocation + vc * Transform.GlobalScale;
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

		public virtual void Destroy() { }

		private void Vertex(Color col, Vector vec)
		{
			GL.Color4(col);
			GL.Vertex2(vec.X, vec.Y);
		}

		private readonly Color color;
		private readonly int lineWidth;
		private readonly Color? lineColor;
		private readonly VectorInt[] vertices;
		private readonly PrimitiveType type;
	}

}
