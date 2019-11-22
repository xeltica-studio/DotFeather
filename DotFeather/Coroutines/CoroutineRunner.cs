using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
			switch (obj)
			{
				case YieldInstruction y:
					return y;
				case IEnumerator ie:
					return CoroutineRunner.Start(ie);
				default:
					return new WaitUntilNextFrame();
			}
		}

		private static readonly Dictionary<Coroutine, object?> coroutines = new Dictionary<Coroutine, object?>();
	}
}
