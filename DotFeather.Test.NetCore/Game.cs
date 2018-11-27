using System;

namespace DotFeather.Test.NetCore
{
	class Game : GameBase
	{
		public Game(int width, int height, string title = null, int refreshRate = 60) : base(width, height, title, refreshRate)
		{

		}

		static void Main(string[] args)
		{
			new Game(640, 480).Run();
		}
	}
}
