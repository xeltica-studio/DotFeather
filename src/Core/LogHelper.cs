using System.Collections.Generic;

namespace DotFeather.Internal
{
	static class LogHelper
	{
		public static void NotImpl(string context)
		{
			Log($"NotImpl: {context}");
		}

		public static void FixMe(string context, string desc = "")
		{
			Log($"FixMe: {context} {desc}");
		}

		public static void Bug(string context, string desc = "")
		{
			Log($"Bug: {context} {desc}");
		}

		public static void Warn(string text)
		{
			Log($"Warn: {text}");
		}

		public static void Info(string log)
		{
			System.Console.WriteLine($"Info: {log}");
		}

		public static void Log(string log)
		{
			System.Console.Error.WriteLine(log);
		}
	}
}
