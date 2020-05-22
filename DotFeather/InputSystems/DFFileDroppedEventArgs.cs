using System;
using System.Linq;

namespace DotFeather
{
	/// <summary>
	/// Arguments for file-dropped-event.
	/// </summary>
	public class DFFileDroppedEventArgs : EventArgs
	{
		[Obsolete("Use " + nameof(Pathes))]
		public string Path { get; set; } = "";

		/// <summary>
		/// Get or set dropped files path.
		/// </summary>
		/// <value></value>
		public string[] Pathes { get; set; }

		public DFFileDroppedEventArgs(string[] pathes)
		{
			Pathes = pathes;

			// backward compatibility
			if (pathes.Length > 0)
			{
#pragma warning disable CS0618
				Path = pathes.First();
#pragma warning restore CS0618
			}
		}
	}
}
