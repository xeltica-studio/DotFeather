using System;

namespace DotFeather
{
	public static class StringExtension
	{
		public static string ReplaceAt(this string str, int index, string replace)
			=> str.Remove(index, Math.Min(replace.Length, str.Length - index))
				.Insert(index, replace);
	}

}
