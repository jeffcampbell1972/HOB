using System.Linq;
using System.Collections.Generic;

namespace HOB.Services
{
    public class Histogram<T> where T : IHistogramBucket
    {
        public List<T> Buckets { get; set; }
        public Histogram(List<T> domain)
        {
            var histogram = new SortedDictionary<int, T>();

            foreach(var t in domain)
            {
                if ( !histogram.ContainsKey(t.Key) )
                {
                    histogram.Add(t.Key, t);
                }
                histogram[t.Key].Count++;
            }

            Buckets = histogram.ToList().Select(x => x.Value).OrderBy(x => x.SortOrder).ToList();
        }

    }
}
