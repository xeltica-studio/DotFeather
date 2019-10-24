namespace DotFeather.Example
{
	static class Entry
	{
		static void Main(string[] args)
		{
			using (var g = new Game(640, 480))
			{
				g.Run();
			}
		}
	}
}
