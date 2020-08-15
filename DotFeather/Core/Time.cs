using System;
namespace DotFeather
{
	/// <summary>
	/// Provides time related information.
	/// </summary>
	public static class Time
	{
		/// <summary>
		/// Get the time since the game started.
		/// </summary>
		public static float Now { get; internal set; }
		/// <summary>
		/// Get the delta time from the previous frame.
		/// </summary>
		public static float DeltaTime { get; internal set; }

		/// <summary>
		/// Get the current frame rate.
		/// </summary>
		public static int Fps { get; internal set; }
	}
}
