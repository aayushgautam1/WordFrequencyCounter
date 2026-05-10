using System;
using System.Collections.Generic;

namespace WordCounterV2
{
    public class TextProcessor
    {
        private int N = 0;
        private int M = 0;

        public void SetVersion2(int n, int m)
        {
            N = n;
            M = m;
        }

        public List<string> GetWordsFromText(string text)
        {
            List<string> words = new List<string>();
            char[] separators = { ' ', ',', '.', ';', ':', '!', '?', '(', ')', '[', ']', '{', '}', '"', '\'', '-', '\n', '\r', '\t' };
            string[] parts = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                string word = part.ToLower().Trim();
                if (word == "") continue;

                // Version 2: trim if longer than N
                if (N > 0 && M > 0 && word.Length > N)
                {
                    int keep = word.Length - M;
                    if (keep > 0)
                        word = word.Substring(0, keep);
                    else
                        word = "";
                }
                if (word != "")
                    words.Add(word);
            }
            return words;
        }
    }
}