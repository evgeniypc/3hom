using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3dom
{
    
    class Repository : ISentencePart
    {
        const string readPath = @"read.txt";
        const string writePath = @"write.txt";
        const string writePathWord = @"writeWord.txt";
        public static string line;
        public void LoadString()
        {
            using (StreamReader file = new StreamReader(readPath))
            {
                line = file.ReadToEnd();
            }
        }
        public void SaveWord(string str, int count)
        {
            using (StreamWriter sw = new StreamWriter(writePathWord, true))
            {
                sw.WriteLine($"{str} - {count}");
            }
        }
        public void SaveSentences(string str, int count, string massage)
        {
            using (StreamWriter sw = new StreamWriter(writePath, true))
            {
                sw.WriteLine(massage);
                sw.WriteLine($"String - {str}");
                sw.WriteLine($"Count  - {count}");
            }
        }
    }
}
