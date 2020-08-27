using System;

namespace DotFeather
{
	/// <summary>
	/// A yield instruction that keeps waiting until the specified condition is met.
	/// </summary>
	public class WaitUntil : YieldInstruction
	{
		public override bool KeepWaiting => !condition();

		public WaitUntil(Func<bool> condition) => this.condition = condition;

		private readonly Func<bool> condition;
	}
}
