using System;

namespace DotFeather
{
    public class ClickableSprite : Sprite, IUpdatable
	{
		public ClickableSprite(Texture2D texture) : base(texture) { }

		public event Action<ClickableSprite> Click;

		public void OnUpdate(GameBase game)
		{
			
		}
	}
}
