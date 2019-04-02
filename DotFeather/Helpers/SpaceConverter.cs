using System;
using OpenTK;

namespace DotFeather
{
	public static class SpaceConverter
	{
		public static Vector2 ToViewportPoint(this Vector2 dp, float halfWidth, float halfHeight) 
			=> new Vector2((dp.X - halfWidth) / halfWidth, -(dp.Y - halfHeight) / halfHeight);

		public static (float, float) ToViewportPoint(this (float, float) dp, float halfWidth, float halfHeight)
			=> ((dp.Item1 - halfWidth) / halfWidth, -(dp.Item2 - halfHeight) / halfHeight);
	}
}
