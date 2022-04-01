using System;
using System.Drawing;
using SDColor = System.Drawing.Color;
using System.IO;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;

namespace DotFeather.Internal
{
	/// <summary>
	/// A implementation of <see cref="IWindow"/> for the desktop environment.
	/// </summary>
	internal sealed class DesktopWindow : IWindow
	{
		public VectorInt Location
		{
			get
			{
				Debug.NotImpl("DesktopWindow.Location get");
				return (0, 0);
			}
			set
			{
				Debug.NotImpl("DesktopWindow.Location set");
			}
		}

		public VectorInt Size
		{
			get => (VectorInt)((Vector)ActualSize / (FollowsDpi ? PixelRatio : 1));
			set => ActualSize = (VectorInt)((Vector)value * (FollowsDpi ? PixelRatio : 1));
		}

		public VectorInt ActualSize
		{
			get
			{
				Debug.NotImpl("DesktopWindow.ActualSize get");
				return (0, 0);
			}
			set
			{
				Debug.NotImpl("DesktopWindow.ActualSize set");
			}
		}

		public int X
		{
			get => Location.X;
			set => Location = (value, Y);
		}

		public int Y
		{
			get => Location.Y;
			set => Location = (X, value);
		}

		public int Width
		{
			get => Size.X;
			set => Size = (value, Height);
		}

		public int Height
		{
			get => Size.Y;
			set => Size = (Width, value);
		}

		public int ActualWidth
		{
			get => ActualSize.X;
			set => ActualSize = (value, ActualHeight);
		}

		public int ActualHeight
		{
			get => ActualSize.Y;
			set => ActualSize = (ActualWidth, value);
		}

		public bool IsVisible
		{
			get
			{
				Debug.NotImpl("DesktopWindow.IsVisible get");
				return true;
			}
			set
			{
				Debug.NotImpl("DesktopWindow.IsVisible set");
			}
		}

		public bool IsFocused
		{
			get
			{
				Debug.NotImpl("DesktopWindow.IsFocused get");
				return false;
			}
		}

		public bool IsFullScreen
		{
			get
			{
				Debug.NotImpl("DesktopWindow.IsFullScreen get");
				return false;
			}
			set
			{
				Debug.NotImpl("DesktopWindow.IsFullScreen set");
			}
		}

		public string Title
		{
			get
			{
				Debug.NotImpl("DesktopWindow.Title get");
				return "";
			}
			set
			{
				Debug.NotImpl("DesktopWindow.Title set");
			}
		}

		public bool IsCaptureMode { get; private set; }

		public bool FollowsDpi { get; set; } = true;

		public long TotalFrame { get; private set; }

		// todo ゲーム起動前に変更可能にする
		public int RefreshRate => 60;

		public float PixelRatio
		{
			get
			{
				Debug.NotImpl("DesktopWindow.IsFullScreen get");
				return 1;
			}
		}

		public SDColor BackgroundColor { get; set; }

		public WindowMode Mode
		{
			get
			{
				Debug.NotImpl("DesktopWindow.Mode get");
				return WindowMode.Fixed;
			}
			set
			{
				Debug.NotImpl("DesktopWindow.Mode set");
			}
		}

		internal DesktopWindow()
		{
			Debug.NotImpl("DesktopWindow.ctor");
			if (IsCaptureMode && !Directory.Exists("./shot"))
			{
				Directory.CreateDirectory("shot");
			}
		}

		public Texture2D TakeScreenshot()
		{
			Debug.NotImpl("DesktopWindow.TakeScreenshot");
			return default;
		}

		public void Run()
		{
			Debug.NotImpl("DesktopWindow.Run");
		}

		public void Exit()
		{
			Debug.NotImpl("DesktopWindow.Exit");
		}

		private void OnUnload(object s, EventArgs e)
		{
			Destroy?.Invoke();
		}

		public event Action? Start;
		public event Action? Update;
		public event Action? Render;
		public event Action? Destroy;
		public event Action<DFFileDroppedEventArgs>? FileDropped;
		public event Action? Resize;
		public event Action? PreUpdate;
		public event Action? PostUpdate;
	}
}
