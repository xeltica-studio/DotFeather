using System.Threading.Tasks;

namespace DotFeather
{
	public class WaitForTask : YieldInstruction
	{
		public override bool KeepWaiting =>
			t != null ? !(t.IsCanceled || t.IsCompleted || t.IsCompletedSuccessfully || t.IsFaulted) :
			vt is ValueTask v ? !(v.IsCanceled || v.IsCompletedSuccessfully || v.IsCompletedSuccessfully || v.IsFaulted) : false;

		public WaitForTask(Task task) => t = task;

		public WaitForTask(ValueTask task) => vt = task;

		private Task? t;
		private ValueTask? vt;
	}
}
