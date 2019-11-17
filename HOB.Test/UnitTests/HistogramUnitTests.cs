using System.Collections.Generic;
using System.Linq;
using Xunit;
using HOB.Services;

namespace HOB.UnitTests
{
    public class HistogramUnitTests
    {
        [Fact]
        public void HistogramGenerated()
        {
            int[] values = new int[] { 1, 2, 3, 2, 2, 2, 3, 4, 1, 1, 2, 3,  5, 3, 4, 4, 4, 4, 4, 4, 2 };

            var domain = new List<HistogramBucket>();
            for (int i = 0; i < values.Length; i++)
            {
                domain.Add(
                    new HistogramBucket 
                    { 
                        Key = values[i], 
                        Count = 0 ,
                        SortOrder = values[i]
                    });
            }

            var histogram = new Histogram<HistogramBucket>(domain);

            Assert.True(histogram.Buckets.Count == 5);

            Assert.True(histogram.Buckets.Single(x => x.Key == 1).Count == 3);
            Assert.True(histogram.Buckets.Single(x => x.Key == 2).Count == 6);
            Assert.True(histogram.Buckets.Single(x => x.Key == 3).Count == 4);
            Assert.True(histogram.Buckets.Single(x => x.Key == 4).Count == 7);
            Assert.True(histogram.Buckets.Single(x => x.Key == 5).Count == 1);
        }
        [Theory]
        [InlineData(new int[] { 1, 2 }, 2)]
        [InlineData(new int[] { 1, 2, 1, 2 }, 2)]
        [InlineData(new int[] { 1, 2, 1, 2, 1, 2 }, 2)]
        [InlineData(new int[] { 1, 2, 1, 2, 1, 2, 1, 2 }, 2)]
        [InlineData(new int[] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 }, 2)]
        [InlineData(new int[] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 }, 2)]
        public void GenerateHistogram_VerifyBucketCounts(int[] values, int expectedBucketCount)
        {
            var domain = new List<HistogramBucket>();
            for (int i = 0; i < values.Length; i++)
            {
                domain.Add(
                    new HistogramBucket
                    {
                        Key = values[i],
                        Count = 0
                    });
            }

            var histogram = new Histogram<HistogramBucket>(domain);

            Assert.True(histogram.Buckets.Count == expectedBucketCount);
        }
    }
}
