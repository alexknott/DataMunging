using System.IO;

namespace CommonLibrary
{
    public class FileSystemFacade
    {
        public virtual string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}