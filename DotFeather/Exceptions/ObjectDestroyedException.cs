namespace DotFeather
{
	[System.Serializable]
	public class ObjectDestroyedException : System.Exception
	{
		public ObjectDestroyedException() : base("You can not add the destroyed element or component.") { }
		public ObjectDestroyedException(string message) : base(message) { }
		public ObjectDestroyedException(string message, System.Exception inner) : base(message, inner) { }
		protected ObjectDestroyedException(
			System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
