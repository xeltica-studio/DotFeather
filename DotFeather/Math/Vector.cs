using System;
namespace DotFeather
{
	/// <summary>
	/// Two dimensional vector.
	/// </summary>
	public struct Vector : IEquatable<Vector>
	{
		/// <summary>
		/// Get or set X coordinate of this vector.
		/// </summary>
		public float X { get; set; }

		/// <summary>
		/// Get or set Y coordinate of this vector.
		/// </summary>
		public float Y { get; set; }

		/// <summary>
		/// Get length of this vector.
		/// </summary>
		public float Magnitude => MathF.Sqrt(X * X + Y * Y);

		/// <summary>
		/// Get a unit vector with the same orientation as this vector.
		/// </summary>
		public Vector Normalized => new Vector(X / Magnitude, Y / Magnitude);

		/// <summary>
		/// Initialize a new instance of <see cref="Vector"/> class.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Vector(float x, float y)
		{
			(X, Y) = (x, y);
		}

		public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y);

		public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.X - v2.X, v1.Y - v2.Y);

		public static Vector operator *(Vector v1, float v2) => new Vector(v1.X * v2, v1.Y * v2);

		public static Vector operator *(Vector v1, Vector v2) => new Vector(v1.X * v2.X, v1.Y * v2.Y);

		public static Vector operator /(Vector v1, float v2) => new Vector(v1.X / v2, v1.Y / v2);

		public static Vector operator /(Vector v1, Vector v2) => new Vector(v1.X / v2.X, v1.Y / v2.Y);

		public static Vector operator -(Vector v1) => new Vector(-v1.X, -v1.Y);

		public static bool operator ==(Vector v1, Vector v2) => v1.X == v2.X && v1.Y == v2.Y;

		public static bool operator !=(Vector v1, Vector v2) => v1.X != v2.X || v1.Y != v2.Y;

		public static explicit operator VectorInt(Vector v1) => new VectorInt((int)v1.X, (int)v1.Y);

		/// <summary>
		/// Get angle between 2 vectors.
		/// </summary>
		/// <returns>Radian angle between 2 vectors.</returns>
		public static float Angle(Vector from, Vector to) => MathF.Atan2(to.Y - from.Y, to.X - from.X);


		/// <summary>
		/// Get the distance between 2 vectors.
		/// </summary>
		public static float Distance(Vector from, Vector to) => MathF.Sqrt(
			MathF.Abs((to.X - from.X) * (to.X - from.X) + (to.Y - from.Y) * (to.Y - from.Y))
		);

		/// <summary>
		/// Compare this object.
		/// </summary>
		public override bool Equals(object obj)
		{
			return obj is Vector && Equals((Vector)obj);
		}

		/// <summary>
		/// Compare this object.
		/// </summary>
		public bool Equals(Vector other)
		{
			return X == other.X &&
				Y == other.Y;
		}

		/// <summary>
		/// Get the hash value of this object.
		/// </summary>
		public override int GetHashCode()
		{
			var hashCode = 1861411795;
			hashCode = hashCode * -1521134295 + X.GetHashCode();
			hashCode = hashCode * -1521134295 + Y.GetHashCode();
			return hashCode;
		}

		/// <summary>
		/// Get angle of this vector.
		/// </summary>
		public float Angle() => MathF.Atan2(Y, X);


		/// <summary>
		/// Get the direction of the specified vector relative to this vector.
		/// </summary>
		public float Angle(Vector to) => Angle(this, to);

		/// <summary>
		/// Get the distance between two vectors.
		/// </summary>
		public float Distance(Vector to) => Distance(this, to);

		/// <summary>
		/// Deconstructs x and y.
		/// </summary>
		public void Deconstruct(out float x, out float y) => (x, y) = (X, Y);

		/// <summary>
		/// Get formatted string of this vector.
		/// </summary>
		public override string ToString() => $"({X}, {Y})";

		/// <summary>
		/// Get <c>new Vector(0, 0)</c> .
		/// </summary>
		public static readonly Vector Zero = new Vector(0, 0);

		/// <summary>
		/// Get <c>new Vector(1, 1)</c> .
		/// </summary>
		public static readonly Vector One = new Vector(1, 1);

		/// <summary>
		/// Get <c>new Vector(-1, 0)</c> .
		/// </summary>
		public static readonly Vector Left = new Vector(-1, 0);

		/// <summary>
		/// Get <c>new Vector(0, -1)</c> .
		/// </summary>
		public static readonly Vector Up = new Vector(0, -1);

		/// <summary>
		/// Get <c>new Vector(1, 0)</c> .
		/// </summary>
		public static readonly Vector Right = new Vector(1, 0);

		/// <summary>
		/// Get <c>new Vector(0, 1)</c> .
		/// </summary>
		public static readonly Vector Down = new Vector(0, 1);


	}
}
