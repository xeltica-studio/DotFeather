using System;
using System.Drawing;

namespace DotFeather
{
	/// <summary>
	/// Extend the random number generator.
	/// </summary>
	public static class RandomExtension
	{
		/// <summary>
		/// Get a random color.
		/// </summary>

		public static Color NextColor(this Random r, int max = 256) => Color.FromArgb(r.Next(max), r.Next(max), r.Next(max));

		/// <summary>
		/// Get a random vector. Both x and y coords are integers.
		/// </summary>
		public static Vector NextVector(this Random r, int xMax, int yMax) => (r.Next(xMax), r.Next(yMax));

		/// <summary>
		/// Get a random vector. Both x and y coords are integers.
		/// </summary>
		public static VectorInt NextVectorInt(this Random r, int xMax, int yMax) => (r.Next(xMax), r.Next(yMax));

		/// <summary>
		/// Get a random vector. Both x and y coords are real numbers.
		/// </summary>
		public static Vector NextVectorFloat(this Random r, int xMax = 1, int yMax = 1) => ((float)r.NextDouble() * xMax, (float)r.NextDouble() * yMax);
	}
}
