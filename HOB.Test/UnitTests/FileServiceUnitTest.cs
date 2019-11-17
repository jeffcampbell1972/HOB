using System.IO;
using Xunit;
using HOB.Services;

namespace HOB.UnitTests
{
    public class FileServiceUnitTest
    {
        private FileService _fileService { get; set; }
        public FileServiceUnitTest()
        {
            _fileService = new FileService();
        }
        [Theory]
        [InlineData("This is a test")]
        [InlineData("This is a test and we want to know how many words")]
        [InlineData("   ")]
        [InlineData("1 2 3 4")]
        [InlineData("This is  a test")]
        public void BuildFileAndExtract(string text)
        {
            string filename = Path.Combine(".", "FileServiceUnitTest.txt");
            File.WriteAllText(filename, text);

            string extractedText = _fileService.ExtractText(filename);

            Assert.True(text == extractedText);

            File.Delete(filename);
        }
        [Fact]
        public void InvalidFile_FileNotFound()
        {
            bool errorFound = false;
            try
            {
                var cleanedText = _fileService.ExtractText(@"c:\testfolderthatdoesnotexist\testfilethatdoesnotexist.txt");
            }
            catch (FileNotFoundException)
            {
                errorFound = true;
            }

            Assert.True(errorFound);
        }
        [Fact]
        public void InvalidFile_InvalidFileType()
        {
            string filename = Path.Combine(".", "FileServiceUnitTest.dat");
            File.WriteAllText(filename, "bigram test"); 
            
            bool errorFound = false;

            try
            {
                var cleanedText = _fileService.ExtractText(filename);
            }
            catch (InvalidFileTypeException)
            {
                errorFound = true;
            }

            Assert.True(errorFound);

            File.Delete(filename);
        }
    }
}
