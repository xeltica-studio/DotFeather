namespace DotFeather
{
	public class DFMouseButtonEventArgs : DFMouseEventArgs
	{
		/// <summary>
		/// Get the button ID related to the event.
		/// </summary>
		public int ButtonId { get; }

		public DFMouseButtonEventArgs(int buttonId, VectorInt position): base(position)
		{
			ButtonId = buttonId;
		}
	}
}
