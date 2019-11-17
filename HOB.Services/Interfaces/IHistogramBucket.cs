
namespace HOB.Services
{
    public interface IHistogramBucket
    {
        public int Key { get; set; }
        public int Count { get; set; }
        public int SortOrder { get; set; }
    }
}
