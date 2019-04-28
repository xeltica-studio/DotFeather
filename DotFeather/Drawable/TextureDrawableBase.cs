namespace DotFeather
{
	/// <summary>
	/// <see cref="Texture2D"/> を描画するオブジェクトの抽象クラスです。
	/// </summary>
    public abstract class TextureDrawableBase : IDrawable
    {
		/// <summary></summary>
        public virtual int ZOrder { get; set; }
        /// <summary></summary>
        public virtual string Name { get; set; }
        /// <summary></summary>
        public virtual Vector Location { get; set; }
        /// <summary></summary>
        public virtual float Angle { get; set; }
        /// <summary></summary>
        public virtual Vector Scale { get; set; }

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
            TextureDrawer.Draw(game, Texture, location + Location, Scale, Angle);
        }
    }
}
