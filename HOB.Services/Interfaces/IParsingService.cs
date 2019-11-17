using System.Collections.Generic;

namespace HOB.Services
{
    public interface IParsingService
    {
        public List<string> Parse(string text);
    }
}
