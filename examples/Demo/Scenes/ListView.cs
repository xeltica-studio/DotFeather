using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace DotFeather.Demo
{
	public partial class LauncherScene
	{
		public class ListView : Container
		{
			public ObservableCollection<ListViewItem> Items { get; } = new ObservableCollection<ListViewItem>();

			public int ItemHeight
			{
				get => itemHeight;
				set
				{
					itemHeight = value;
					UpdateList();
				}
			}

			public int Padding
			{
				get => padding;
				set
				{
					padding = value;
					UpdateList();
				}
			}

			public ListView(IEnumerable<ListViewItem>? items = null)
			{
				if (items != null)
					Items = new ObservableCollection<ListViewItem>(items);
				Items.CollectionChanged += (_, __) => UpdateList();

				var t = Texture2D.CreateSolid(Color.FromArgb(24, 24, 24), 1, 1);
				backdrop = new Sprite(t);
				inner = new Container();
				Add(backdrop);
				Add(inner);
				IsTrimmable = true;
			}

			public void BeginUpdating() => isUpdating = true;

			public void EndUpdating()
			{
				if (isUpdating)
				{
					isUpdating = false;
					UpdateList();
				}
			}

			protected override void OnUpdate()
			{
				base.OnUpdate();

				backdrop.Size = inner.Size = Size;

				var (mx, my) = DFMouse.Position;
				var (x, y) = Location;

				// 範囲外なら無視
				if (!DFMouse.Position.In(Location, Size)) return;

				var innerY = inner.Location.Y; ;

				if (landingPoint == null)
				{
					innerY += DFMouse.Scroll.Y * 1.5f;
				}

				if (DFMouse.IsLeftDown)
				{
					landingPoint = DFMouse.Position;
					landingScrollY = (int)inner.Location.Y;
				}
				if (landingPoint is Vector v)
				{
					// 内部でマウスを押下している状態
					innerY = landingScrollY + (my - v.Y);
					if (DFMouse.IsLeftUp)
					{
						landingPoint = null;
						if (v.Distance(DFMouse.Position) < 2)
						{
							for (var i = 0; i < Items.Count; i++)
							{
								var elHeight = ItemHeight + padding + 16;
								var ely = y + i * elHeight + padding + inner.Location.Y;
								if (ely <= my && my <= ely + elHeight)
									ItemSelected?.Invoke(i, Items[i]);
							}
						}
					}
				}

				if (innerY < -(padding + (ItemHeight + padding + 16) * Items.Count) + Height)
					innerY = -(padding + (ItemHeight + padding + 16) * Items.Count) + Height;

				if (innerY > 0)
					innerY = 0;

				inner.Location = new Vector(inner.Location.X, innerY);
			}

			private void UpdateList()
			{
				if (isUpdating)
					return;

				inner.Clear();
				var y = padding;
				foreach (var item in Items)
				{
					var text = new TextElement(item.Text, DFFont.GetDefault(ItemHeight), Color.White) { Location = (padding + ItemHeight + padding, y) };
					inner.Add(text);

					y += ItemHeight;

					if (item.Description != null)
					{
						y += 4;
						var desc = new TextElement(item.Description, DFFont.GetDefault(12), Color.LightGray) { Location = (text.Location.X, y) };
						inner.Add(desc);
						y += 12;
					}
					else
					{
						y += 16;
					}
					y += padding;
				}
			}

			public event ItemSelectedEventHandler? ItemSelected;

			private int itemHeight = 24;

			private int padding = 8;
			private Vector? landingPoint;
			private int landingScrollY;
			private bool isUpdating = false;
			private readonly Sprite backdrop;
			private readonly Container inner;

			public delegate void ItemSelectedEventHandler(int index, ListViewItem item);
		}
	}
}
