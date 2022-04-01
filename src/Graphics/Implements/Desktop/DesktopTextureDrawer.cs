#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較
using System;
using System.Drawing;

namespace DotFeather.Internal
{
	/// <summary>
	/// <see cref="Texture2D"/> オブジェクトをバッファ上に描画する機能を提供します。
	/// </summary>
	internal class DesktopTextureDrawer : ITextureDrawer
	{
		/// <summary>
		/// テクスチャを描画します。
		/// </summary>
		public void Draw(Texture2D texture, Vector location, Vector scale, Color? color = null, float? width = null, float? height = null, float angle = 0)
		{
			location = location.ToDeviceCoord();
			scale = scale.ToDeviceCoord();

			var w = width ?? texture.Size.X;
			var h = height ?? texture.Size.Y;

			w *= scale.X;
			h *= scale.Y;

			var (left, top) = location;
			var right = left + w;
			var bottom = top + h;

			if (left > DF.Window.ActualWidth || top > DF.Window.ActualHeight || right < 0 || bottom < 0)
				return;

			Debug.NotImpl("DesktopTextureDrawer.Draw");
		}

		private void Vertex(double tcx, double tcy, (float x, float y) vx, Color? color)
		{
			Debug.NotImpl("DesktopTextureDrawer.Vertex");
		}
	}
}
