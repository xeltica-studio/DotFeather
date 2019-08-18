using System;

namespace DotFeather
{
    /// <summary>
    /// 指定した条件が満たされるまで待機し続けるイールド命令です。
    /// </summary>
    public class WaitUntil : YieldInstruction
	{
        public override bool KeepWaiting => !condition();

		public WaitUntil(Func<bool> condition) => this.condition = condition;

		private Func<bool> condition;
    }
}
