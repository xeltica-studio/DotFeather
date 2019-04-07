using System;
namespace DotFeather
{
    /// <summary>
    /// 2次元のベクトルです。
    /// </summary>
	public struct Vector : IEquatable<Vector>
	{
        /// <summary>
        /// このベクトルの X 成分を取得または設定します。
        /// </summary>
		public float X { get; set; }
        /// <summary>
        /// このベクトルの Y 成分を取得または設定します。
        /// </summary>
		public float Y { get; set; }

        /// <summary>
        /// <see cref="Vector"/> クラスの新しいインスタンスを初期化します。"
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
		public Vector(float x, float y)
		{
			X = x;
			Y = y;
		}

		public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y);
		public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.X - v2.X, v1.Y - v2.Y);
		public static Vector operator *(Vector v1, float v2) => new Vector(v1.X * v2, v1.Y * v2);
		public static Vector operator /(Vector v1, float v2) => new Vector(v1.X / v2, v1.Y / v2);
		public static Vector operator -(Vector v1) => new Vector(-v1.X, -v1.Y);

#pragma warning disable RECS0018
		public static bool operator ==(Vector v1, Vector v2) => v1.X == v2.X && v1.Y == v2.Y;
		public static bool operator !=(Vector v1, Vector v2) => v1.X != v2.X || v1.Y != v2.Y;

		public override bool Equals(object obj)
		{
			return obj is Vector && Equals((Vector)obj);
		}

		public bool Equals(Vector other)
		{
			return X == other.X &&
				   Y == other.Y;
#pragma warning restore RECS0018
		}

		public override int GetHashCode()
		{
			var hashCode = 1861411795;
			hashCode = hashCode * -1521134295 + X.GetHashCode();
			hashCode = hashCode * -1521134295 + Y.GetHashCode();
			return hashCode;
		}

		public override string ToString() => $"({X}, {Y})";

		public static readonly Vector Zero = new Vector(0, 0);
		public static readonly Vector One = new Vector(1, 1);
	}
}
