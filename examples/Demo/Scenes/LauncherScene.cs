using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using static DotFeather.ComponentFactory;

namespace DotFeather.Demo
{
	public partial class LauncherScene : Scene
	{
		public override void OnStart(Dictionary<string, object> args)
		{
			BackgroundColor = Color.FromArgb(255, 32, 32, 32);
			var titleText = Text("title", "DotFeather", DFFont.GetDefault(56), Color.White)
				.Translate((24, 24))
				.GetComponent<TextRenderer>()!;
			Root.Add(titleText.Element!);

			var sampleProgramText = Text("version", $"Demo {DemoOS.VERSION}", DFFont.GetDefault(24), Color.White)
				.Translate((24 + titleText.Width + 8, 50));
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
	}
}
