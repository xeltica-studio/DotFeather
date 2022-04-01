using System.Collections.Generic;

public static class Debug
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
		Log($"FixMe: {context} {desc}");
	}

	public static void DebugLog(string log)
	{
		System.Console.WriteLine($"Debug: {log}");
	}

	public static void Log(string log)
	{
		if (Logs.Contains(log)) return;
		System.Console.Error.WriteLine(log);
		Logs.Add(log);
	}

	private readonly static HashSet<string> Logs = new();
}
