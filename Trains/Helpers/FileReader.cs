using System.IO;

namespace Trains.Helpers
{
    public class FileReader : IFileReader
    {
        private readonly string _Path;

        public FileReader(string path)
        {
            _Path = path;
        }

        public string ReadAllText()
        {
            return File.ReadAllText(_Path);
        }
    }
}