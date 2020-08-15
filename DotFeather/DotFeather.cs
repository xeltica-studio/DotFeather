using System;
using System.Collections.Generic;
using OpenTK;

namespace DotFeather
{
	public static partial class DotFeather
	{
		public static IWindow Window { get; }
		public static IConsole Console { get; }
		public static Container Root { get; } = new Container();

		public static int Run()
		{
			window.Run();
			return statusCode;
		}

		public static void Exit(int status = 0)
		{
			statusCode = status;
			window.Exit();
		}

		public static int RunAsCaptureMode()
		{
			// todo
			return Run();
		}

		public static void NextFrame(Action task)
		{
			nextFrameQueue.Add(task);
		}

		private static readonly GameWindow window;
		private static readonly List<Action> nextFrameQueue = new List<Action>();
		private static int statusCode;
	}
}
