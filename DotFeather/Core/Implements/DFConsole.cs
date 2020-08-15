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
		public VectorInt Cursor { get; set; }

		public int FontSize { get; set; }

		public string? FontPath { get; set; }

		/// <summary>
		/// Get or set a text color of the console.
		/// </summary>
		/// <value></value>
		public Color TextColor { get; set; } = Color.White;

		internal DFConsole()
		{
			renderer = new TextDrawable("", DFFont.GetDefault(), Color.White);
			FontSize = 16;
			DotFeather.Window.Render += () =>
			{
				renderer.Color = TextColor;
				renderer.Draw(Vector.Zero);
			};

			DotFeather.Window.PostUpdate += UpdateConsole;
		}

		public void Cls()
		{
			consoleBuffer.Clear();
			FontSize = 16;
			Cursor = VectorInt.Zero;
		}

		public void Print(object? obj)
		{
			var text = obj as string ?? obj?.ToString() ?? "null";
			var (x, y) = Cursor;
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
			Cursor = new VectorInt(0, y + 1);
		}

		private void UpdateConsole()
		{
			var f = renderer.Font;
			var w = DotFeather.Window;
			if (f.Size != FontSize * w.Dpi || prevFont != FontPath)
				renderer.Font = FontPath == null ? DFFont.GetDefault(FontSize * w.Dpi) : new DFFont(FontPath, FontSize * w.Dpi);

			var maxLine = Math.Max(0, w.Height - 1) / FontSize;

			var buf = consoleBuffer.Count > maxLine ? consoleBuffer.Skip(consoleBuffer.Count - maxLine) : consoleBuffer;

			renderer.Color = TextColor;
			renderer.Text = string.Join('\n', buf);
			prevFont = FontPath;
		}

		private readonly TextDrawable renderer;
		private readonly List<string> consoleBuffer = new List<string>();
		private string? prevFont;
	}
}
