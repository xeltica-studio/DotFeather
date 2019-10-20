namespace DotFeather
{
    public class Font
	{
		public string Path { get; private set; }
		public float Size { get; private set; }
		public FontStyle FontStyle { get; private set; }

		public Font(string path, float size = 24, FontStyle style = FontStyle.Normal)
		{
			Path = path;
			Size = size;
			FontStyle = style;
		}
	}
}
