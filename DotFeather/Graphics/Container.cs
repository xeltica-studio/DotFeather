using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenTK.Graphics.OpenGL;

namespace DotFeather
{
	/// <summary>
	/// 他の <see cref="IDrawable"/> オブジェクトを格納し、相対位置に描画するオブジェクトです。
	/// </summary>
	public class Container : ISizedDrawable, IContainable, IUpdatable, IList<IDrawable>
	{
		/// <summary>
		/// この <see cref="T:DotFeather.Drawable.IDrawable"/> の描画優先順位を取得または設定します。数値が低いほど奥に描画されます。
		/// </summary>
		public int ZOrder { get; set; }

		/// <summary>
		/// この <see cref="T:DotFeather.Drawable.IDrawable"/> の名前を取得または設定します。
		/// </summary>
		public string Name { get; set; } = "";

		/// <summary>
		/// この <see cref="T:DotFeather.Drawable.IDrawable"/> の座標を取得または設定します。
		/// </summary>
		public Vector Location { get; set; }

		/// <summary>
		/// この <see cref="T:DotFeather.Drawable.IDrawable"/> の角度を取得または設定します。
		/// </summary>
		public float Angle { get; set; }

		/// <summary>
		/// Get or set scale of this <see cref="T:DotFeather.Drawable.IDrawable"/>.
		/// </summary>
		public Vector Scale { get; set; } = Vector.One;

		/// <summary>
		/// Get or set width of this <see cref="T:DotFeather.Drawable.IDrawable"/>.
		/// </summary>
		public int Width { get; set; } = 256;

		/// <summary>
		/// Get or set height of this <see cref="T:DotFeather.Drawable.IDrawable"/>.
		/// </summary>
		public int Height { get; set; } = 256;

		/// <summary>
		/// Get or set whether this container is trimmable. If true, this container draws children with trimming within rectangular range of this container.
		/// </summary>
		public bool IsTrimmable { get; set; }

		float ISizedDrawable.Width
		{
			get => Width;
			set => Width = (int)value;
		}

		float ISizedDrawable.Height
		{
			get => Height;
			set => Height = (int)value;
		}

		/// <summary>
		/// Get a parent of this drawable.
		/// </summary>
		public IContainable? Parent { get; internal set; }

		IContainable? IContainable.Parent
		{
			get => Parent;
			set => Parent = value;
		}

		/// <summary>
		/// 列挙子を取得します。
		/// </summary>
		IEnumerator IEnumerable.GetEnumerator() => Children.GetEnumerator();

		/// <summary>
		/// 要素数を取得します。
		/// </summary>
		public int Count => Children.Count;

		/// <summary>
		/// Get absolute location.
		/// </summary>
		public Vector AbsoluteLocation => Location + (Parent?.AbsoluteLocation ?? Vector.Zero);

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
		public void Sort() => Children.Sort((d1, d2) => d1.ZOrder != d2.ZOrder ? d1.ZOrder - d2.ZOrder : countMap[d1] - countMap[d2]);

		/// <summary>
		/// このコンテナに子要素を追加します。
		/// </summary>
		/// <param name="child">子要素。</param>
		public void Add(IDrawable child)
		{
			if (Contains(child)) return;
			countMap[child] = count++;
			if (child is IContainable c) c.Parent = this;
			Children.Add(child);
			Sort();
		}

		/// <summary>
		/// このコンテナに子要素を複数追加します。
		/// </summary>
		/// <param name="children">子要素。</param>
		public void AddRange(IEnumerable<IDrawable> children)
		{
			foreach (var child in children)
			{
				if (Contains(child)) continue;
				countMap[child] = count++;
				if (child is IContainable c) c.Parent = this;
				Children.Add(child);
			}
			Sort();
		}

		/// <summary>
		/// このコンテナに子要素を挿入します。
		/// </summary>
		/// <param name="index">挿入先の位置。</param>
		/// <param name="item">子要素。</param>
		public void Insert(int index, IDrawable item)
		{
			if (Contains(item)) return;
			if (item is IContainable c) c.Parent = this;
			Children.Insert(index, item);
		}

		/// <summary>
		/// 描画を開始します。
		/// </summary>
		public virtual void Draw(GameBase game, Vector location)
		{
			if (IsTrimmable)
			{
				GL.Enable(EnableCap.ScissorTest);
				var left = (VectorInt)(Location + location);
				var size = (VectorInt)(new Vector(Width, Height) * Scale);

				if (left.X < 0) left.X = 0;
				if (left.Y < 0) left.Y = 0;

				if (left.X + size.X > game.ActualWidth)
					size.X = left.X + size.X - game.ActualWidth;

				if (left.Y + size.Y > game.ActualHeight)
					size.Y = left.Y + size.Y - game.ActualHeight;

				left.Y = game.ActualHeight - left.Y - size.Y;

				GL.Scissor(left.X, left.Y, size.X, size.Y);
			}

			for (var i = 0; i < Count; i++)
			{
				if (Count - 1 < i)
					continue;
				// 位置を調整
				var baseLoc = this[i].Location;
				var baseScale = this[i].Scale;
				this[i].Scale *= Scale;
				this[i].Location *= Scale;

				this[i].Draw(game, Location + location);

				// 戻す
				this[i].Scale = baseScale;
				this[i].Location = baseLoc;
			}

			if (IsTrimmable)
			{
				GL.Scissor(0, 0, game.ActualWidth, game.ActualHeight);
				GL.Disable(EnableCap.ScissorTest);
			}
		}

		public virtual void OnUpdate(GameBase game)
		{
			this.OfType<IUpdatable>().ToList().ForEach(u => u.OnUpdate(game));
		}

		/// <summary>
		/// この <see cref="Container"/> を破棄します。
		/// </summary>
		public virtual void Destroy() => Clear();

		/// <summary>
		/// 列挙子を取得します。
		/// </summary>
		public IEnumerator<IDrawable> GetEnumerator() => Children.GetEnumerator();

		#region other inherited members
		/// <summary>
		/// 指定した要素の位置を取得します。
		/// </summary>
		public int IndexOf(IDrawable item) => Children.IndexOf(item);

		/// <summary>
		/// 指定した位置にあるオブジェクトを削除します。
		/// </summary>
		public void RemoveAt(int index)
		{
			if (Children.Count <= index) return;
			countMap.Remove(Children[index]);
			Children.RemoveAt(index);
			Sort();
		}

		/// <summary>
		/// オブジェクトを削除します。
		/// </summary>
		public void Clear()
		{
			countMap.Clear();
			Children.Clear();
		}

		/// <summary>
		/// 指定したオブジェクトが存在するかどうかを判断します。
		/// </summary>
		public bool Contains(IDrawable item) => Children.Contains(item);

		/// <summary>
		/// 指定した配列およびその位置に、要素をコピーします。
		/// </summary>
		public void CopyTo(IDrawable[] array, int arrayIndex) => Children.CopyTo(array, arrayIndex);

		/// <summary>
		/// 指定したオブジェクトを削除します。
		/// </summary>
		public bool Remove(IDrawable item)
		{
			if (!Children.Contains(item)) return false;
			var res = Children.Remove(item);
			countMap.Remove(item);
			Sort();
			return res;
		}

		/// <summary>
		/// 読み取り専用かどうかを示す値を取得します。
		/// </summary>
		public bool IsReadOnly => false;
		#endregion

		private List<IDrawable> Children { get; } = new List<IDrawable>(10000);
		private readonly Dictionary<IDrawable, int> countMap = new Dictionary<IDrawable, int>();

		private int count = 0;
	}
}
