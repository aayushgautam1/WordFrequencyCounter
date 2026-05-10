using System;
using System.Collections.Generic;

namespace WordCounterV2
{
    public class WordCounter
    {
        public Dictionary<string, int> Count(List<string> words)
        {
            Dictionary<string, int> freq = new Dictionary<string, int>();
            foreach (string w in words)
            {
                if (freq.ContainsKey(w))
                    freq[w]++;
                else
                    freq[w] = 1;
            }
            return freq;
        }

        public void Show(Dictionary<string, int> freq)
        {
            Console.WriteLine("\n--- Word Frequencies ---");
            foreach (var item in freq)
                Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}