namespace DotFeather
{
	public interface IConsole
	{
		VectorInt ConsoleCursor { get; set; }
		int ConsoleSize { get; set; }
		DFFont? ConsoleFont { get; set; }

		void Print(object? obj);
		void Cls();
	}
}
