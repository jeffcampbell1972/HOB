using System.Collections.Generic;

namespace HOB.Services
{
    public interface IBigramService
    {
        public List<string> Extract(List<string> words);
    }
}
