using System;
using System.Collections.Generic;
using System.Text;

namespace HOB.Services
{
    public class InvalidFileTypeException : Exception
    {
        public InvalidFileTypeException(string message) : base(message)
        {

        }
    }
}
