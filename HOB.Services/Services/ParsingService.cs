using System.Collections.Generic;

namespace HOB.Services
{
    public class ParsingService : IParsingService
    {
        public List<string> Parse(string inputString)
        {
            var wordArray = inputString.Split(" ");

            return new List<string>(wordArray);
        }
    }

}
