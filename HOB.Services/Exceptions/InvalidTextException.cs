using System;
using System.Collections.Generic;
using System.Text;

namespace HOB.Services
{
    public class InvalidTextException : Exception
    {
        public InvalidTextException(string message) : base(message)
        {

        }
    }
}

