using System.Collections.Generic;

namespace DotFeather.Example
{
    public class Folder : IFileSystemElement
    {
        public string Name { get; }

        public List<IFileSystemElement> Files { get; } = new List<IFileSystemElement>();

        public int Count => Files.Count;

        public Folder(string name) => Name = name;
    }
}