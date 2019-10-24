using System;
using System.Collections.Generic;

namespace DotFeather.Example
{
    public class SceneFile : IFileSystemElement
    {
        public string Name { get; }
		public Type Scene { get; }
        public Dictionary<string, string> Description { get; } = new Dictionary<string, string>();

        public Folder? Parent { get; }

        public SceneFile(string name, Type scene, Folder? parent = null) => (Name, Parent, Scene) = (name, parent, scene);
    }
}
