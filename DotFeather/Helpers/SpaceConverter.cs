using System;
using OpenTK;

namespace DotFeather
{
	/// <summary>
	/// 座標系変換の為のメソッドを提供します。
	/// </summary>
	public static class SpaceConverter
	{
		/// <summary>
		/// スクリーン座標をViewport座標に変換します。
		/// </summary>
		public static Vector ToViewportPoint(this Vector dp, float halfWidth, float halfHeight)
			=> new Vector((dp.X - halfWidth) / halfWidth, -(dp.Y - halfHeight) / halfHeight);

		/// <summary>
		/// スクリーン座標をViewport座標に変換します。
		/// </summary>
		public static (float, float) ToViewportPoint(this (float, float) dp, float halfWidth, float halfHeight)
			=> ((dp.Item1 - halfWidth) / halfWidth, -(dp.Item2 - halfHeight) / halfHeight);
	}
}
