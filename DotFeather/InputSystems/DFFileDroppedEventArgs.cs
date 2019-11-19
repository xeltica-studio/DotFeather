using System;

namespace DotFeather
{
    /// <summary>
    /// Arguments for file-dropped-event.
    /// </summary>
    public class DFFileDroppedEventArgs : EventArgs
    {
        /// <summary>
        /// Get path of a dropped file.
        /// </summary>
        public string Path { get; set; }

        public DFFileDroppedEventArgs(string path) => Path = path;
    }
}
