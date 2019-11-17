using System;
using System.Collections.Generic;
using System.Text;

namespace HOB
{
    public interface IHobHelper
    {
        public string[] GetHobForConsole(string text);
        public string[] GetHobForConsoleFromFile(string text);
    }
}
