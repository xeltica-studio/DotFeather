using System;
using System.Collections.Generic;

namespace DotFeather
{
	/// <summary>
	/// Scene Management class.
	/// </summary>
	public class Router
	{

		/// <summary>
		/// Initialize a new instance of <see cref="Router"/> class with the specified parent game class.
		/// </summary>
		public Router()
		{
			DF.Window.Update += Update;
			DF.Window.Render += Render;
		}

		/// <summary>
		/// Please call when updating the game class.
		/// </summary>
		private void Update()
		{
			if (current == null) return;

			current.OnUpdate();
			if (current.BackgroundColor != null)
				DF.Window.BackgroundColor = current.BackgroundColor.Value;

			if (current.Title != null)
				DF.Window.Title = current.Title;
		}

		/// <summary>
		/// Please call when rendering the game class.
		/// </summary>
		private void Render()
		{
			current?.OnRender();
		}

		/// <summary>
		/// Register a scene by name.
		/// </summary>
		public void RegisterScene<T>(string name) where T : Scene
		{
			dic[name] = New<T>.Instance;
		}

		/// <summary>
		/// Register a scene by name.
		/// </summary>
		public void RegisterScene(Type t, string name)
		{
			dic[name] = New<Scene>.InstanceOf(t);
		}

		/// <summary>
		/// Change current scene by type.
		/// </summary>
		public void ChangeScene<T>(Dictionary<string, object>? args = null) where T : Scene
		{
			ChangeScene(New<T>.Instance(), args);
		}

		/// <summary>
		/// Change current scene by type.
		/// </summary>
		public void ChangeScene(Type t, Dictionary<string, object>? args = null)
		{
			ChangeScene(New<Scene>.InstanceOf(t)(), args);
		}

		/// <summary>
		/// Change current scene by specifying path.
		/// </summary>
		public void ChangeScene(string path, Dictionary<string, object>? args = null)
		{
			if (!dic.ContainsKey(path))
				throw new ArgumentException();

			ChangeScene(dic[path](), args);
		}

		private void ChangeScene<T>(T scene, Dictionary<string, object>? args) where T : Scene
		{
			if (current != null)
			{
				current.OnDestroy();
				DF.Root.Remove(current.Root);
				current = null;
			}
			DF.Console.Cls();
			CoroutineRunner.Clear();
			current = scene;
			current.OnStart(args ?? new Dictionary<string, object>());
			DF.Root.Add(current.Root);
		}

		private Scene? current;
		private readonly Dictionary<string, Func<Scene>> dic = new Dictionary<string, Func<Scene>>();
	}
}
