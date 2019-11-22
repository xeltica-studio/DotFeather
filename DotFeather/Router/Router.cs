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
		/// Get the parent game class.
		/// </summary>
		/// <value></value>
		public GameBase Game { get; }

		/// <summary>
		/// Initialize a new instance of <see cref="Router"/> class with the specified parent game class.
		/// </summary>
		/// <param name="gameBase"></param>
		public Router(GameBase gameBase)
		{
			Game = gameBase;
		}

		/// <summary>
		/// Please call when updating the game class.
		/// </summary>
		public void Update(DFEventArgs e)
		{
			if (current != null)
			{
				current.OnUpdate(this, Game, e);
				if (current.BackgroundColor != null)
					Game.BackgroundColor = current.BackgroundColor.Value;

				if (current.Title != null)
					Game.Title = current.Title;
			}
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
				current.OnDestroy(this);
				Game.Root.Remove(current.Root);
				current = null;
			}
			Game.Cls();
			CoroutineRunner.Clear();
			current = scene;
			current.OnStart(this, Game, args ?? new Dictionary<string, object>());
			Game.Root.Add(current.Root);
		}

		private Scene? current;
		private Dictionary<string, Func<Scene>> dic = new Dictionary<string, Func<Scene>>();
	}
}
