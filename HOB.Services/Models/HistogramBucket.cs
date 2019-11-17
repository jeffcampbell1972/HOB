namespace HOB.Services
{
    public class HistogramBucket : IHistogramBucket
    {
        public HistogramBucket()
        {

        }
        public int Key { get; set; }
        public int Count { get; set; }
        public int SortOrder { get; set; }
    }
}
