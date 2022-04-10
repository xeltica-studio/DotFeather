using System;
using System.Drawing;

namespace DotFeather
{
	/// <summary>
	/// Provides Game API.
	/// </summary>
	public interface IWindow
	{
		/// <summary>
		/// Get or set location of this game window.
		/// </summary>
		VectorInt Location { get; set; }

		/// <summary>
		/// Get or set size of this game window.
		/// </summary>
		VectorInt Size { get; set; }

		/// <summary>
		/// Get or set device-unit size of this game window.
		/// </summary>
		VectorInt ActualSize { get; [Obsolete("will be deleted in 4.0.0")] set; }

		/// <summary>
		/// Get or set X-coord location of this game window.
		/// </summary>
		int X { get; set; }

		/// <summary>
		/// Get or set Y-coord location of this game window.
		/// </summary>
		int Y { get; set; }

		/// <summary>
		/// Get or set width of this game window.
		/// </summary>
		int Width { get; set; }

		/// <summary>
		/// Get or set height of this game window.
		/// </summary>
		int Height { get; set; }

		/// <summary>
		/// Get or set device-unit width of this game window.
		/// </summary>
		int ActualWidth { get; [Obsolete("will be deleted in 4.0.0")] set; }

		/// <summary>
		/// Get or set device-unit height of this game window.
		/// </summary>
		int ActualHeight { get; [Obsolete("will be deleted in 4.0.0")] set; }

		/// <summary>
		/// Get or set whether this game window is visible.
		/// </summary>
		bool IsVisible { get; set; }

		/// <summary>
		/// Get or set whether this game window is focused.
		/// </summary>
		bool IsFocused { get; }

		/// <summary>
		/// Get or set whether this game window is fullscreen.
		/// </summary>
		bool IsFullScreen { get; set; }

		/// <summary>
		/// Get or set whether this game window is launched as a capture mode.
		/// </summary>
		bool IsCaptureMode { get; }

		[Obsolete("will be deleted in 4.0.0")]
		bool FollowsDpi { get; set; }

		/// <summary>
		/// Get or set total frame count after this game window starts.
		/// </summary>
		long TotalFrame { get; }

		/// <summary>
		/// Get or set refresh rate of this game window.
		/// </summary>
		int RefreshRate { get; }

		/// <summary>
		/// Get or set pixel ratio of this game window.
		/// </summary>
		float PixelRatio { get; }

		/// <summary>
		/// Get or set a title of this game window.
		/// </summary>
		string Title { get; set; }

		/// <summary>
		/// Get or set background color this game window is visible.
		/// </summary>
		Color BackgroundColor { get; set; }

		/// <summary>
		/// Get or set this game window mode.
		/// </summary>
		WindowMode Mode { get; set; }

		/// <summary>
		/// Take a screenshot and generate a texture from it.
		/// </summary>
		/// <returns>A screenshot as a texture</returns>
		Texture2D TakeScreenshot();

		/// <summary>
		/// Open this window and start game.
		/// </summary>
		void Run();

		/// <summary>
		/// Exit this game by the specified status code.
		/// </summary>
		void Exit();

		/// <summary>
		/// Occured when this game starts.
		/// </summary>
		event Action? Start;

		/// <summary>
		/// Occured when this game updates the frame.
		/// </summary>
		event Action? Update;

		/// <summary>
		/// Occured when this game renders the frame.
		/// </summary>
		event Action? Render;

		/// <summary>
		/// Occured before this game updates the frame.
		/// </summary>
		event Action? PreUpdate;

		/// <summary>
		/// Occured after this game updates the frame.
		/// </summary>
		event Action? PostUpdate;

		/// <summary>
		/// Occured when the user drops files into the window.
		/// </summary>
		event Action<DFFileDroppedEventArgs>? FileDropped;

		/// <summary>
		/// Occured when this game window resized.
		/// </summary>
		event Action? Resize;
	}
}
