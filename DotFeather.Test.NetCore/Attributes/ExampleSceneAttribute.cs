using System;

namespace DotFeather
{
    [AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
	public sealed class ExampleSceneAttribute : Attribute
	{
		public string Path { get; set; }
		// This is a positional argument
		public ExampleSceneAttribute(string path) => Path = path;
	}
}
