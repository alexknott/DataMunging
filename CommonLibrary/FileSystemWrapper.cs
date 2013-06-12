using System.IO;

namespace CommonLibrary
{
    public class FileSystemWrapper
    {
        public virtual string[] ReadAllLines(string path)
        {
            return File.ReadAllLines(path);
        }
    }
}