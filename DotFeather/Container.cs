using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DotFeather
{
	/// <summary>
	/// 他の <see cref="IDrawable"/> オブジェクトを格納し、相対位置に描画するオブジェクトです。
	/// </summary>
	public class Container : IDrawable, IList<IDrawable>
	{
		/// <summary>
		/// この <see cref="T:DotFeather.Drawable.IDrawable"/> の描画優先順位を取得または設定します。数値が低いほど奥に描画されます。
		/// </summary>
		public int ZOrder { get; set; }

		/// <summary>
		/// この <see cref="T:DotFeather.Drawable.IDrawable"/> の名前を取得または設定します。
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// この <see cref="T:DotFeather.Drawable.IDrawable"/> の座標を取得または設定します。
		/// </summary>
		public Vector Location { get; set; }

		/// <summary>
		/// この <see cref="T:DotFeather.Drawable.IDrawable"/> の角度を取得または設定します。
		/// </summary>
		public float Angle { get; set; }

		/// <summary>
		/// この <see cref="T:DotFeather.Drawable.IDrawable"/> のスケーリングを取得または設定します。
		/// </summary>
		public Vector Scale { get; set; }

		/// <summary>
		/// このコンテナーの子要素にアクセスします。
		/// </summary>
		/// <param name="index">インデックス。</param>
		/// <returns>子要素</returns>
		public IDrawable this[int index]
		{
			get => Children[index];
			set => Children[index] = value;
		}

		/// <summary>
		/// コンテナをソートします。
		/// </summary>
		public void Sort() =>
			Children.Sort((d1, d2) => d1.ZOrder < d2.ZOrder ? -1 : d1.ZOrder > d2.ZOrder ? 1 : 0);

		/// <summary>
		/// このコンテナに子要素を追加します。
		/// </summary>
		/// <param name="child">子要素。</param>
		public void Add(IDrawable child)
		{
			Sort();
			Children.Add(child);
		}

		/// <summary>
		/// このコンテナに子要素を挿入します。
		/// </summary>
		/// <param name="index">挿入先の位置。</param>
		/// <param name="item">子要素。</param>
		public void Insert(int index, IDrawable item)
		{
			Sort();
			Children.Insert(index, item);
		}

		/// <summary>
		/// 描画を開始します。
		/// </summary>
		public void Draw(GameBase game, Vector location)
		{
			foreach (var child in Children.ToList())
				child.Draw(game, Location + location);
		}

		/// <summary>
		/// この <see cref="Container"/> を破棄します。
		/// </summary>
		public void Destroy() => Children.ForEach(e => e.Destroy());

        /// <summary>
        /// 列挙子を取得します。
        /// </summary>
        public IEnumerator<IDrawable> GetEnumerator() => Children.GetEnumerator();

		#region other IList<T> members
		int IList<IDrawable>.IndexOf(IDrawable item) => Children.IndexOf(item);
		void IList<IDrawable>.RemoveAt(int index) => Children.RemoveAt(index);
		void ICollection<IDrawable>.Clear() => Children.Clear();
		bool ICollection<IDrawable>.Contains(IDrawable item) => Children.Contains(item);
		void ICollection<IDrawable>.CopyTo(IDrawable[] array, int arrayIndex) => Children.CopyTo(array, arrayIndex);
		bool ICollection<IDrawable>.Remove(IDrawable item) => Children.Remove(item);
		IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();
		int ICollection<IDrawable>.Count => Children.Count;
		bool ICollection<IDrawable>.IsReadOnly => false;
		#endregion

		private List<IDrawable> Children { get; } = new List<IDrawable>(10000);
    }
}
