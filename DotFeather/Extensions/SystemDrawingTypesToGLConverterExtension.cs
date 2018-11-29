using System;
using System.Drawing;
using TK = OpenTK;

namespace DotFeather
{
	public static class SystemDrawingTypesToGLConverterExtension
	{
		public static TK.Color ToGL(this Color c) => new TK.Color(c.R, c.G, c.B, c.A);
		public static Color ToDrawing(this TK.Color c) => Color.FromArgb(c.R, c.G, c.B, c.A);

		public static TK.Point ToGL(this Point p) => new TK.Point(p.X, p.Y);
		public static Point ToDrawing(this TK.Point p) => new Point(p.X, p.Y);

		public static TK.PointF ToGL(this PointF p) => new TK.PointF(p.X, p.Y);
		public static PointF ToDrawing(this TK.PointF p) => new PointF(p.X, p.Y);

		public static TK.Size ToGL(this Size s) => new TK.Size(s.Width, s.Height);
		public static Size ToDrawing(this TK.Size s) => new Size(s.Width, s.Height);

		public static TK.SizeF ToGL(this SizeF s) => new TK.SizeF(s.Width, s.Height);
		public static SizeF ToDrawing(this TK.SizeF s) => new SizeF(s.Width, s.Height);

		public static TK.Rectangle ToGL(this Rectangle s) => new TK.Rectangle(s.Location.ToGL(), s.Size.ToGL());
		public static Rectangle ToDrawing(this TK.Rectangle s) => new Rectangle(s.Location.ToDrawing(), s.Size.ToDrawing());

		public static TK.RectangleF ToGL(this RectangleF s) => new TK.RectangleF(s.Location.ToGL(), s.Size.ToGL());
		public static RectangleF ToDrawing(this TK.RectangleF s) => new RectangleF(s.Location.ToDrawing(), s.Size.ToDrawing());
	}
}
