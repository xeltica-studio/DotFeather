using System;

namespace DotFeather.Demo
{
    [AttributeUsage(System.AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
	public sealed class DemoSceneAttribute : Attribute
	{
		public string Path { get; set; }
		// This is a positional argument
		public DemoSceneAttribute(string path) => Path = path;
	}
}
