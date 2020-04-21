using System;

namespace DotFeather
{
	/// <summary>
	/// A yield instruction that keeps waiting while the specified condition is met.
	/// </summary>
	public class WaitWhile : YieldInstruction
	{
		public override bool KeepWaiting => condition();

		public WaitWhile(Func<bool> condition) => this.condition = condition;

		private readonly Func<bool> condition;
	}
}
