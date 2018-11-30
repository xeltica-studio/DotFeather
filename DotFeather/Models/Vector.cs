using System;
namespace DotFeather
{
	public struct Vector : IEquatable<Vector>
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Vector(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y);
		public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.X - v2.X, v1.Y - v2.Y);
		public static Vector operator *(Vector v1, int v2) => new Vector(v1.X * v2, v1.Y - v2);
		public static Vector operator /(Vector v1, int v2) => new Vector(v1.X / v2, v1.Y / v2);
		public static Vector operator -(Vector v1) => new Vector(-v1.X, -v1.Y);

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
