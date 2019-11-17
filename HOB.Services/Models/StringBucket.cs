namespace HOB.Services
{
    public class StringBucket : IHistogramBucket
    {
        public int Key { get; set; }
        public int Count { get; set; }
        public string Value { get; set; }
        public int SortOrder { get; set; }
    }
}
