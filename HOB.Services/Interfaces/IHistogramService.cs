using System.Collections.Generic;

namespace HOB.Services
{
    public interface IHistogramService
    {
        public List<StringBucket> BuildStringDomain(List<string> domainItems);
        public Histogram<StringBucket> Generate(List<StringBucket> domain);
    }
}
