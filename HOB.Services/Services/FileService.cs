using System;
using System.IO;

namespace HOB.Services
{
    public class FileService : IFileService
    {
        public string ExtractText(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("File does not exist.");
            }
            else if (Path.GetExtension(filename).ToLower() != ".txt")
            {
                throw new InvalidFileTypeException("File must have .txt extension.");
            }

            string textFromFile = "";
            try
            {
                textFromFile = File.ReadAllText(filename);
            }
            catch (Exception ex)
            {
                throw new ReadAllTextException(ex.Message);
            }

            return textFromFile;
        }
    }
}
