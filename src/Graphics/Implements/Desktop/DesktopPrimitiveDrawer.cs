using System;
using System.Drawing;

namespace DotFeather.Internal
{
	public class DesktopPrimitiveDrawer : IPrimitiveDrawer
	{
		public void Draw(Vector originLocation, Vector originScale, VectorInt[] vertices, ShapeType type, Color color, int lineWidth = 0, Color? lineColor = null)
		{
			if (vertices.Length == 0)
				return;

			Debug.NotImpl("DesktopPrimitiveDrawer.Draw#1");

			if (color.A > 0)
			{
				Debug.NotImpl("DesktopPrimitiveDrawer.Draw#2");
			}

			if (lineWidth > 0 && lineColor is Color lc)
			{
				Debug.NotImpl("DesktopPrimitiveDrawer.Draw#3");
			}
		}

		private void Vertex(Color col, Vector vec)
		{
			Debug.NotImpl("DesktopPrimitiveDrawer.Vertex");
		}
	}
}
