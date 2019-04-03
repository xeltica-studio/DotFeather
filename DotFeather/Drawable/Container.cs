using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotFeather.Drawable
{
	public class Container : IDrawable, IList<IDrawable>
	{
		public int ZOrder { get; set; }
		public string Name { get; set; }
		public Vector Location { get; set; }
		public float Angle { get; set; }
		public Vector Scale { get; set; }

		private List<IDrawable> Children { get; } = new List<IDrawable>(10000);

		public IDrawable this[int index]
		{
			get => Children[index];
			set => Children[index] = value;
		}

		public void Draw(GameBase game, Vector location)
		{
			foreach (var child in Children.ToList())
				child.Draw(game, Location + location);
		}

		public void Sort() =>
			Children.Sort((d1, d2) => d1.ZOrder < d2.ZOrder ? -1 : d1.ZOrder > d2.ZOrder ? 1 : 0);

		public void Add(IDrawable child)
		{
			Sort();
			Children.Add(child);
		}

		public int IndexOf(IDrawable item) => Children.IndexOf(item);
		public void Insert(int index, IDrawable item)
		{
			Sort();
			Children.Insert(index, item);
		}
		public void RemoveAt(int index) => Children.RemoveAt(index);
		public void Clear() => Children.Clear();
		public bool Contains(IDrawable item) => Children.Contains(item);
		public void CopyTo(IDrawable[] array, int arrayIndex) => Children.CopyTo(array, arrayIndex);
		public bool Remove(IDrawable item) => Children.Remove(item);
		public IEnumerator<IDrawable> GetEnumerator() => Children.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
		public int Count => Children.Count;
		public bool IsReadOnly => false;
	}
}
