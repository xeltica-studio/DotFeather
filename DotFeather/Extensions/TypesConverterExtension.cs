using System;
using System.Drawing;
using OpenToolkit.Windowing.Common.Input;

namespace DotFeather
{
	internal static class TypesConverterExtension
	{
		internal static DFKeyCode ToDF(this Key key) => (DFKeyCode)(int)key;

		internal static Key ToTK(this DFKeyCode key) => (Key)(int)key;
	}
}
