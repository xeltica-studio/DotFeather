namespace DotFeather
{
	/// <summary>
	/// Depresents font-family, size, and font style.
	/// </summary>
    public class Font
	{
		/// <summary>
		/// Get a path to this font, or font-family name.
		/// </summary>
		public string Path { get; private set; }

		/// <summary>
		/// Get a size of this font.
		/// </summary>
		public float Size { get; private set; }

		/// <summary>
		/// Get a style of this font.
		/// </summary>
		public FontStyle FontStyle { get; private set; }

		/// <summary>
		/// Initialize a new instance of <see cref="Font"/> class.
		/// </summary>
		/// <param name="path">relative path to the font, or font-family name of system fonts.</param>
		/// <param name="size">font size by pixel unit.</param>
		/// <param name="style">font style.</param>
		public Font(string path, float size = 24, FontStyle style = FontStyle.Normal)
		{
			Path = path;
			Size = size;
			FontStyle = style;
		}
	}
}
