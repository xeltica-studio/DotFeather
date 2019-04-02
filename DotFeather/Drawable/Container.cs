using System.Collections.Generic;
using System.Linq;

namespace DotFeather.Drawable
{
	public class Container : IDrawable
	{
		public int ZOrder { get; set; }
		public string Name { get; set; }
		public Vector Location { get; set; }
		public float Angle { get; set; }
		public Vector Scale { get; set; }

		public List<IDrawable> Children { get; } = new List<IDrawable>();

		public void Draw(GameBase game, Vector location)
		{
			foreach (var child in Children.OrderBy(child => child.ZOrder))
				child.Draw(game, Location + location);
		}
	}

}
