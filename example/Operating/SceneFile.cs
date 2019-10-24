using System.Collections.Generic;

namespace DotFeather.Example
{
    public class SceneFile : IFileSystemElement
    {
        public string Name { get; }
        public Dictionary<string, string> Description { get; } = new Dictionary<string, string>();

        public SceneFile(string name)
        {
            Name = name;
        }
    }
}