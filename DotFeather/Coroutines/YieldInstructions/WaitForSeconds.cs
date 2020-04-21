namespace DotFeather
{
	/// <summary>
	/// A yield instruction that waits for a specified number of seconds.
	/// </summary>
	public class WaitForSeconds : YieldInstruction
	{
		public override bool KeepWaiting
		{
			get
			{
				startTime ??= Time.Now;
				return Time.Now - startTime.Value < targetTime;
			}
		}

		public WaitForSeconds(float time)
		{
			targetTime = time;
		}

		private double? startTime;
		private readonly double targetTime;
	}
}
