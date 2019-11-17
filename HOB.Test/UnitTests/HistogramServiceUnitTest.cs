using HOB.Services;
using Xunit;

namespace HOB.UnitTests
{
    public class HistogramServiceUnitTest
    {

        private readonly IHistogramService _histogramService;
        private readonly IParsingService _parsingService;

        public HistogramServiceUnitTest()
        {
            _histogramService = new HistogramService();
            _parsingService = new ParsingService();
        }

        [Theory]
        [InlineData("This is a test")]
        [InlineData("This is a test and we want to know how many words")]
        [InlineData("1 2 3 4")]
        [InlineData("This is  a test")]
        public void StringDomains_VerifyBuckets(string testString)
        {
            var words = _parsingService.Parse(testString);

            var domain = _histogramService.BuildStringDomain(words);

            Assert.True(words.Count == domain.Count);

            int wordIndex = 0;
            foreach(var bucket in domain)
            {
                Assert.True(bucket.Value == words[wordIndex], $"Bucket Value ({bucket.Value}) does not match word ({words[wordIndex]}");
                Assert.True(bucket.Key == words[wordIndex].GetHashCode(), "Key does not match the hash code of word");
                Assert.True(bucket.Count == 0, "Count is not zero");
                Assert.True(bucket.SortOrder == wordIndex, "Sort Order does not match word index");

                wordIndex++;
            }
        }
    }
}
