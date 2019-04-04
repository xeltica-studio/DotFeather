using System;

namespace DotFeather.Models
{
	/// <summary>
	/// DotFeather の基本的なイベント引数です。
	/// </summary>
	public class DFEventArgs : EventArgs
	{
		/// <summary>
		/// 前回同じイベントを呼び出されてから経過した時間(秒単位)。
		/// </summary>
		/// <value>The delta time.</value>
		public double DeltaTime { get; set; }
	}
}
