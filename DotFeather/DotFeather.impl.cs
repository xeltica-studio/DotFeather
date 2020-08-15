using OpenTK;
using OpenTK.Graphics;

namespace DotFeather
{
	public static partial class DotFeather
	{
		static DotFeather()
		{
			window = new GameWindow(640, 480, GraphicsMode.Default, "DotFeather Window", GameWindowFlags.FixedWindow)
			{
				VSync = VSyncMode.Adaptive,
				TargetRenderFrequency = 60,
				TargetUpdateFrequency = 60,
			};
		}
	}
}
