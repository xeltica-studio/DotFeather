using System.Collections.Generic;

namespace DotFeather.Demo
{
    public class Folder : IFileSystemElement
    {
        public string Name { get; }

        public List<IFileSystemElement> Files { get; } = new List<IFileSystemElement>();

		public Folder? Parent { get; }

        public int Count => Files.Count;

        public Folder(string name, Folder? parent = null) => (Name, Parent) = (name, parent);
    }
}
