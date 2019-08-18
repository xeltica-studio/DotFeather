using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;

namespace DotFeather
{
	class Game : GameBase
	{
        public Game(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
		{
			BackgroundColor = Color.Black;
		}

		protected override void OnLoad(object sender, EventArgs e)
		{
			Root.Add(g);
			for (var i = 0; i < 100; i++)
			{
				int x = rnd.Next(1000), y = rnd.Next(1000);
				g.Rect(x, y, x + rnd.Next(256), y + rnd.Next(256), rnd.NextColor(), rnd.Next(32), rnd.NextColor());
			}

			StartCoroutine(Coroutine1())
				.Then(a => StartCoroutine(Coroutine2(a))
					.Error(err => Console.WriteLine($"{err.GetType().Name}: {err.Message}\n{err.StackTrace}")));
		}

		protected override void OnUpdate(object sender, DFEventArgs e)
		{
			if (Input.Keyboard.Escape.IsKeyUp)
				Exit(0);
			var clicked = Input.Mouse.IsLeft;
			var mp = Input.Mouse.Position;
			if (p is Point pp)
			{
				g.Location += new Vector(mp.X - pp.X, mp.Y - pp.Y);
			}
			p = clicked ? mp : (Point?)null;	
        }

		IEnumerator Coroutine1()
		{
			for (var i = 0; i < 120; i++)
			{
				Console.WriteLine(i);
				yield return i;
			}
		}

		IEnumerator Coroutine2(object a)
		{
			Console.WriteLine(a);
			yield return new WaitForSeconds(5);
			throw new Exception("Sample Error");
		}

		Graphic g = new Graphic();

		private Random rnd = new Random();
		private Point? p;
    }
}
