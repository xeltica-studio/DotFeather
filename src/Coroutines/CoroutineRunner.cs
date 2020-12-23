using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotFeather
{
	/// <summary>
	/// A static coroutine manager class.
	/// </summary>
	public static class CoroutineRunner
	{
		/// <summary>
		/// Start the specified coroutine.
		/// </summary>
		public static Coroutine Start(IEnumerator coroutine)
		{
			var c = new Coroutine(coroutine);

			coroutines[c] = null;
			c.Start();
			return c;
		}

		/// <summary>
		/// Stop the specified coroutine.
		/// </summary>
		public static void Stop(Coroutine coroutine)
		{
			coroutines.Remove(coroutine);
			coroutine.Stop();
		}

		/// <summary>
		/// Stop all running coroutines.
		/// </summary>
		public static void Clear()
		{
			// Stop
			coroutines.Keys.ToList().ForEach(c => c.Stop());
			coroutines.Clear();
		}

		internal static void Update()
		{
			foreach (var (coroutine, obj) in coroutines.Select(c => (c.Key, c.Value)).ToArray())
			{
				var currentInst = ToYieldInstruction(obj);

				if (!currentInst.KeepWaiting)
				{
					try
					{
						if (coroutine.MoveNext())
						{
							var cur = coroutine.Current;
							// IEnumerator が来たら再度コルーチン開始する
							cur = cur is IEnumerator ie ? Start(ie) : cur;
							coroutines[coroutine] = cur;
						}
						else
						{
							Stop(coroutine);
							coroutine.ThenAction?.Invoke(obj);
						}
					}
					catch (Exception ex)
					{
						coroutine.Stop();
						coroutine.ErrorAction?.Invoke(ex);
					}
				}
			}
		}

		private static YieldInstruction ToYieldInstruction(object obj)
		{
			return obj switch
			{
				YieldInstruction y => y,
				IEnumerator ie => Start(ie),
				Task t => t.ToYieldInstruction(),
				ValueTask t => t.ToYieldInstruction(),
				_ => new WaitUntilNextFrame(),
			};
		}

		private static readonly Dictionary<Coroutine, object?> coroutines = new();
	}
}
