using System;

namespace DotFeather
{
	public class DFMouseEventArgs : EventArgs
	{
		/// <summary>
		/// Get the button position related to the event.
		/// </summary>
		public VectorInt Position { get; }

		public DFMouseEventArgs(VectorInt position)
		{
			Position = position;
		}
	}
}
