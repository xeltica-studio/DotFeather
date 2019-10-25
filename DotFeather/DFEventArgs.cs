using System;

namespace DotFeather
{
	/// <summary>
	/// A basic event arguments.
	/// </summary>
	public class DFEventArgs : EventArgs
	{
		/// <summary>
		/// Get elapsed time (in seconds) since the same event was called last time.
		/// </summary>
		/// <value>The delta time.</value>
		public float DeltaTime { get; set; }
	}

	/// <summary>
	/// Arguments for file-dropped-event.
	/// </summary>
	public class FileDroppedEventArgs : EventArgs
	{
		/// <summary>
		/// Get path of a dropped file.
		/// </summary>
		public string Path { get; set; }

		public FileDroppedEventArgs(string path) => Path = path;
	}
}
