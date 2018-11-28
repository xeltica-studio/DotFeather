using OpenTK.Input;

namespace DotFeather
{
	public struct DFKey
	{
		private readonly Key source;
		internal DFKey(Key key)
		{
			source = key;
		}

		public bool IsPressed => Keyboard.GetState()[source];
	}

}
