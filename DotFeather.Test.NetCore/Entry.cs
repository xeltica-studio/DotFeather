namespace DotFeather
{
	static class Entry
	{
		static void Main(string[] args)
		{
			using (var g = new Game(1280, 720))
			{
				g.Run();
			}
		}
	}
}
