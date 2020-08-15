using System.Drawing;

namespace DotFeather
{
	/// <summary>
	/// Provides Console API.
	/// </summary>
	public interface IConsole
	{
		/// <summary>
		/// Get or set a current position of this console.
		/// </summary>
		VectorInt ConsoleCursor { get; set; }

		/// <summary>
		/// Get or set font size to render this console.
		/// </summary>
		int ConsoleSize { get; set; }

		/// <summary>
		/// Get or set a font path to render this console.
		/// </summary>
		/// <value>Path to the font. If <c>null</c>, default font is used.</value>
		string? ConsoleFontPath { get; set; }

		Color ForegroundColor { get; set; }

		/// <summary>
		/// Print a provided object to the current position of this console.
		/// </summary>
		/// <param name="obj">A object to print. It will be converted to string by using ToString method.</param>
		void Print(object? obj);

		/// <summary>
		/// Clear this console.
		/// </summary>
		void Cls();
	}
}
