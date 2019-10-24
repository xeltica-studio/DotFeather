using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace DotFeather.Example
{
    public static class ExampleOS
    {
        public static string? Path { get; set; }
        public static string? FormattedPath => Path == null ? null : Path.ToUpperInvariant().Replace("/", " » ");

        public static Folder Root { get; } = new Folder("/");

        public static void Init()
        {
            // Load all example scenes
            var scenes = typeof(ExampleOS).Assembly.GetTypes()
                .Select(t => (t, a: t.GetCustomAttribute<ExampleSceneAttribute>()))
                .Where(t => t.a != null);
            
            foreach (var (type, attr) in scenes)
            {
                var path = attr.Path;
                if (path.IndexOf('/') < 0) path = "/" + path;
                var a = path.LastIndexOf('/');
                var folderPath = path.Remove(a);
                var fileName = path.Substring(a + 1);
                var folder = CreateOrGetFolder(folderPath);

                var file = new SceneFile(fileName);
                folder.Files.Add(file);
            }
        }

        public static Folder CreateOrGetFolder(string path)
        {
            path = path.ToLowerInvariant();
            var nest = path.Split('/').Where(s => !string.IsNullOrEmpty(s));
            Folder current = Root;
            foreach (var name in nest)
            {
                var el = current.Files.FirstOrDefault(f => f.Name == name);
                if (el is null)
                {
                    var folder = new Folder(name);
                    current.Files.Add(folder);
                    current = folder;
                }
                else if (el is Folder f)
                {
                    current = f;
                }
                else
                {
                    // el is other non-null type
                    throw new Exception($"'{path}' already exists");
                }
            }
            return current;
        }
    }
}