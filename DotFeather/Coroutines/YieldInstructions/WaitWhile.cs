using System;

namespace DotFeather
{
    /// <summary>
    /// 指定した条件が満たされている間、待機し続けるイールド命令です。
    /// </summary>
    public class WaitWhile : YieldInstruction
	{
        public override bool KeepWaiting => condition();

		public WaitWhile(Func<bool> condition) => this.condition = condition;

		private Func<bool> condition;
    }
}
