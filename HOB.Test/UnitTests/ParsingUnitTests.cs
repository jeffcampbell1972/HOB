using Xunit;
using HOB.Services;

namespace HOB.UnitTests
{
    public class ParsingServiceUnitTests
    {
        private readonly ParsingService _parsingService;

        public ParsingServiceUnitTests()
        {
            _parsingService = new ParsingService();
        }

        [Fact]
        public void ParseWords_VerifyWords()
        {
            string text = "This is a test";
            int expectedWordCount = 4;

            var words = _parsingService.Parse(text);

            Assert.True(words.Count == expectedWordCount);

            Assert.True(words[0] == "This");
            Assert.True(words[1] == "is");
            Assert.True(words[2] == "a");
            Assert.True(words[3] == "test");
        }
        [Theory]
        [InlineData("This is a test", 4)]
        [InlineData("This is a test and we want to know how many words", 12)]
        [InlineData("   ", 4)]
        [InlineData("1 2 3 4", 4)]
        [InlineData("This is  a test", 5)]
        public void ParseWords_VerifyCount(string text, int expectedWordCount)
        {
            var words = _parsingService.Parse(text);

            Assert.True(words.Count == expectedWordCount);
        } 
 
    }
}