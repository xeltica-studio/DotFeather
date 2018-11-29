using System;
using System.Collections.Generic;
using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace DotFeather
{
	public class GraphicLayer : ILayer
	{

		public List<Drawable> Drawables { get; } = new List<Drawable>();

		public void Draw(GameBase game)
		{
			Drawables.ForEach(d => d.Draw(game));
		}

		public void Pixel(Point pos, Color color)
		{
			Drawables.Add(new Drawable(color.ToGL(), PrimitiveType.Points, ((PointF)pos).ToGL()));
		}

		public void Pixel(int x, int y, Color color)
		{
			Pixel(new Point(x, y), color);
		}

		public void Line(Point begin, Point end, Color color)
		{
			Drawables.Add(new Drawable(color.ToGL(), PrimitiveType.Lines, ((PointF)begin).ToGL(), ((PointF)end).ToGL()));
		}

		public void Line(int x1, int y1, int x2, int y2, Color color)
		{
			Line(new Point(x1, y1), new Point(x2, y2), color);
		}

		public void Rect(Point begin, Point end, Color color)
		{
			Rect(begin.X, begin.Y, end.X, end.Y, color);
		}

		public void Rect(int x1, int y1, int x2, int y2, Color color)
		{
			Drawables.Add(new Drawable(color.ToGL(), PrimitiveType.Quads,
			                           new OpenTK.PointF(x1, y1), 
			                           new OpenTK.PointF(x1, y2), 
			                           new OpenTK.PointF(x2, y2),
			                           new OpenTK.PointF(x2, y1)));
		}

		public void Clear()
		{
			Drawables.Clear();
		}

		public void Text(Rectangle range, string text, Color color, Font font = default)
		{
			//todo Implement this. Reference: https://github.com/mono/opentk/blob/master/Source/Examples/OpenGL/1.x/TextRendering.cs
			throw new NotImplementedException("Wait!");
		}
	}

}
