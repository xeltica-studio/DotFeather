using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotFeather
{
	public sealed class Element : IReadOnlyList<Element>
	{
		public string Key { get; set; }

		public int Count => children.Count;

		public Element this[int index] { get => children[index]; }

		public Transform Transform { get; private set; }

		public Element? Parent { get; private set; }

		public bool IsVisible { get; set; } = true;

		public bool IsDestroyed { get; private set; }

		public Element(string key)
		{
			Key = key;
			Transform = new Transform();
			Transform.SetParent(this);
			Transform.OnStart();
		}

		public Element(string key, params Element[] children) : this(key)
		{
			AddRange(children);
		}

		public void AddComponent(Component com)
		{
			// 破棄されたコンポーネントを追加してはいけない
			if (com.IsDestroyed) throw new ObjectDestroyedException();

			if (com is Transform t)
			{
				// 他に親を持つ Transform を追加してはいけない
				if (t.Element != null && t.Element != this)
					throw new ArgumentException("You can not add this Transform component.");

				t.SetParent(this);
				Transform = t;
				return;
			}

			if (com.Element != null)
				com.Element.RemoveComponent(com);

			com.SetParent(this);
			components.Add(com);
			com.OnStart();
		}

		public Element With(params Component[] components)
		{
			foreach (var com in components)
				AddComponent(com);
			return this;
		}

		public Element With(Vector location)
		{
			Transform.Location = location;
			return this;
		}

		public Element With(Vector location, Vector scale)
		{
			Transform.Location = location;
			Transform.Scale = scale;
			return this;
		}

		public T? GetComponent<T>() where T : Component
		{
			return components.OfType<T>().FirstOrDefault();
		}

		public T[] GetComponents<T>() where T : Component
		{
			return components.OfType<T>().ToArray();
		}

		public void RemoveComponent(Component com)
		{
			components.Remove(com);
			com.Destroy();
			com.SetParent(null);
		}

		public void ClearComponents()
		{
			components.ToList().ForEach(RemoveComponent);
		}

		public void Update()
		{
			// 自分自身のコンポーネントをアップデートする
			Transform.OnUpdate();
			for (var i = 0; i < components.Count; i++)
			{
				if (!components[i].IsEnabled) continue;
				components[i].OnUpdate();
			}
			for (var i = 0; i < children.Count; i++)
			{
				if (!children[i].IsVisible) continue;
				children[i].Update();
			}
		}

		public void Render()
		{
			Transform.OnPreRender();
			for (var i = 0; i < components.Count; i++)
			{
				if (!components[i].IsEnabled) continue;
				components[i].OnPreRender();
			}

			Transform.OnRender();
			for (var i = 0; i < components.Count; i++)
			{
				if (!components[i].IsEnabled) continue;
				components[i].OnRender();
			}

			for (var i = 0; i < children.Count; i++)
			{
				if (!children[i].IsVisible) continue;
				children[i].Render();
			}

			Transform.OnPostRender();
			for (var i = 0; i < components.Count; i++)
			{
				if (!components[i].IsEnabled) continue;
				components[i].OnPostRender();
			}
		}

		public void Insert(int index, Element item)
		{
			if (children.Contains(item)) return;

			if (item.Parent != null && item.Parent != this)
			{
				// 親が自分では無いElementの場合、元の親から削除する
				item.Parent.Remove(item);
			}
			item.Parent = this;

			children.Insert(index, item);
		}

		public void Add(Element item)
		{
			if (item.IsDestroyed)
				throw new ObjectDestroyedException();

			if (children.Contains(item)) return;

			if (item.Parent != null && item.Parent != this)
			{
				// 親が自分では無いElementの場合、元の親から削除する
				item.Parent.Remove(item, true);
			}
			item.Parent = this;

			children.Add(item);
		}

		public void AddRange(IEnumerable<Element> items)
		{
			foreach (var item in items) Add(item);
		}

		public void Destroy()
		{
			if (Parent != null) Parent.children.Remove(this);
			Parent = null;
			IsDestroyed = true;
			ClearComponents();
			Clear();
		}

		public void Clear()
		{
			children.ToList().ForEach(c => c.Destroy());
			children.Clear();
		}

		public bool Remove(Element item)
		{
			return Remove(item, false);
		}

		internal bool Remove(Element item, bool preserve)
		{
			if (!children.Contains(item)) return false;
			if (!preserve) item.Destroy(); else children.Remove(item);
			return true;
		}

		public void RemoveAt(int index)
		{
			if (children.Count <= index) throw new ArgumentOutOfRangeException();
			Remove(children[index]);
		}

		public int IndexOf(Element item) => children.IndexOf(item);
		public bool Contains(Element item) => children.Contains(item);
		public IEnumerator<Element> GetEnumerator() => children.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private readonly List<Element> children = new List<Element>();
		internal readonly List<Component> components = new List<Component>();
	}
}
