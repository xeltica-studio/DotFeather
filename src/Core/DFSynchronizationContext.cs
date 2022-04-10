// SEE: https://qiita.com/NumAniCloud/items/6c99ab1d4ec8b8e1c8f8
using System.Collections.Concurrent;
using System.Threading;

namespace DotFeather
{
	public class DFSynchronizationContext : SynchronizationContext
	{
		readonly ConcurrentQueue<(SendOrPostCallback callback, object? state)> continuations = new();

		public override void Post(SendOrPostCallback d, object? state)
		{
			continuations.Enqueue((d, state));
		}

		public void Update()
		{
			while (continuations.TryDequeue(out var cont))
			{
				cont.callback(cont.state);
			}
		}
	}
}
