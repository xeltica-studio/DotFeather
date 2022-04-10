using System;
using System.Drawing;
using System.IO;

namespace DotFeather
{
	/// <summary>
	/// 画像ファイルを表示するタイルです。
	/// </summary>
	public class Tile : ITile
	{
		/// <summary>
		/// 描画されるテクスチャを取得します。
		/// </summary>
		public Texture2D Texture { get; private set; }

		/// <summary>
		/// アニメーションに使われるテクスチャの配列を取得します。
		/// </summary>
		public Texture2D[] Animations { get; private set; }

		/// <summary>
		/// アニメーションにおけるテクスチャ1枚あたりの描画時間を取得します。
		/// </summary>
		public double Interval { get; private set; }

		private readonly bool textureIsInternal;

		/// <summary>
		/// テクスチャを指定して、<see cref="Tile"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="texture">タイルとして描画されるテクスチャ。</param>
		public Tile(Texture2D texture)
			: this(texture, false) { }

		/// <summary>
		/// <see cref="Tile"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		protected Tile(Texture2D texture, bool b1)
			: this(new[] { texture }, 0)
		{
			textureIsInternal = b1;
		}

		/// <summary>
		/// テクスチャの配列とアニメーション時間を指定して、<see cref="Tile"/> クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="animations">アニメーション描画されるテクスチャの配列。</param>
		/// <param name="interval">アニメーションの時間。</param>
		/// <exception cref="ArgumentNullException">animations が <c>null</c> です。</exception>
		/// <exception cref="ArgumentException">animations の長さが <c>0</c> です。</exception>
		public Tile(Texture2D[] animations, double interval)
		{
			if (animations.Length < 1)
				throw new ArgumentException(null, nameof(animations));
			Animations = animations;
			Interval = interval;
			Texture = Animations[0];
		}

		/// <summary>
		///
		/// </summary>
		public void Draw(Tilemap map, VectorInt _, Vector locationToDraw, Color? color)
		{
			if (prevFrameCount != DF.Window.TotalFrame)
			{
				if (timer > Interval)
				{
					animationState++;
					if (animationState >= Animations.Length)
						animationState = 0;
					timer = 0;
				}

				Texture = Animations[animationState];
				timer += Time.DeltaTime;
			}
			prevFrameCount = DF.Window.TotalFrame;
			DF.TextureDrawer.Draw(Texture, locationToDraw, map.AbsoluteScale, color);
		}

		/// <summary>
		/// 画像ファイルを指定して、タイルを生成します。
		/// </summary>
		/// <param name="path">ファイルパス。</param>
		/// <returns>生成されたタイル。</returns>
		public static Tile LoadFrom(string path) => new(Texture2D.LoadFrom(path), true);

		/// <summary>
		/// 画像ファイルを指定して、タイルを生成します。
		/// </summary>
		/// <param name="stream">ファイルを示すストリーム。</param>
		/// <returns>生成されたタイル。</returns>
		public static Tile LoadFrom(Stream stream) => new(Texture2D.LoadFrom(stream), true);

		/// <summary>
		/// この <see cref="Tile"/> を削除します。
		/// </summary>
		public void Destroy()
		{
			if (textureIsInternal)
				Texture.Dispose();
		}

		private int animationState;
		private double timer;
		private long prevFrameCount = -1;
	}
}
