using System;
namespace DotFeather
{
	/// <summary>
	/// Two dimensional vector.
	/// </summary>
	public struct VectorInt : IEquatable<VectorInt>
	{
		/// <summary>
		/// Get or set X coordinate of this vector.
		/// </summary>
		public int X { get; set; }

		/// <summary>
		/// Get or set Y coordinate of this vector.
		/// </summary>
		public int Y { get; set; }

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
		public VectorInt(int x, int y)
		{
			(X, Y) = (x, y);
		}


		public static VectorInt operator +(VectorInt v1, VectorInt v2) => new VectorInt(v1.X + v2.X, v1.Y + v2.Y);

		public static VectorInt operator -(VectorInt v1, VectorInt v2) => new VectorInt(v1.X - v2.X, v1.Y - v2.Y);

		public static VectorInt operator *(VectorInt v1, int v2) => new VectorInt(v1.X * v2, v1.Y * v2);

		public static VectorInt operator *(VectorInt v1, VectorInt v2) => new VectorInt(v1.X * v2.X, v1.Y * v2.Y);

		public static VectorInt operator /(VectorInt v1, int v2) => new VectorInt(v1.X / v2, v1.Y / v2);

		public static VectorInt operator /(VectorInt v1, VectorInt v2) => new VectorInt(v1.X / v2.X, v1.Y / v2.Y);

		public static VectorInt operator -(VectorInt v1) => new VectorInt(-v1.X, -v1.Y);

		public static implicit operator Vector(VectorInt v1) => new Vector(v1.X, v1.Y);

		public static bool operator ==(VectorInt v1, VectorInt v2) => v1.X == v2.X && v1.Y == v2.Y;

		public static bool operator !=(VectorInt v1, VectorInt v2) => v1.X != v2.X || v1.Y != v2.Y;

		/// <summary>
		/// Get angle between 2 vectors.
		/// </summary>
		/// <returns>Radian angle between 2 vectors.</returns>
		public static float Angle(VectorInt from, VectorInt to) => MathF.Atan2(to.Y - from.Y, to.X - from.X);


		/// <summary>
		/// Get the distance between 2 vectors.
		/// </summary>
		public static float Distance(VectorInt from, VectorInt to) => MathF.Sqrt(
			MathF.Abs((to.X - from.X) * (to.X - from.X) + (to.Y - from.Y) * (to.Y - from.Y))
		);

		/// <summary>
		/// Compare this object.
		/// </summary>
		public override bool Equals(object obj)
		{
			return obj is VectorInt vec && Equals(vec);
		}

		/// <summary>
		/// Compare this object.
		/// </summary>
		public bool Equals(VectorInt other)
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
		public float Angle(VectorInt to) => Angle(this, to);

		/// <summary>
		/// Get the distance between two vectors.
		/// </summary>
		public float Distance(VectorInt to) => Distance(this, to);

		/// <summary>
		/// Deconstructs x and y.
		/// </summary>
		public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);

		/// <summary>
		/// Get formatted string of this vector.
		/// </summary>
		public override string ToString() => $"({X}, {Y})";

		/// <summary>
		/// Get <c>new VectorInt(0, 0)</c>.
		/// </summary>
		public static readonly VectorInt Zero = new VectorInt(0, 0);

		/// <summary>
		/// Get <c>new VectorInt(1, 1)</c>.
		/// </summary>
		public static readonly VectorInt One = new VectorInt(1, 1);

		/// <summary>
		/// Get <c>new VectorInt(-1, 0)</c>.
		/// </summary>
		public static readonly VectorInt Left = new VectorInt(-1, 0);

		/// <summary>
		/// Get <c>new VectorInt(0, -1)</c>.
		/// </summary>
		public static readonly VectorInt Up = new VectorInt(0, -1);

		/// <summary>
		/// Get <c>new VectorInt(1, 0)</c>.
		/// </summary>
		public static readonly VectorInt Right = new VectorInt(1, 0);

		/// <summary>
		/// Get <c>new VectorInt(0, 1)</c>.
		/// </summary>
		public static readonly VectorInt Down = new VectorInt(0, 1);
	}
}
