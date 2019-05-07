using System;
using System.Drawing;

namespace DotFeather
{
    /// <summary>
    /// 乱数生成機を拡張します。
    /// </summary>
    public static class RandomExtension
	{
		/// <summary>
		/// ランダムな色を取得します。
		/// </summary>

		public static Color NextColor(this Random r, int max = 256) => Color.FromArgb(r.Next(max), r.Next(max), r.Next(max));

		/// <summary>
		/// ランダムなベクトルを取得します。 x, y 成分はどちらも整数です。
		/// </summary>
        public static Vector NextVector(this Random r, int xMax, int yMax) => new Vector(r.Next(xMax), r.Next(yMax));

		/// <summary>
		/// ランダムなベクター値を取得します。 x, y 成分はどちらも実数です。
		/// </summary>
        public static Vector NextVectorFloat(this Random r, int xMax = 1, int yMax = 1) => new Vector((float)r.NextDouble() * xMax, (float)r.NextDouble() * yMax);
	}
}
