using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace DotFeather.Demo
{
	public partial class LauncherScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			DF.Window.Mode = WindowMode.Resizable;
			BackgroundColor = Color.FromArgb(255, 32, 32, 32);
			TextElement titleText;

			Root.AddRange(
				titleText = new TextElement("DotFeather", DFFont.GetDefault(56), Color.White) { Location = (24, 24) },
				new TextElement("Demo " + DemoOS.VERSION, DFFont.GetDefault(24), Color.White) { Location = (24 + titleText.Width + 8, 50) },
				listView = new ListView { Location = (16, titleText.Location.Y + titleText.Height + 16) }
			);

			listView.ItemSelected += ItemSelected;

			ChangeDirectory(DemoOS.CurrentDirectory);
		}

		public override void OnUpdate()
		{
			Title = $"DotFeather Demo - {DemoOS.CurrentDirectory.Name.ToUpperInvariant()}";
			listView.Width = Window.Width - 32;
			listView.Height = Window.Height - 16 - (int)listView.Location.Y;
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

		private ListView listView;
	}
}
