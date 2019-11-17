using Xunit;
using System.IO;
using HOB.Services;

namespace HOB.UnitTests
{
    public class BigramHistogramReportServiceUnitTests
    {
        private readonly IReportService<BigramHistogramReport> _bigramHistogramReportService;
        private readonly IFileService _fileService;

        public BigramHistogramReportServiceUnitTests()
        {
            _fileService = new FileService();

            _bigramHistogramReportService = new BigramHistogramReportService(
                new CleaningService(),
                new ParsingService(),
                new BigramService(),
                new HistogramService()
                );
        }
        [Fact]
        public void GenerateBigramHistogramReport()
        {
            var histogramReport = _bigramHistogramReportService.Generate(testString);

            VerifyThisIsATest(histogramReport);
        }
        [Fact]
        public void GenerateBigramHistogramReportFromBigTestFile()
        {

            string filename = Path.Combine(".", "UnitTestFiles", "BigTest.txt");

            string text = _fileService.ExtractText(filename);

            var histogramReport = _bigramHistogramReportService.Generate(text);

            Assert.True(histogramReport.Histogram.Buckets.Count == 6);
        }

        // shared test data
        private string testString = "This is a test is a test";
        private int expectedBigramCount = 6;
        private int expectedBucketCount = 4;
        private void VerifyThisIsATest(BigramHistogramReport histogramReport)
        {
            Assert.True(histogramReport.OriginalString == testString);
            Assert.True(histogramReport.Domain.Count == expectedBigramCount, $"# of bigrams = {histogramReport.Domain.Count} but should be {expectedBigramCount}");
            Assert.True(histogramReport.Histogram.Buckets.Count == expectedBucketCount, $"# of buckets = {histogramReport.Histogram.Buckets.Count} but should be {expectedBucketCount}");

            Assert.True(histogramReport.Histogram.Buckets[0].Value == "This is");
            Assert.True(histogramReport.Histogram.Buckets[1].Value == "is a");
            Assert.True(histogramReport.Histogram.Buckets[2].Value == "a test");
            Assert.True(histogramReport.Histogram.Buckets[3].Value == "test is");

            Assert.True(histogramReport.Histogram.Buckets[0].Count == 1);
            Assert.True(histogramReport.Histogram.Buckets[1].Count == 2);
            Assert.True(histogramReport.Histogram.Buckets[2].Count == 2);
            Assert.True(histogramReport.Histogram.Buckets[3].Count == 1);
        }
    }
}
