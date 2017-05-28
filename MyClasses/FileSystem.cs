namespace MyClasses
{
	public class FileSystem : IFileSystem
	{
		public bool DirectoryExists(string directoryName)
		{
			return System.IO.Directory.Exists(directoryName);
		}
	}
}
