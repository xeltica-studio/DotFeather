using System;
using System.Linq;

namespace DotFeather
{
	/// <summary>
	/// Arguments for file-dropped-event.
	/// </summary>
	public struct DFFileDroppedEventArgs
	{
		/// <summary>
		/// Get pathes of dropped files.
		/// </summary>
		public string[] Pathes { get; set; }

		/// <summary>
		/// Get path of a dropped file.
		/// </summary>
		public string Path => Pathes.First();

		public DFFileDroppedEventArgs(string[] pathes) => Pathes = pathes;
	}
}
