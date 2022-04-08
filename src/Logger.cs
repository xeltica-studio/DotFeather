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

	public static void Info(string log)
	{
		if (Logs.Contains(log)) return;
		System.Console.WriteLine($"Info: {log}");
		Logs.Add(log);
	}

	public static void Log(string log)
	{
		if (Logs.Contains(log)) return;
		System.Console.Error.WriteLine(log);
		Logs.Add(log);
	}

	private readonly static HashSet<string> Logs = new();
}
