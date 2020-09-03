using System;

namespace DotFeather
{
	public static class VectorExtension
	{
		private static float Dpi => DF.Window.FollowsDpi ? DF.Window.PixelRatio : 1;
		public static Vector ToDeviceCoord(this Vector v)
			=> v * Dpi;

		public static Vector ToVirtualCoord(this Vector v)
			=> v / Dpi;

		public static VectorInt ToDeviceCoord(this VectorInt v)
			=> (VectorInt)((Vector)v * Dpi);

		public static VectorInt ToVirtualCoord(this VectorInt v)
			=> (VectorInt)((Vector)v / Dpi);
	}

}
