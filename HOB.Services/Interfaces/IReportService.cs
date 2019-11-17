
namespace HOB.Services
{
    public interface IReportService<T>
    {
        public T Generate(string text);
        //public T GenerateFromFile(string filename);
    }
}
