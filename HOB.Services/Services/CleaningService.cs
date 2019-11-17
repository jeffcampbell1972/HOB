using System;
using System.Text;

namespace HOB.Services
{
    public class CleaningService : ICleaningService
    {
        public string Clean(string inputString)
        {
            if (inputString == null)
            {
                throw new InvalidTextException("Input string cannot be null");
            }
            if (inputString.Trim() == "")
            {
                throw new InvalidTextException("Input string cannot be empty");
            }
            // iterate through the characters of the string to remove all non-alphanumeric characters except dashes and apostropes which can be part of a word.
            // note that quoted text such as "this is a test" and 'this is a test' will have the quotes or double quotes removed.

            var original = inputString.ToCharArray();
            var cleaned = new StringBuilder();

            foreach (var _character in original)
            { 
                if (Char.IsLetterOrDigit(_character))                            // leave alphanumeric characters alone
                {
                    cleaned.Append(_character);
                }
                else if (_character == '-' || _character == Char.Parse("'"))     // leave dashes and apostrophes alone
                {
                    cleaned.Append(_character);
                }
                else if (Char.IsWhiteSpace(_character))                          // convert all white space to the space character
                {
                    cleaned.Append(' ');
                }
            }

            var outputString = cleaned.ToString();

            // dashes cannot have leading or trailing spaces.  they can only exist as part of a word such as "Mary Jones-Constiglio"
            outputString = outputString.Replace(" -", " ");
            outputString = outputString.Replace("- ", " ");

            // apostrophes cannot have leading or trailing spaces.  they can only exist as part of a contraction such as "can't" or a name such as "O'Reilly"
            outputString = outputString.Replace(" '", " ");
            outputString = outputString.Replace("' ", " ");

            // replace all consecutive spaces with single space until all consecutive spaces are removed.
            var tempString = "";

            while (outputString != tempString)
            {
                tempString = outputString;
                outputString = outputString.Replace("  ", " ");
            }

            return outputString.Trim();
        }
    }
}
