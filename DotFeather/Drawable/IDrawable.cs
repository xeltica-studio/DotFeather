namespace DotFeather
{
	/// <summary>
	/// 描画処理を行うクラスはすべてこのインターフェイスを実装します。
	/// </summary>
	public interface IDrawable
	{
		/// <summary>
		/// 画面への描画を開始します。
		/// </summary>
		/// <param name="game">Game.</param>
		void Draw(GameBase game, Vector location);

		/// <summary>
		/// この <see cref="IDrawable"/> の描画優先順位を取得または設定します。数値が低いほど奥に描画されます。
		/// </summary>
		int ZOrder { get; set; }

		/// <summary>
		/// この <see cref="IDrawable"/> の名前を取得または設定します。
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// この <see cref="IDrawable"/> の座標を取得または設定します。
		/// </summary>
		Vector Location { get; set; }

		/// <summary>
		/// この <see cref="IDrawable"/> の角度を取得または設定します。
		/// </summary>
		float Angle { get; set; }

		/// <summary>
		/// この <see cref="IDrawable"/> のスケーリングを取得または設定します。
		/// </summary>
		Vector Scale { get; set; }

        /// <summary>
        /// この <see cref="IDrawable"/> を完全に破棄します。
        /// </summary>
        void Destroy();
	}

}
