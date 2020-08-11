namespace DotFeather
{
	public static class DotFeather
	{
		public static IGameBase Current { get; }


	}

	public interface IGameBase
	{
		VectorInt Location { get; set; }
		VectorInt Size { get; set; }
		string Title { get; set; }


	}
}
