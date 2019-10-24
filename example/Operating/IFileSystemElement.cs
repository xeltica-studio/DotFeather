namespace DotFeather.Example
{
    public interface IFileSystemElement
    {
        string Name { get; }

		Folder? Parent { get; }
    }
}
