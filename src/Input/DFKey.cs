
namespace DotFeather
{
	/// <summary>
	/// Represents a keyboard key.
	/// </summary>
	public class DFKey
	{
		internal DFKey() { }

		/// <summary>
		/// Gets a value that indicates whether the key is pressed.
		/// </summary>
		public bool IsPressed { get; internal set; }

		/// <summary>
		/// Gets the frame count elapsed since the key was pressed.
		/// </summary>
		/// <value></value>
		public int ElapsedFrameCount { get; internal set; }

		/// <summary>
		/// Gets the time elapsed since the key was pressed.
		/// </summary>
		/// <value></value>
		public float ElapsedTime { get; internal set; }

		/// <summary>
		/// Gets whether the key was pressed at this frame.
		/// </summary>
		public bool IsKeyDown { get; internal set; }

		/// <summary>
		/// Gets whether the key was released at this frame.
		/// </summary>
		public bool IsKeyUp { get; internal set; }

		public static implicit operator bool(DFKey key) => key.IsPressed;
	}

}
