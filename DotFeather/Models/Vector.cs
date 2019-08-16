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

		/// <summary></summary>
		public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y);
		/// <summary></summary>
		public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.X - v2.X, v1.Y - v2.Y);
		/// <summary></summary>
		public static Vector operator *(Vector v1, float v2) => new Vector(v1.X * v2, v1.Y * v2);
        /// <summary></summary>
        public static Vector operator *(Vector v1, Vector v2) => new Vector(v1.X * v2.X, v1.Y * v2.Y);
		/// <summary></summary>
		public static Vector operator /(Vector v1, float v2) => new Vector(v1.X / v2, v1.Y / v2);
        /// <summary></summary>
        public static Vector operator /(Vector v1, Vector v2) => new Vector(v1.X / v2.X, v1.Y / v2.Y);
		/// <summary></summary>
		public static Vector operator -(Vector v1) => new Vector(-v1.X, -v1.Y);

#pragma warning disable RECS0018
		/// <summary></summary>
		public static bool operator ==(Vector v1, Vector v2) => v1.X == v2.X && v1.Y == v2.Y;
		/// <summary></summary>
		public static bool operator !=(Vector v1, Vector v2) => v1.X != v2.X || v1.Y != v2.Y;

		/// <summary>
		/// このオブジェクトを比較します。
		/// </summary>
		public override bool Equals(object obj)
		{
			return obj is Vector && Equals((Vector)obj);
		}

		/// <summary>
		/// このオブジェクトを比較します。
		/// </summary>
		public bool Equals(Vector other)
		{
			return X == other.X &&
				   Y == other.Y;
#pragma warning restore RECS0018
		}

		/// <summary>
		/// このオブジェクトのハッシュ値を取得します。
		/// </summary>
		public override int GetHashCode()
		{
			var hashCode = 1861411795;
			hashCode = hashCode * -1521134295 + X.GetHashCode();
			hashCode = hashCode * -1521134295 + Y.GetHashCode();
			return hashCode;
		}

		/// <summary>
		/// このベクトルの文字列表現を取得します。
		/// </summary>
		public override string ToString() => $"({X}, {Y})";

		/// <summary>
		/// <c>new Vector(0, 0)</c> を取得します。
		/// </summary>
		public static readonly Vector Zero = new Vector(0, 0);

		/// <summary>
		/// <c>new Vector(1, 1)</c> を取得します。
		/// </summary>
		public static readonly Vector One = new Vector(1, 1);

		/// <summary>
		/// <c>new Vector(-1, 0)</c> を取得します。
		/// </summary>
		public static readonly Vector Left = new Vector(-1, 0);

		/// <summary>
		/// <c>new Vector(0, -1)</c> を取得します。
		/// </summary>
		public static readonly Vector Up = new Vector(0, -1);

		/// <summary>
		/// <c>new Vector(1, 0)</c> を取得します。
		/// </summary>
		public static readonly Vector Right = new Vector(1, 0);

		/// <summary>
		/// <c>new Vector(0, 1)</c> を取得します。
		/// </summary>
		public static readonly Vector Down = new Vector(0, 1);

		
	}
}
