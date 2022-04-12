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
			FontSize = 16;
			DF.Window.Start += () => {
				text = new TextElement("", DFFont.GetDefault(), Color.White);
				heightCalculator = new TextElement("", DFFont.GetDefault(), Color.White);
				maxLine = CalculateMaxLine();
			};
			DF.Window.Render += () =>
			{
				text?.Render();
			};

			DF.Window.PostUpdate += UpdateConsole;
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
			if (text == null) return;
			var f = text.Font;
			var w = DF.Window;
			if (f.Size != FontSize || prevFont != FontPath)
			{
				heightCalculator.Font = text.Font = FontPath == null ? DFFont.GetDefault(FontSize) : new DFFont(FontPath, FontSize);
				maxLine = CalculateMaxLine();
			}

			var buf = consoleBuffer.Count > maxLine ? consoleBuffer.Skip(consoleBuffer.Count - maxLine) : consoleBuffer;

			text.Color = TextColor;
			text.Text = string.Join('\n', buf);
			prevFont = FontPath;
		}

		private int CalculateMaxLine()
		{
			var l = 0;
			do {
				heightCalculator.Text += "A\n";
				l++;
			} while (heightCalculator.Height < DF.Window.Height);
			return l - 1;
		}

		private TextElement? text;
		private readonly List<string> consoleBuffer = new();
		private TextElement heightCalculator;
		private string? prevFont;
		private int maxLine;
	}
}
