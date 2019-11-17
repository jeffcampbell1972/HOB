using System.Collections.Generic;
using System.Linq;

namespace HOB.Services
{
    public class HistogramService : IHistogramService
    {
        public List<StringBucket> BuildStringDomain(List<string> domainItems)
        {
            int sortOrder = 0;

            var domain = domainItems
                .Select(x => new StringBucket
                    {
                        Key = x.GetHashCode(),
                        Value = x,
                        Count = 0,
                        SortOrder = sortOrder++
                    })
                .ToList()
                .OrderBy(x => x.SortOrder)
                .ToList();

            return domain;
        }

        public Histogram<StringBucket> Generate(List<StringBucket> domain)
        {
            return new Histogram<StringBucket>(domain);
        }
    }
}
