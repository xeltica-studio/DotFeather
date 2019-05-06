using System;
using System.Drawing;
using OpenTK.Input;
using TK = OpenTK;

namespace DotFeather
{
	/// <summary>
	/// <see cref="System.Drawing"/>、 <see cref="DotFeather"/> および <see cref="OpenTK"/> 間における類似した構造体の相互変換をする、拡張メソッドを追加します。
	/// </summary>
	public static class SystemDrawingTypesToGLConverterExtension
	{
		/// <summary>
		/// GL版に変換します。
		/// </summary>
		public static TK.Color ToGL(this Color c) => new TK.Color(c.R, c.G, c.B, c.A);

		/// <summary>
		/// <see cref="System.Drawing"/> 版に変換します。
		/// </summary>
		public static Color ToDrawing(this TK.Color c) => Color.FromArgb(c.R, c.G, c.B, c.A);

		/// <summary>
		/// <see cref="OpenTK"/> 版に変換します。
		/// </summary>
		public static TK.Point ToGL(this Point p) => new TK.Point(p.X, p.Y);

		/// <summary>
		/// <see cref="System.Drawing"/> 版に変換します。
		/// </summary>
		public static Point ToDrawing(this TK.Point p) => new Point(p.X, p.Y);

		/// <summary>
		/// <see cref="OpenTK"/> 版に変換します。
		/// </summary>
		public static TK.PointF ToGL(this PointF p) => new TK.PointF(p.X, p.Y);

		/// <summary>
		/// <see cref="System.Drawing"/> 版に変換します。
		/// </summary>
		public static PointF ToDrawing(this TK.PointF p) => new PointF(p.X, p.Y);

		/// <summary>
		/// <see cref="OpenTK"/> 版に変換します。
		/// </summary>
		public static TK.Size ToGL(this Size s) => new TK.Size(s.Width, s.Height);

		/// <summary>
		/// <see cref="System.Drawing"/> 版に変換します。
		/// </summary>
		public static Size ToDrawing(this TK.Size s) => new Size(s.Width, s.Height);

		/// <summary>
		/// <see cref="OpenTK"/> 版に変換します。
		/// </summary>
		public static TK.SizeF ToGL(this SizeF s) => new TK.SizeF(s.Width, s.Height);

		/// <summary>
		/// <see cref="System.Drawing"/> 版に変換します。
		/// </summary>
		public static SizeF ToDrawing(this TK.SizeF s) => new SizeF(s.Width, s.Height);

		/// <summary>
		/// <see cref="OpenTK"/> 版に変換します。
		/// </summary>
		public static TK.Rectangle ToGL(this Rectangle s) => new TK.Rectangle(s.Location.ToGL(), s.Size.ToGL());

		/// <summary>
		/// <see cref="System.Drawing"/> 版に変換します。
		/// </summary>
		public static Rectangle ToDrawing(this TK.Rectangle s) => new Rectangle(s.Location.ToDrawing(), s.Size.ToDrawing());

		/// <summary>
		/// <see cref="OpenTK"/> 版に変換します。
		/// </summary>
		public static TK.RectangleF ToGL(this RectangleF s) => new TK.RectangleF(s.Location.ToGL(), s.Size.ToGL());

		/// <summary>
		/// <see cref="System.Drawing"/> 版に変換します。
		/// </summary>
		public static RectangleF ToDrawing(this TK.RectangleF s) => new RectangleF(s.Location.ToDrawing(), s.Size.ToDrawing());
	}
}
