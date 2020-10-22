using OpenTK.Windowing.GraphicsLibraryFramework;

namespace DotFeather
{
    internal static class TypesConverterExtension
	{
		internal static DFKeyCode ToDF(this Keys key) => (DFKeyCode)(int)key;

		internal static Keys ToTK(this DFKeyCode key) => (Keys)(int)key;
	}
}
