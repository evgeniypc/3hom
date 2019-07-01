using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3dom
{
    public class TextHandler
    {
        public string Path { get; set; }
        public async Task<Sentence[]> ParserTextToSentences()
        {
            Parser parser = new Parser();
            return await parser.GetSentences(Path);
        }

        public async Task<Dictionary<string, int>> GetAlphabeticalDictionary(/*Sentence[]*/)
        {
            var sentences = await ParserTextToSentences();
            //получили все слова
            var words = sentences.Select(s => s.Where(part => part is word)).SelectMany(s => s);

            var dictionary = new Dictionary<string, int>();
            foreach (var item in words)
            {
                if (dictionary.ContainsKey(item.Value))
                {
                    dictionary[item.Value]++;
                }
                else
                {
                    dictionary.Add(item.Value, 1);
                }
            }
            return dictionary;
        }
        public async Task CreatAlphabeticalFileWithData()
        {
            string path = @"C:\Users\Sony\source\repos\3dom\123\555.txt";
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                var dict = await GetAlphabeticalDictionary();
                foreach (var item in dict.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp))
                {
                    await sw.WriteLineAsync($"{item.Key} - {item.Value.ToString()}");
                }
            }
        }

    }
}

    

