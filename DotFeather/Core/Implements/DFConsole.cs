using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DotFeather.Internal
{
	/// <summary>
	/// A implementation of <see cref="IConsole"/>.
	/// </summary>
	internal sealed class DFConsole : IConsole
	{
		public VectorInt ConsoleCursor { get; set; }

		public int ConsoleSize
		{
			get => (int)renderer.Font.Size;
			set => renderer.Font = ConsoleFontPath != null ? new DFFont(ConsoleFontPath, value) : DFFont.GetDefault(value);
		}

		public string? ConsoleFontPath
		{
			get => renderer.Font.Path;
			set => renderer.Font = value != null ? new DFFont(value, ConsoleSize) : DFFont.GetDefault(ConsoleSize);
		}

		/// <summary>
		/// Get or set a text color of the console.
		/// </summary>
		/// <value></value>
		public Color ForegroundColor { get; set; } = Color.White;

		internal DFConsole()
		{
			renderer = new TextDrawable("", DFFont.GetDefault(), Color.White);
			ConsoleSize = 16;
			DotFeather.Window.PostUpdate += () =>
			{
				renderer.Color = ForegroundColor;
				renderer.Draw(Vector.Zero);
			};
		}

		public void Cls()
		{
			consoleBuffer.Clear();
			ConsoleSize = 16;
			ConsoleCursor = VectorInt.Zero;
		}

		public void Print(object? obj)
		{
			var text = obj as string ?? obj?.ToString() ?? "null";
			var (x, y) = ConsoleCursor;
			x = Math.Max(0, x);
			y = Math.Max(0, y);
			if (y < consoleBuffer.Count)
			{
				// 置換
				consoleBuffer[y] = consoleBuffer[y].ReplaceAt(x, text);
			}
			else
			{
				// 挿入
				consoleBuffer.AddRange(Enumerable.Repeat("", y - consoleBuffer.Count));
				consoleBuffer.Add(new string(' ', x) + text);
			}
			ConsoleCursor = new VectorInt(0, y + 1);
		}

		private readonly TextDrawable renderer;
		private readonly List<string> consoleBuffer = new List<string>();
	}
}
