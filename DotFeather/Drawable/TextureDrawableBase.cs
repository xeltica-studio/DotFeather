using System.Drawing;

namespace DotFeather
{
	/// <summary>
	/// <see cref="Texture2D"/> を描画するオブジェクトの抽象クラスです。
	/// </summary>
    public abstract class TextureDrawableBase : IDrawable
    {
		/// <summary>
		/// 描画の優先順位を取得または設定します。数が小さいほど奥に描画されます。
		/// </summary>
        public virtual int ZOrder { get; set; }

        /// <summary>
		/// このオブジェクトの名前を取得または設定します。
		/// </summary>
        public virtual string Name { get; set; }

        /// <summary>
		/// このオブジェクトの座標を取得または設定します。
		/// </summary>
        public virtual Vector Location { get; set; }

        /// <summary>
		/// このオブジェクトの角度を取得または設定します。
		/// </summary>
        public virtual float Angle { get; set; }

        /// <summary>
		/// このオブジェクトのスケーリングを取得または設定します。
		/// </summary>
        public virtual Vector Scale { get; set; } = new Vector(1, 1);

		/// <summary>
		/// このオブジェクトの幅を取得または設定します。
		/// </summary>
		public virtual float Width { get; set; }

		/// <summary>
		/// このオブジェクトの高さを取得または設定します。
		/// </summary>
		/// <value></value>
		public virtual float Height { get; set; }

        /// <summary>
        /// このオブジェクトの高さを取得または設定します。
        /// </summary>
        /// <value></value>
        public virtual Color? Color { get; set; }

		/// <summary>
		/// テクスチャを取得します。
		/// </summary>
		public virtual Texture2D Texture { get; protected set; }

		/// <summary>
		/// このオブジェクトを破棄します。
		/// </summary>
        public virtual void Destroy()
        {
        }

		/// <summary>
		/// 描画します。
		/// </summary>
        public virtual void Draw(GameBase game, Vector location)
        {
            TextureDrawer.Draw(game, Texture, location + Location, Scale, Angle, Color, Width, Height);
        }
    }
}
