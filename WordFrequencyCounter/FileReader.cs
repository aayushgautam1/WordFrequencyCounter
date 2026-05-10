using System;
using System.Collections.Generic;
using System.IO;

namespace WordCounterV1
{
    public class FileReader
    {
        public List<string> ReadAllTxtFiles(string folder)
        {
            List<string> allText = new List<string>();
            if (!Directory.Exists(folder))
            {
                Console.WriteLine("Folder does not exist: " + folder);
                return allText;
            }
            string[] files = Directory.GetFiles(folder, "*.txt");
            foreach (string file in files)
            {
                string text = File.ReadAllText(file);
                allText.Add(text);
                Console.WriteLine("Read: " + Path.GetFileName(file));
            }
            return allText;
        }
    }
}