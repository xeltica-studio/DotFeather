using System;
namespace DotFeather.Models
{
	public class Sprite
	{
		/// <summary>
		/// このスプライトの座標を取得または設定します。
		/// </summary>
		/// <value>The position.</value>
		public Vector Position { get; set; }

		/// <summary>
		/// このスプライトの角度情報を取得または設定します。
		/// </summary>
		/// <value>The rotation.</value>
		public Vector Rotation { get; set; }

		/// <summary>
		/// スプライトのタグを取得または設定します。
		/// </summary>
		public string Tag { get; set; }

		/// <summary>
		/// スプライトのサイズを取得または設定します。
		/// </summary>
		/// <value>The size.</value>
		public Vector Size { get; set; }

		/// <summary>
		/// スプライトのスケールを取得または設定します。
		/// </summary>
		public Vector Scale { get; set; }
	}
}
