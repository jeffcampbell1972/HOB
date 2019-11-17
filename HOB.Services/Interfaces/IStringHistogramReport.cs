using System.Collections.Generic;

namespace HOB.Services
{
    public interface IStringHistogramReport
    {
        public string OriginalString { get; set; }
        public List<string> Domain { get; set; }
        public Histogram<StringBucket> Histogram { get; set; }
    }
}
