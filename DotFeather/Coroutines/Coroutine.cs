using System;
using System.Collections;

namespace DotFeather
{
	/// <summary>
	/// コルーチンを表します。
	/// </summary>
    public class Coroutine : YieldInstruction
    {
		/// <summary>
		/// コルーチンが実行中であるかどうかを取得します。
		/// </summary>
		public bool IsRunning { get; }
		
        public override bool KeepWaiting => IsRunning;

		/// <summary>
		/// 終了後に実行するコールバックを取得します。
		/// </summary>
		public Action<object> ThenAction { get; internal set; }

		/// <summary>
		/// ハンドルされていない例外が発生した時に実行するコールバックを取得します。
		/// </summary>
		public Action<Exception> ErrorAction { get; internal set; }

		internal Coroutine(IEnumerator coroutine)
		{
			this.coroutine = coroutine;
		}

		/// <summary>
		/// コルーチン終了後のコールバックを設定します。
		/// </summary>
		/// <param name="callback">コールバック。引数は最後に <c>yield return</c> した値が入ります。</param>
		/// <returns></returns>
		public Coroutine Then(Action<object> callback) 
		{
			ThenAction = callback;
			return this;
		}

		public Coroutine Error(Action<Exception> callback) 
		{
			ErrorAction = callback;
			return this;
		}

		internal object Current => coroutine.Current;

		internal bool MoveNext()
		{
			return coroutine.MoveNext();
		}

		IEnumerator coroutine;
    }
}
