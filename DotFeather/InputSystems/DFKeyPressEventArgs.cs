using System;

namespace DotFeather
{
	/// <summary>
	/// Keyboard pressed event argument.
	/// </summary>
	public class DFKeyPressEventArgs : EventArgs
	{
		public char KeyChar { get; }

		internal DFKeyPressEventArgs(char ch) => KeyChar = ch;
	}
}
