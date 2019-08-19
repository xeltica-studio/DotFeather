namespace DotFeather
{
	/// <summary>
	/// 次回フレームまで待機するイールド命令です。
	/// </summary>
	public class WaitUntilNextFrame : YieldInstruction
	{
		public override bool KeepWaiting => false;
	}
}
