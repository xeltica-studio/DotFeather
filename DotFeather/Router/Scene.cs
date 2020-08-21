using System;
using System.Collections.Generic;
using System.Drawing;

namespace DotFeather
{
	/// <summary>
	/// Abstract scene class.
	/// </summary>
	public abstract class Scene
	{
		/// <summary>
		/// Get a root container of this scene.
		/// </summary>
		public Element Root
		{
			get => root;
			set
			{
				if (root != null) root.Destroy();
				root = value;
			}
		}

		/// <summary>
		/// Get a random generator.
		/// </summary>
		public Random Random { get; private set; } = new Random();

		/// <summary>
		/// Get or set background color.
		/// </summary>
		public Color? BackgroundColor { get; set; }

		/// <summary>
		/// Get or set window title.
		/// </summary>
		public string? Title { get; set; }

		/// <summary>
		/// Get a current window;
		/// </summary>
		public IWindow Window => DF.Window;

		/// <summary>
		/// Get a current router;
		/// </summary>
		public Router Router => DF.Router;

		/// <summary>
		/// Alias of <see cref="IConsole.Print"/>
		/// </summary>
		public void Print(object? obj) => DF.Console.Print(obj);

		/// <summary>
		/// Alias of <see cref="IConsole.Cls"/>
		/// </summary>
		public void Cls() => DF.Console.Cls();

		/// <summary>
		/// Alias of <see cref="IConsole.Cursor"/>
		/// </summary>
		public VectorInt ConsoleCursor
		{
			get => DF.Console.Cursor;
			set => DF.Console.Cursor = value;
		}

		/// <summary>
		/// Initialize the random generator.
		/// </summary>
		/// <param name="seed">Seed value. If not specified, using a default constructor of <see cref="Random"/> to initialize. </param>
		public void Randomize(int? seed = null)
		{
			Random = seed is int s ? new Random(s) : new Random();
		}

		/// <summary>
		/// Called when the scene starts.
		/// </summary>
		public virtual void OnStart(Dictionary<string, object> args) { }

		/// <summary>
		/// Called when updating frame of the scene.
		/// </summary>
		public virtual void OnUpdate() { }
		/// <summary>
		/// Called when rendering frame of the scene.
		/// </summary>
		public virtual void OnRender() { }

		/// <summary>
		/// Called when the scene is disposed.
		/// </summary>
		public virtual void OnDestroy() { }

		private Element root = new Element("root");
	}
}
