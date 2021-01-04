using System;
using System.Linq;
using System.Drawing;
using static DotFeather.MiscUtility;

namespace DotFeather
{
	/// <summary>
	/// Provide rendering primitive shapes.
	/// </summary>
	public class Shape : ElementBase
	{
		private Shape(Color c, ShapeType type, int lineWidth, Color? lineColor, params VectorInt[] vertices)
		{
			color = c;
			this.lineWidth = lineWidth;
			this.lineColor = lineColor;

			this.vertices = vertices;
			this.type = type;
		}

		public static Shape CreatePixel(VectorInt p, Color color)
			=> new(color, ShapeType.Pixel, 0, null, p);

		public static Shape CreatePixel(int x, int y, Color color)
			=> CreatePixel((x, y), color);

		public static Shape CreateLine(VectorInt start, VectorInt end, Color color, int lineWidth = 1)
			=> new(color, ShapeType.Line, lineWidth, null, start, end);

		public static Shape CreateLine(int sx, int sy, int ex, int ey, Color color, int lineWidth = 1)
			=> CreateLine((sx, sy), (ex, ey), color, lineWidth);

		public static Shape CreateRect(VectorInt start, VectorInt end, Color color, int lineWidth = 0, Color? lineColor = null)
			=> new(color, ShapeType.Rect, lineWidth, lineColor,
				(start.X, start.Y),
				(start.X, end.Y),
				(end.X, end.Y),
				(end.X, start.Y)
			);

		public static Shape CreateRect(int sx, int sy, int ex, int ey, Color color, int lineWidth = 0, Color? lineColor = null)
			=> CreateRect((sx, sy), (ex, ey), color, lineWidth, lineColor);

		public static Shape CreateTriangle(VectorInt v1, VectorInt v2, VectorInt v3, Color color, int lineWidth = 0, Color? lineColor = null)
			=> new(color, ShapeType.Triangle, lineWidth, lineColor, v1, v2, v3);

		public static Shape CreateTriangle(int x1, int y1, int x2, int y2, int x3, int y3, Color color, int lineWidth = 0, Color? lineColor = null)
			=> CreateTriangle((x1, y1), (x2, y2), (x3, y3), color, lineWidth, lineColor);

		public static Shape CreateEllipse(VectorInt v1, VectorInt v2, Color color, int lineWidth = 0, Color? lineColor = null)
			=> CreateEllipse(v1.X, v1.Y, v2.X, v2.Y, color, lineWidth, lineColor);

		public static Shape CreateEllipse(int x1, int y1, int x2, int y2, Color color, int lineWidth = 0, Color? lineColor = null)
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
			return new Shape(color, ShapeType.Polygon, lineWidth, lineColor, vertices);
		}

		public static Shape CreatePolygon(Color color, int lineWidth = 0, Color? lineColor = null, params VectorInt[] vertices)
			=> new(color, ShapeType.Polygon, lineWidth, lineColor, vertices);

		protected override void OnRender()
		{
			RenderTo(AbsoluteLocation, AbsoluteScale);
		}

		internal void RenderTo(Vector absoluteLocation, Vector absoluteScale)
		{
			if (vertices.Length == 0)
				return;

			DF.PrimitiveDrawer.Draw(absoluteLocation, absoluteScale, vertices, type, color, lineWidth, lineColor);
		}

		private readonly Color color;
		private readonly int lineWidth;
		private readonly Color? lineColor;
		private readonly VectorInt[] vertices;
		private readonly ShapeType type;
	}
}
