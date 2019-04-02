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

		public List<IDrawable> Children { get; } = new List<IDrawable>(10000);

		public void Draw(GameBase game, Vector location)
		{
			Children.Sort((d1, d2) => d1.ZOrder < d2.ZOrder ? - 1 : d1.ZOrder > d2.ZOrder ? 1 : 0);
			foreach (var child in Children.ToList())
				child.Draw(game, Location + location);
		}
	}

}
