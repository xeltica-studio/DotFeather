using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using static DotFeather.MiscUtility;

namespace DotFeather
{
	/// <summary>
	/// This is a graphic layer to draw shapes.
	/// </summary>
	public class Graphic : IDrawable
	{
		/// <summary>
		/// Get the list of drawing objects that the current <see cref="Graphic"/> has.
		/// </summary>
		/// <value>A list of drawable objects</value>
		public List<IDrawable> Drawables { get; } = new List<IDrawable>();

		public Vector Location { get; set; }

		public float Angle { get; set; }

		public Vector Scale { get; set; } = Vector.One;

		public int ZOrder { get; set; }

		public string Name { get; set; } = "";

		public void Draw(GameBase game, Vector location)
		{
			// Drawables を用いて毎フレーム描画を行う
			for (var i = Drawables.Count - 1; i >= 0; i--)
			{
				Drawables[i].Scale = Scale;
				Drawables[i].Draw(game, Location + location);
			}
		}

		/// <summary>
		/// Draw a point.
		/// </summary>
		public Graphic Pixel(VectorInt pos, Color color)
		{
			Drawables.Add(new PrimitiveDrawable(color, PrimitiveType.Points, 0, null, pos));
			return this;
		}

		/// <summary>
		/// Draw a point.
		/// </summary>
		public Graphic Pixel(int x, int y, Color color)
		{
			return Pixel(new VectorInt(x, y), color);
		}

		/// <summary>
		/// Draw a line.
		/// </summary>
		/// <param name="begin">Position of the start point.</param>
		/// <param name="end">Position of the end point.</param>
		/// <param name="color">color.</param>
		public Graphic Line(VectorInt begin, Vector end, Color color)
		{
			Drawables.Add(new PrimitiveDrawable(color, PrimitiveType.Lines, 0, null, begin, end));
			return this;
		}

		/// <summary>
		/// Draw a line.
		/// </summary>
		/// <param name="x1">X coordinate of the start point.</param>
		/// <param name="y1">Y coordinate of the start point.</param>
		/// <param name="x2">X coordinate of the end point.</param>
		/// <param name="y2">X coordinate of the end point.</param>
		/// <param name="color">color.</param>
		public Graphic Line(int x1, int y1, int x2, int y2, Color color)
		{
			return Line(new VectorInt(x1, y1), new Vector(x2, y2), color);
		}

		/// <summary>
		/// Draw a rectangle.
		/// </summary>
		/// <param name="begin">Position of the start point.</param>
		/// <param name="end">Position of the end point.</param>
		/// <param name="color">Color.</param>
		/// <param name="lineWidth">Width of the outline.</param>
		/// <param name="lineColor">Color of the outline.</param>
		public Graphic Rect(VectorInt begin, VectorInt end, Color color, int lineWidth = 0, Color? lineColor = default)
		{
			return Rect(begin.X, begin.Y, end.X, end.Y, color, lineWidth, lineColor);
		}

		/// <summary>
		/// Draw a rectangle.
		/// </summary>
		/// <param name="x1">X coordinate of the start point.</param>
		/// <param name="y1">Y coordinate of the start point.</param>
		/// <param name="x2">X coordinate of the end point.</param>
		/// <param name="y2">X coordinate of the end point.</param>
		/// <param name="color">Color.</param>
		/// <param name="lineWidth">Width of the outline.</param>
		/// <param name="lineColor">Color of the outline.</param>
		public Graphic Rect(int x1, int y1, int x2, int y2, Color color, int lineWidth = 0, Color? lineColor = default)
		{
			Drawables.Add(new PrimitiveDrawable(color, PrimitiveType.Quads, lineWidth, lineColor,
				new Vector(x1, y1),
				new Vector(x1, y2),
				new Vector(x2, y2),
				new Vector(x2, y1)));
			return this;
		}

		/// <summary>
		/// Draw a triangle.
		/// </summary>
		public Graphic Triangle(int x1, int y1, int x2, int y2, int x3, int y3, Color color, int lineWidth = 0, Color? lineColor = default)
		{
			Drawables.Add(new PrimitiveDrawable(color, PrimitiveType.Triangles,lineWidth, lineColor,
				new Vector(x1, y1),
				new Vector(x2, y2),
				new Vector(x3, y3)));
			return this;
		}

		/// <summary>
		/// Draw a triangle.
		/// </summary>
		public Graphic Triangle(VectorInt p1, VectorInt p2, VectorInt p3, Color color, int lineWidth = 0, Color? lineColor = default)
		{
			return Triangle(p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y, color, lineWidth, lineColor);
		}

		/// <summary>
		/// Draw an ellipse.
		/// </summary>
		public Graphic Ellipse(int x1, int y1, int x2, int y2, Color color, int lineWidth = 0, Color? lineColor = default)
		{
			var list = new List<Vector>();

			if (x1 > x2) Swap(ref x1, ref x2);
			if (y1 > y2) Swap(ref y1, ref y2);

			var (width, height) = (x2 - x1, y2 - y1);

			// 大きさに応じて頂点数いじる
			var verts = Math.Min(360, (width + height) / 10);

			for (int i = 0; i < 360; i += (int)(360 / verts))
			{
				var (rw, rh) = (width / 2, height / 2);
				var (ox, oy) = (x1 + rw, y1 + rh);

				list.Add(new Vector(
					(float)(Math.Cos(DFMath.ToRadian(i)) * rw + ox),
					(float)(Math.Sin(DFMath.ToRadian(i)) * rh + oy)
				));

			}

			Drawables.Add(new PrimitiveDrawable(color, PrimitiveType.Polygon, lineWidth, lineColor, list.ToArray()));
			return this;
		}

		/// <summary>
		/// Draw an ellipse.
		/// </summary>
		public Graphic Ellipse(VectorInt p1, VectorInt p2, Color color, int lineWidth = 0, Color? lineColor = default)
		{
			return Ellipse(p1.X, p1.Y, p2.X, p2.Y, color, lineWidth, lineColor);
		}

		/// <summary>
		/// Draw a texture.
		/// </summary>
		/// <param name="x">The first x value.</param>
		/// <param name="y">The first y value.</param>
		/// <param name="texture">A texture.</param>
		public Graphic Texture(int x, int y, Texture2D texture)
		{
			Drawables.Add(new Sprite(texture)
			{
				Location = new Vector(x, y),
			});
			return this;
		}

		/// <summary>
		/// Clear this graphic layer.
		/// </summary>
		public Graphic Clear()
		{
			Drawables.ForEach(d => d.Destroy());
			Drawables.Clear();
			return this;
		}

		/// <summary>
		/// Destroy this <see cref="Graphic"/>.
		/// </summary>
		public void Destroy() => Clear();
	}
}
