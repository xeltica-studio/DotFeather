using System;
using System.Collections;

namespace DotFeather
{
	/// <summary>
	/// Coroutine class.
	/// </summary>
	public class Coroutine : YieldInstruction
	{
		/// <summary>
		/// Get whether the coroutine is running.
		/// </summary>
		public bool IsRunning { get; private set; }

		public override bool KeepWaiting => IsRunning;

		/// <summary>
		/// Get the callback to execute after exiting.
		/// </summary>
		public Action<object?>? ThenAction { get; internal set; }

		/// <summary>
		/// Get the callback that executes when an unhandled exception occurs.
		/// </summary>
		public Action<Exception>? ErrorAction { get; internal set; }

		internal Coroutine(IEnumerator coroutine)
		{
			this.coroutine = coroutine;
		}

		internal void Start() => IsRunning = true;

		internal void Stop()
		{
			IsRunning = false;

			// Dispose objects generated in the coroutine if possible
			(coroutine as IDisposable)?.Dispose();
		}

		/// <summary>
		/// Set the callback after the coroutine ends.
		/// </summary>
		/// <param name="callback">Callback. The argument is the last <c>yield return</c>ed value of the coroutine.</param>
		/// <returns></returns>
		public Coroutine Then(Action<object?> callback)
		{
			ThenAction = callback;
			return this;
		}


		/// <summary>
		/// Set the callback when the coroutine throws an exception
		/// </summary>
		/// <param name="callback">Callback.</param>
		/// <returns></returns>
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

		readonly IEnumerator coroutine;
	}
}
