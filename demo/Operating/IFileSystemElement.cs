namespace DotFeather.Demo
{
    public interface IFileSystemElement
    {
        string Name { get; }

		Folder? Parent { get; }
    }
}
