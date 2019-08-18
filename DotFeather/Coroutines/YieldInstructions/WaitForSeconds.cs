namespace DotFeather
{
	/// <summary>
	/// 指定した秒数だけ待機するイールド命令です。
	/// </summary>
    public class WaitForSeconds : YieldInstruction
	{
		public override bool KeepWaiting
		{
			get
			{
				startTime = startTime ?? Time.Now;
				return Time.Now - startTime.Value < targetTime;
			}
		}

		/// <summary>
		/// 指定した時間待機するイールド命令を生成します。
		/// </summary>
		/// <param name="time"></param>
		public WaitForSeconds(float time)
		{
			targetTime = time;
		}

		private double? startTime;
		private double targetTime;
	}
}
