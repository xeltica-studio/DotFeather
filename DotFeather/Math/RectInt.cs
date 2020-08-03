namespace DotFeather
{
	/// <summary>
	/// Rectangle structure.
	/// </summary>
	public struct RectInt
	{
		/// <summary>
		/// Get or set the location of this rect.
		/// </summary>
		public VectorInt Location { get; set; }

		/// <summary>
		/// Get or set the size of this rect.
		/// </summary>
		public VectorInt Size { get; set; }

		/// <summary>
		/// Get or set the left position of this rect.
		/// </summary>
		public int Left
		{
			get => Location.X;
			set => Location = new VectorInt(value, Top);
		}

		/// <summary>
		/// Get or set the top position of this rect.
		/// </summary>
		public int Top
		{
			get => Location.Y;
			set => Location = new VectorInt(Left, value);
		}

		/// <summary>
		/// Get or set the right position of this rect.
		/// </summary>
		public int Right
		{
			get => Left + Width;
			set => Left = value - Width;
		}

		/// <summary>
		/// Get or set the bottom position of this rect.
		/// </summary>
		public int Bottom
		{
			get => Top + Height;
			set => Top = value - Height;
		}

		/// <summary>
		/// Get or set width of this rect.
		/// </summary>
		public int Width
		{
			get => Size.X;
			set => Size = new VectorInt(value, Height);
		}

		/// <summary>
		/// Get or set height of this rect.
		/// </summary>
		public int Height
		{
			get => Size.Y;
			set => Size = new VectorInt(Width, value);
		}

		/// <summary>
		/// Initialize a new instance of <see cref="RectInt"/> class.
		/// </summary>
		public RectInt(VectorInt location, VectorInt size)
		{
			Location = location;
			Size = size;
		}

		/// <summary>
		/// Initialize a new instance of <see cref="RectInt"/> class.
		/// </summary>
		public RectInt(int left, int top, int width, int height)
			: this(new VectorInt(left, top), new VectorInt(width, height)) { }
	}
}
