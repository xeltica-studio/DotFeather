public static class Debug
{
	public static void NotImpl(string context)
	{
		System.Console.WriteLine($"NotImpl: {context}");
	}

	public static void FixMe(string context, string desc = "")
	{
		System.Console.WriteLine($"FixMe: {context} {desc}");
	}

	public static void Bug(string context, string desc = "")
	{
		System.Console.WriteLine($"FixMe: {context} {desc}");
	}
}
