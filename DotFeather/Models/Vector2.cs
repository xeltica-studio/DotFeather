using System;
namespace DotFeather
{
	public struct Vector2 : IEquatable<Vector2>
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Vector2(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static Vector2 operator +(Vector2 v1, Vector2 v2) => new Vector2(v1.X + v2.X, v1.Y + v2.Y);
		public static Vector2 operator -(Vector2 v1, Vector2 v2) => new Vector2(v1.X - v2.X, v1.Y - v2.Y);
		public static Vector2 operator *(Vector2 v1, int v2) => new Vector2(v1.X * v2, v1.Y - v2);
		public static Vector2 operator /(Vector2 v1, int v2) => new Vector2(v1.X / v2, v1.Y / v2);
		public static Vector2 operator -(Vector2 v1) => new Vector2(-v1.X, -v1.Y);

		public static bool operator ==(Vector2 v1, Vector2 v2) => v1.X == v2.X && v1.Y == v2.Y;
		public static bool operator !=(Vector2 v1, Vector2 v2) => v1.X != v2.X || v1.Y != v2.Y;

		public override bool Equals(object obj)
		{
			return obj is Vector2 && Equals((Vector2)obj);
		}

		public bool Equals(Vector2 other)
		{
			return X == other.X &&
				   Y == other.Y;
		}

		public override int GetHashCode()
		{
			var hashCode = 1861411795;
			hashCode = hashCode * -1521134295 + X.GetHashCode();
			hashCode = hashCode * -1521134295 + Y.GetHashCode();
			return hashCode;
		}
	}
}
