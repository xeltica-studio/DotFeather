using System.Collections.Generic;
using System.Linq;

namespace DotFeather
{
	public abstract class ElementBase
	{
		public virtual string Name { get; set; } = "";
		public virtual Vector Location { get; set; }
		public virtual Vector Scale { get; set; } = (1, 1);
		public virtual VectorInt Size { get; set; }
		public int Width { get => Size.X; set => Size = (value, Height); }
		public int Height { get => Size.Y; set => Size = (Width, value); }

		public Vector AbsoluteLocation { get; private set; }
		public Vector AbsoluteScale { get; private set; }

		public Container? Parent { get; internal set; }

		public ElementBase()
		{
			ComputeTransform();
		}

		public T AddComponent<T>() where T : Component
		{
			var com = New<T>.Instance();
			com.Element = this;
			components.Add(com);
			com.OnStart();
			return com;
		}

		public T? GetComponent<T>() where T : Component
		{
			return EnumerateComponents<T>().FirstOrDefault();
		}

		public T[] GetComponents<T>() where T : Component
		{
			return EnumerateComponents<T>().ToArray();
		}

		public IEnumerable<T> EnumerateComponents<T>() where T : Component
		{
			return components.OfType<T>();
		}

		public void RemoveComponent(Component c)
		{
			c.OnDestroy();
			c.Element = null!;
			components.Remove(c);
		}

		public void Destroy()
		{
			OnDestroy();
			for (var i = 0; i < components.Count; i++)
				components[i].OnDestroy();
		}

		internal void ComputeTransform()
		{
			// Compute global location and scale
			AbsoluteLocation = Location;
			AbsoluteScale = Scale;

			var p = Parent;
			if (p == null) return;
			AbsoluteScale *= p.AbsoluteScale;
			AbsoluteLocation *= AbsoluteScale;
			AbsoluteLocation += p.AbsoluteLocation;
		}

		internal virtual void Update()
		{
			ComputeTransform();
			OnUpdate();
			for (var i = 0; i < components.Count; i++)
				components[i].OnUpdate();
		}

		internal virtual void Render()
		{
			OnRender();
			for (var i = 0; i < components.Count; i++)
				components[i].OnRender();
		}

		protected virtual void OnUpdate() { }

		protected virtual void OnRender() { }

		protected virtual void OnDestroy() { }

		private readonly List<Component> components = new List<Component>();
	}
}
