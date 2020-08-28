using System.Drawing;

namespace DotFeather
{
	public class Graphic : PrimitiveElement
	{
		public new void Clear()
		{
			ClearComponents();
		}

		public Graphic Pixel(VectorInt p, Color color)
		{
			AddComponent(ShapeRenderer.CreatePixel(p, color));
			return this;
		}

		public Graphic Pixel(int x, int y, Color color)
			=> Pixel((x, y), color);

		public Graphic Line(VectorInt start, VectorInt end, Color color, int lineWidth = 1)
		{
			AddComponent(ShapeRenderer.CreateLine(start, end, color, lineWidth));
			return this;
		}

		public Graphic Line(int sx, int sy, int ex, int ey, Color color, int lineWidth = 1)
			=> Line((sx, sy), (ex, ey), color, lineWidth);

		public Graphic Rect(VectorInt start, VectorInt end, Color color, int lineWidth = 0, Color? lineColor = null)
		{
			AddComponent(ShapeRenderer.CreateRect(start, end, color, lineWidth, lineColor));
			return this;
		}

		public Graphic Rect(int sx, int sy, int ex, int ey, Color color, int lineWidth = 0, Color? lineColor = null)
			=> Rect((sx, sy), (ex, ey), color, lineWidth, lineColor);

		public Graphic Triangle(VectorInt v1, VectorInt v2, VectorInt v3, Color color, int lineWidth = 0, Color? lineColor = null)
		{
			AddComponent(ShapeRenderer.CreateTriangle(v1, v2, v3, color, lineWidth, lineColor));
			return this;
		}

		public Graphic Triangle(int x1, int y1, int x2, int y2, int x3, int y3, Color color, int lineWidth = 0, Color? lineColor = null)
			=> Triangle((x1, y1), (x2, y2), (x3, y3), color, lineWidth, lineColor);

		public Graphic Ellipse(VectorInt v1, VectorInt v2, Color color, int lineWidth = 0, Color? lineColor = null)
			=> Ellipse(v1.X, v1.Y, v2.X, v2.Y, color, lineWidth, lineColor);

		public Graphic Ellipse(int x1, int y1, int x2, int y2, Color color, int lineWidth = 0, Color? lineColor = null)
		{
			AddComponent(ShapeRenderer.CreateEllipse(x1, y1, x2, y2, color, lineWidth, lineColor));
			return this;
		}

		public Graphic Polygon(Color color, int lineWidth = 0, Color? lineColor = null, params VectorInt[] vertices)
		{
			AddComponent(ShapeRenderer.CreatePolygon(color, lineWidth, lineColor, vertices));
			return this;
		}
	}
}
