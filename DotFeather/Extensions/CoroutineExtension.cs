using System.Threading.Tasks;

namespace DotFeather
{
	public static class CoroutineExtension
	{
		public static WaitForTask ToYieldInstruction(this Task t) => new WaitForTask(t);

		public static WaitForTask ToYieldInstruction(this ValueTask t) => new WaitForTask(t);
	}
}
