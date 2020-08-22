using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using static DotFeather.ComponentFactory;

namespace DotFeather.Demo
{
	public class LauncherScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			BackgroundColor = Color.FromArgb(255, 32, 32, 32);
			var titleText = Text("title", "DotFeather", DFFont.GetDefault(56), Color.White)
				.With((24, 24))
				.GetComponent<TextRenderer>()!;
			Root.Add(titleText.Element!);

			var sampleProgramText = Text("version", $"Demo {DemoOS.VERSION}", DFFont.GetDefault(24), Color.White)
				.With((24 + titleText.Width + 8, 50));
			Root.Add(sampleProgramText);

			var lv = new Element("listView").With(listView);

			Root.Add(lv);
			listView.ItemSelected += ItemSelected;
			lv.Transform.Location = new Vector(16, titleText.Transform!.Location.Y + titleText.Height + 16);

			ChangeDirectory(DemoOS.CurrentDirectory);
		}

		public override void OnUpdate()
		{
			Title = $"DotFeather Demo - {DemoOS.CurrentDirectory.Name.ToUpperInvariant()}";
			listView.Width = Window.Width - 32;
			listView.Height = Window.Height - 16 - (int)listView.Transform!.Location.Y;
		}

		public void ItemSelected(int i, ListViewItem item)
		{
			var parent = DemoOS.CurrentDirectory.Parent;
			if (parent != null && i == 0)
			{
				ChangeDirectory(parent);
			}
			else
			{
				var el = DemoOS.CurrentDirectory.Files[parent != null ? i - 1 : i];
				switch (el)
				{
					case Folder f:
						ChangeDirectory(f);
						break;
					case SceneFile f:
						Router.ChangeScene(f.Scene);
						break;
				}
			}
		}

		public void ChangeDirectory(Folder folder)
		{
			DemoOS.CurrentDirectory = folder;
			listView.BeginUpdating();
			listView.Items.Clear();
			if (folder.Parent != null)
			{
				listView.Items.Add(new ListViewItem("← ..", folder.Parent.Name.ToUpperInvariant()));
			}

			folder.Files.ForEach(el => listView.Items.Add(el switch
			{
				Folder folder => new ListViewItem(folder.Name.ToUpperInvariant()),
				SceneFile file => new ListViewItem(file.Name.ToUpperInvariant(), file.Description[CultureInfo.CurrentCulture.TwoLetterISOLanguageName]),
				_ => new ListViewItem(el.Name),
			}));
			listView.EndUpdating();
		}

		private readonly ListView listView = new ListView();

		public class ListView : Component
		{
			public ObservableCollection<ListViewItem> Items { get; } = new ObservableCollection<ListViewItem>();

			public int Width { get; set; }
			public int Height { get; set; }

			public int ItemHeight
			{
				get => itemHeight;
				set
				{
					ItemHeight = value;
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
			}

			public override void OnStart()
			{
				var t = Texture2D.CreateSolid(Color.FromArgb(24, 24, 24), 1, 1);
				var bd = Sprite("backdrop", t);
				backdrop = bd.GetComponent<SpriteRenderer>()!;
				inner = new Element("inner");
				Element!.Add(bd);
				Element!.Add(inner);
				trimmer = new Trimmer(Width, Height);
				AddComponent(trimmer);
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

			public override void OnUpdate()
			{
				if (Transform == null) return;
				base.OnUpdate();

				backdrop.Width = trimmer.Width = Width;
				backdrop.Height = trimmer.Height = Height;

				var (mx, my) = DFMouse.Position;
				var (x, y) = Transform.Location;

				// 範囲外なら無視
				if (!Intersects(DFMouse.Position, Transform.Location, Transform.Location + (Width, Height))) return;

				var innerY = inner.Transform.Location.Y;

				if (landingPoint == null)
				{
					innerY += DFMouse.Scroll.Y * 1.5f;
				}

				if (DFMouse.IsLeftDown)
				{
					landingPoint = DFMouse.Position;
					landingScrollY = (int)inner.Transform.Location.Y;
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
								var ely = y + i * elHeight + padding + inner.Transform.Location.Y;
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

				inner.Transform.Location = new Vector(inner.Transform.Location.X, innerY);
			}

			private bool Intersects(Vector point, Vector topLeft, Vector bottomRight)
			{
				var (px, py) = point;
				var (tlx, tly) = topLeft;
				var (brx, bry) = bottomRight;

				return tlx <= px && tly <= py && px <= brx && py <= bry;
			}

			private void UpdateList()
			{
				if (isUpdating)
					return;

				inner.Clear();
				var y = padding;
				foreach (var item in Items)
				{
					var text = Text(item.Text, item.Text, DFFont.GetDefault(ItemHeight), Color.White).With(new Vector(padding + ItemHeight + padding, y));
					inner.Add(text);

					y += ItemHeight;

					if (item.Description != null)
					{
						y += 4;
						var desc = Text("a desc of " + item.Text, item.Description, DFFont.GetDefault(12), Color.LightGray).With(new Vector(text.Transform.Location.X, y));
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

			private int padding = 8;
			private Vector? landingPoint;
			private int landingScrollY;
			private bool isUpdating = false;
			private SpriteRenderer backdrop;
			private readonly int itemHeight = 24;
			private Element inner;
			private Trimmer trimmer;

			public delegate void ItemSelectedEventHandler(int index, ListViewItem item);
		}

		public class ListViewItem
		{
			// public Texture2D? Icon { get; set; }
			public string Text { get; set; }
			public string? Description { get; set; }

			public ListViewItem(string text, string? description = null) => (Text, Description) = (text, description);
		}
	}
}
