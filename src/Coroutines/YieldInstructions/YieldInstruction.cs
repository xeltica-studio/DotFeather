namespace DotFeather
{
	/// <summary>
	/// A base yield instructions class that control coroutine waits.
	/// </summary>
	public abstract class YieldInstruction
	{
		/// <summary>
		/// Get whether it is waiting.
		/// </summary>
		public abstract bool KeepWaiting { get; }
	}
}
