using System;
using System.Collections.Generic;

namespace WordCounterV1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Word Frequency Counter - Version 1 ===");
            Console.Write("Enter folder path containing .txt files: ");
            string folder = Console.ReadLine();

            FileReader reader = new FileReader();
            List<string> contents = reader.ReadAllTxtFiles(folder);

            if (contents.Count == 0)
            {
                Console.WriteLine("No .txt files found. Exiting.");
                return;
            }

            TextProcessor processor = new TextProcessor();
            List<string> allWords = new List<string>();
            foreach (string text in contents)
            {
                List<string> words = processor.GetWordsFromText(text);
                allWords.AddRange(words);
            }

            WordCounter counter = new WordCounter();
            Dictionary<string, int> result = counter.Count(allWords);
            counter.Show(result);
            Console.WriteLine("\nTotal unique words: " + result.Count);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}