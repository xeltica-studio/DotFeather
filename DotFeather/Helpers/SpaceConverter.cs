using System;
using OpenTK;

namespace DotFeather
{
	public static class SpaceConverter
	{
		public static Vector2 ToViewportPoint(this Vector2 dp, float halfWidth, float halfHeight) 
			=> new Vector2((int)((dp.X - halfWidth) / halfWidth), (int)(-(dp.Y - halfHeight) / halfHeight));
	}
}
