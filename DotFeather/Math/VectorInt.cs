using System;
namespace DotFeather
{
	/// <summary>
	/// 2次元のベクトルです。
	/// </summary>
	public struct VectorInt: IEquatable<VectorInt>
	{
		/// <summary>
		/// このベクトルの X 成分を取得または設定します。
		/// </summary>
		public int X { get; set; }

		/// <summary>
		/// このベクトルの Y 成分を取得または設定します。
		/// </summary>
		public int Y { get; set; }

		/// <summary>
		/// このベクトルの長さを取得します。
		/// </summary>
		public float Magnitude => MathF.Sqrt(X * X + Y * Y);

		/// <summary>
		/// このベクトルと向きが等しい単位ベクトルを取得します。
		/// </summary>
		public Vector Normalized => new Vector(X / Magnitude, Y / Magnitude);

		/// <summary>
		/// <see cref="VectorInt"/> クラスの新しいインスタンスを初期化します。"
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
		/// 2ベクトル間の角を取得します。
		/// </summary>
		/// <returns>2ベクトル間のラジアン。</returns>
		public static float Angle(VectorInt from, VectorInt to) => MathF.Atan2(to.Y - from.Y, to.X - from.X);


		/// <summary>
		/// 2ベクトル間の距離を取得します。
		/// </summary>
		public static float Distance(VectorInt from, VectorInt to) => MathF.Sqrt(
			MathF.Abs((to.X - from.X) * (to.X - from.X) + (to.Y - from.Y) * (to.Y - from.Y))
		);

		/// <summary>
		/// このオブジェクトを比較します。
		/// </summary>
		public override bool Equals(object obj)
		{
			return obj is VectorInt && Equals((VectorInt)obj);
		}

		/// <summary>
		/// このオブジェクトを比較します。
		/// </summary>
		public bool Equals(VectorInt other)
		{
			return X == other.X &&
				Y == other.Y;
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
		/// このベクトルの向きを取得します。
		/// </summary>
		public float Angle() => MathF.Atan2(Y, X);


		/// <summary>
		/// このベクトルを基準とした、指定したベクトルの向きを取得します。
		/// </summary>
		public float Angle(VectorInt to) => Angle(this, to);

		/// <summary>
		/// 2ベクトル間の距離を取得します。
		/// </summary>
		public float Distance(VectorInt to) => Distance(this, to);

		/// <summary>
		/// Deconstructs x and y.
		/// </summary>
		public void Deconstruct(out int x, out int y) => (x, y) = (X, Y);

		/// <summary>
		/// このベクトルの文字列表現を取得します。
		/// </summary>
		public override string ToString() => $"({X}, {Y})";

		/// <summary>
		/// <c>new VectorInt(0, 0)</c> を取得します。
		/// </summary>
		public static readonly VectorInt Zero = new VectorInt(0, 0);

		/// <summary>
		/// <c>new VectorInt(1, 1)</c> を取得します。
		/// </summary>
		public static readonly VectorInt One = new VectorInt(1, 1);

		/// <summary>
		/// <c>new VectorInt(-1, 0)</c> を取得します。
		/// </summary>
		public static readonly VectorInt Left = new VectorInt(-1, 0);

		/// <summary>
		/// <c>new VectorInt(0, -1)</c> を取得します。
		/// </summary>
		public static readonly VectorInt Up = new VectorInt(0, -1);

		/// <summary>
		/// <c>new VectorInt(1, 0)</c> を取得します。
		/// </summary>
		public static readonly VectorInt Right = new VectorInt(1, 0);

		/// <summary>
		/// <c>new VectorInt(0, 1)</c> を取得します。
		/// </summary>
		public static readonly VectorInt Down = new VectorInt(0, 1);


	}
}
