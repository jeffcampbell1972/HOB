using System;
using System.Collections.Generic;

namespace HOB.Services
{
    public class BigramService : IBigramService
    {
        public List<string> Extract(List<string> words)
        {
            string currentWord = "";
            string prevWord = "";

            var strings = new List<string>();

            foreach (string word in words)
            {
                currentWord = word;
                if (currentWord != "" && prevWord != "")
                {
                    string stringValue = String.Format("{0} {1}", prevWord, currentWord);

                    strings.Add(stringValue);
                }
                prevWord = currentWord;
            }

            return strings;
        }

    }
}
