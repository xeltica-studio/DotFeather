using System.Drawing;

namespace DotFeather
{
	/// <summary>
	/// An abstract class for objects that draw a <see cref="Texture2D"/>.
	/// </summary>
	public abstract class TextureDrawableBase : IContainable, ISizedDrawable
	{
		public virtual int ZOrder { get; set; }

		public virtual string Name { get; set; } = "";

		public virtual Vector Location { get; set; }

		public virtual float Angle { get; set; }

		public virtual Vector Scale { get; set; } = new Vector(1, 1);

		/// <summary>
		/// Get or set width of this object.
		/// </summary>
		public virtual float Width { get; set; }

		/// <summary>
		/// Get or set height of this object.
		/// </summary>
		/// <value></value>
		public virtual float Height { get; set; }

		/// <summary>
		/// Get or set color of this object.
		/// </summary>
		/// <value></value>
		public virtual Color? Color { get; set; }

		/// <summary>
		/// Get a texture of this object.
		/// </summary>
		public virtual Texture2D Texture { get; protected set; }

		float ISizedDrawable.Width
		{
			get => Width;
			set => Width = (int)value;
		}

		float ISizedDrawable.Height
		{
			get => Height;
			set => Height = (int)value;
		}

		public IContainable? Parent { get; internal set; }

		IContainable? IContainable.Parent
		{
			get => Parent;
			set => Parent = value;
		}

		/// <summary>
		/// Get absolute location.
		/// </summary>
		public Vector AbsoluteLocation => Location + (Parent?.AbsoluteLocation ?? Vector.Zero);

		/// <summary>
		/// Dispose this object.
		/// </summary>
		public virtual void Destroy()
		{
		}

		/// <summary>
		/// Draw the texture.
		/// </summary>
		public virtual void Draw(GameBase game, Vector location)
		{
			TextureDrawer.Draw(game, Texture, location + Location, Scale, Angle, Color, Width, Height);
		}
	}
}
