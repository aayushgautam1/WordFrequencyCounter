using System;
using System.Collections.Generic;

namespace WordCounterV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Word Frequency Counter - Version 2 ===");
            Console.Write("Enter folder path containing .txt files: ");
            string folder = Console.ReadLine();

            Console.Write("Enable Version 2 (trim long words)? (y/n): ");
            string answer = Console.ReadLine().ToLower();

            TextProcessor processor = new TextProcessor();
            if (answer == "y" || answer == "yes")
            {
                Console.Write("Enter N (min length to trigger trim): ");
                int n = int.Parse(Console.ReadLine());
                Console.Write("Enter M (chars to remove from end): ");
                int m = int.Parse(Console.ReadLine());
                processor.SetVersion2(n, m);
                Console.WriteLine($"Version 2 ON: words longer than {n} lose last {m} chars.\n");
            }
            else
            {
                Console.WriteLine("Version 1 (no trimming).\n");
            }

            FileReader reader = new FileReader();
            List<string> contents = reader.ReadAllTxtFiles(folder);
            if (contents.Count == 0) { Console.WriteLine("No .txt files found."); return; }

            List<string> allWords = new List<string>();
            foreach (string text in contents)
                allWords.AddRange(processor.GetWordsFromText(text));

            WordCounter counter = new WordCounter();
            Dictionary<string, int> result = counter.Count(allWords);
            counter.Show(result);
            Console.WriteLine("\nTotal unique words: " + result.Count);
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}