using System;
using System.Drawing;

namespace DotFeather
{
	public interface IWindow
	{
		VectorInt Location { get; set; }
		VectorInt Size { get; set; }
		int X { get; set; }
		int Y { get; set; }
		int Width { get; set; }
		int Height { get; set; }
		int ActualWidth { get; set; }
		int ActualHeight { get; set; }
		bool IsVisible { get; set; }
		bool IsFocused { get; set; }
		bool IsFullScreen { get; set; }
		bool IsCaptureMode { get; set; }
		bool FollowsDpi { get; set; }
		long TotalFrame { get; }
		int RefreshRate { get; }
		float Dpi { get; }
		string Title { get; set; }
		Color BackgroundColor { get; set; }
		WindowMode WindowMode { get; set; }

		Texture2D TakeScreenshot();

		event Action Start;
		event Action Update;
		event EventHandler<DFFileDroppedEventArgs> FileDropped;
		event Action Resize;
	}
}
