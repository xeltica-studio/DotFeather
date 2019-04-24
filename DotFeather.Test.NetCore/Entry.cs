namespace DotFeather
{
    static class Entry
	{
        static void Main(string[] args)
        {
            using (var g = new Game(320, 240))
            {
                g.Run();
            }
        }
	}
}
