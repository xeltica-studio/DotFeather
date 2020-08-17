using System;
using OpenTK.Graphics.OpenGL;

namespace DotFeather
{
	public class Trimmer : Component
	{
		public VectorInt Size { get; set; }

		public int Width
		{
			get => Size.X;
			set => Size = (value, Height);
		}

		public int Height
		{
			get => Size.Y;
			set => Size = (Width, value);
		}

		public Trimmer(VectorInt size)
		{
			Size = size;
		}

		public Trimmer(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public override void OnPreRender()
		{
			if (Transform == null) return;

			if (GL.IsEnabled(EnableCap.ScissorTest))
				throw new InvalidOperationException($"{nameof(Trimmer)} component can not be nested.");

			GL.Enable(EnableCap.ScissorTest);
			var left = (VectorInt)Transform.GlobalLocation;
			var size = (VectorInt)(new Vector(Width, Height) * Transform.GlobalScale);

			if (left.X < 0) left.X = 0;
			if (left.Y < 0) left.Y = 0;

			if (left.X + size.X > DF.Window.ActualWidth)
				size.X = left.X + size.X - DF.Window.ActualWidth;

			if (left.Y + size.Y > DF.Window.ActualHeight)
				size.Y = left.Y + size.Y - DF.Window.ActualHeight;

			left.Y = DF.Window.ActualHeight - left.Y - size.Y;

			GL.Scissor(left.X, left.Y, size.X, size.Y);
		}

		public override void OnPostRender()
		{
			GL.Scissor(0, 0, DF.Window.ActualWidth, DF.Window.ActualHeight);
			GL.Disable(EnableCap.ScissorTest);
		}
	}
}
