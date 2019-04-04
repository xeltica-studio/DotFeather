using System;
namespace DotFeather
{
	/// <summary>
	/// 時間に関係する情報を提供します。
	/// </summary>
	public static class Time
	{
		public static double Now { get; internal set; }
		public static double DeltaTime { get; internal set; }
	}
}
