using System.Threading.Tasks;

namespace DotFeather
{
	public static class CoroutineExtension
	{
		public static WaitForTask ToYieldInstruction(this Task t) => new(t);

		public static WaitForTask ToYieldInstruction(this ValueTask t) => new(t);
	}
}
