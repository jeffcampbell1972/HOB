using System.Collections.Generic;

namespace HOB.Services
{
    public class BigramHistogramReport : IStringHistogramReport
    {
        public string OriginalString { get; set; }
        public List<string> Domain { get; set; }
        public Histogram<StringBucket> Histogram { get; set; }
    }
}
