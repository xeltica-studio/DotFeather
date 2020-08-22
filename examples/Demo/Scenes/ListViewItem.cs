namespace DotFeather.Demo
{
	public partial class LauncherScene
	{
		public class ListViewItem
		{
			// public Texture2D? Icon { get; set; }
			public string Text { get; set; }
			public string? Description { get; set; }

			public ListViewItem(string text, string? description = null) => (Text, Description) = (text, description);
		}
	}
}
