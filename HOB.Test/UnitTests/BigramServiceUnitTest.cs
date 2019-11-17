using System.Collections.Generic;
using Xunit;
using HOB.Services;

namespace HOB.UnitTests
{
    public class BigramServiceUnitTest
    {
        private readonly IBigramService _bigramService;
        private readonly IParsingService _parsingService;

        public BigramServiceUnitTest()
        {
            _bigramService = new BigramService();
            _parsingService = new ParsingService();
        }
        [Fact]
        public void ExtractBigrams_VerifyBigrams()
        {
            var words = new List<string> { "This", "is", "a", "test" };

            int expectedBigramCount = 3;

            var bigrams = _bigramService.Extract(words);

            Assert.True(bigrams.Count == expectedBigramCount, $"Bigram count = {bigrams.Count} but {expectedBigramCount} was expected.");

            Assert.True(bigrams[0] == "This is");
            Assert.True(bigrams[1] == "is a");
            Assert.True(bigrams[2] == "a test");
        }

        [Theory]
        [InlineData("This was a test", 3)]
        public void CreateWordListAndExtractBigrams_VerifyCount(string text, int expectedBigramCount)
        {
            var words = _parsingService.Parse(text);

            var bigrams = _bigramService.Extract(words);

            Assert.True(bigrams.Count == expectedBigramCount, $"Bigram count = {bigrams.Count} but {expectedBigramCount} was expected.");
        }
    }
}
