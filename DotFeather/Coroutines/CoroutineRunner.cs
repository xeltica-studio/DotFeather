using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotFeather
{
	/// <summary>
	/// コルーチンを管理する静的クラスです。
	/// </summary>
    public static class CoroutineRunner
	{
		/// <summary>
		/// コルーチンを開始します。
		/// </summary>
		public static Coroutine Start(IEnumerator coroutine)
		{
			var c = new Coroutine(coroutine);

			coroutines[c] = null;
			return c;
		}

		/// <summary>
		/// コルーチンを停止します。
		/// </summary>
		public static void Stop(Coroutine coroutine)
		{
			coroutines.Remove(coroutine);
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
							coroutines[coroutine] = coroutine.Current;
						}
						else
						{
							Stop(coroutine);
							coroutine.ThenAction?.Invoke(obj);
						}
					}
					catch (Exception ex)
					{
						coroutine.ErrorAction?.Invoke(ex);
					}
				}
			}
		}

		/// <summary>
		/// 任意のオブジェクトをイールド命令に変換します。
		/// </summary>
		/// <returns>イールド命令であればそのまま、<see cref="IEnumerator"/> であればコルーチン、その他であれば <see cref="WaitUntilNextFrame"/> のインスタンスを返します。</returns>
		public static YieldInstruction ToYieldInstruction(object obj)
		{
			switch (obj)
			{
				case YieldInstruction y:
					return y;
				case IEnumerator ie:
					return new Coroutine(ie);
				default:
					return new WaitUntilNextFrame();
			}
		}

		private static readonly Dictionary<Coroutine, object> coroutines = new Dictionary<Coroutine, object>();
	}
}
