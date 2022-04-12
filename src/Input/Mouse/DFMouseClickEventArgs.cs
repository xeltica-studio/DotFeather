namespace DotFeather
{
	public class DFMouseClickEventArgs : DFMouseEventArgs
	{
		/// <summary>
		/// Get the button ID related to the event.
		/// </summary>
		public int ButtonId { get; }

		public DFMouseClickEventArgs(int buttonId, VectorInt position): base(position)
		{
			ButtonId = buttonId;
		}
	}
}
