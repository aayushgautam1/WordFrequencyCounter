using System;
using System.Collections.Generic;

namespace WordCounterV1
{
    public class TextProcessor
    {
        public List<string> GetWordsFromText(string text)
        {
            List<string> words = new List<string>();
            char[] separators = { ' ', ',', '.', ';', ':', '!', '?', '(', ')', '[', ']', '{', '}', '"', '\'', '-', '\n', '\r', '\t' };
            string[] parts = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                string word = part.ToLower().Trim();
                if (word != "")
                    words.Add(word);
            }
            return words;
        }
    }
}