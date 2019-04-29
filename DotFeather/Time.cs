using System;
namespace DotFeather
{
	/// <summary>
	/// 時間に関係する情報を提供します。
	/// </summary>
	public static class Time
	{
		/// <summary>
		/// ゲームが起動してからの時刻を取得します。
		/// </summary>
		public static double Now { get; internal set; }
		/// <summary>
		/// 前回フレームとの差分時間を取得します。
		/// </summary>
		public static double DeltaTime { get; internal set; }

		/// <summary>
		/// 現在のフレームレートを取得します。
		/// </summary>
		public static int Fps { get; internal set; }
	}
}
