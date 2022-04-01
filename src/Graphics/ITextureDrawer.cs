#pragma warning disable RECS0018 // 等値演算子による浮動小数点値の比較
using System.Drawing;

namespace DotFeather
{
	public interface ITextureDrawer
	{
		void Draw(Texture2D texture, Vector location, Vector scale, Color? color = null, float? width = null, float? height = null, float angle = 0);

		int GenerateTexture(byte[] bmp, int width, int height);
	}
}
