using System;
using System.Linq;
using System.Reflection;

namespace DotFeather.Demo
{
	public static class DemoOS
	{
		/// <summary>
		/// Get or set the version of DemoOS.
		/// </summary>
		public const string VERSION = "3.0.0";

		/// <summary>
		/// Get or set current path.
		/// </summary>
		public static Folder CurrentDirectory { get; set; } = Root;

		/// <summary>
		/// Get Root Directory of Demo File System.
		/// </summary>
		public static Folder Root { get; } = new Folder("/");

		/// <summary>
		/// Initialize Demo Operating System.
		/// </summary>
		public static void Init()
		{
			// 全てのシーンを読み込む
			// Load All Scenes
			var scenes = typeof(DemoOS).Assembly.GetTypes()
				.Select(t => (t, a: t.GetCustomAttribute<DemoSceneAttribute>()))
				.Where(t => t.a != null);

			foreach (var (type, attr) in scenes)
			{
				// シーンをファイルシステムに追加
				// Add scenes to the file system
				var path = attr.Path;
				if (path.IndexOf('/') < 0) path = "/" + path;
				var a = path.LastIndexOf('/');
				var folderPath = path.Remove(a);
				var fileName = path.Substring(a + 1);
				var folder = CreateOrGetFolder(folderPath);

				var file = new SceneFile(fileName, type, folder);

				type.GetCustomAttributes<DescriptionAttribute>()
					.ToList()
					.ForEach(desc => file.Description[desc.Language] = desc.Text);

				folder.Files.Add(file);
				folder.Files.Sort((f1, f2) => f1.Name.CompareTo(f2.Name));
			}
			CurrentDirectory = Root;
		}

		/// <summary>
		/// Get folder, or create one if it doesn't exist.
		/// </summary>
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
					var folder = new Folder(name, current);
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
