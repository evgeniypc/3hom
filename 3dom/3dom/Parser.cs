using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace _3dom
{
   public class Parser:Word
    {
        public async Task<Sentence[]> GetSentences(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string fullText = null;
                    using (StreamReader sr = new StreamReader(path))
                    {
                        fullText = await sr.ReadToEndAsync();
                    }
                    var changeText = RemoveUnusedSymbols(fullText);
                    return GetSentenceByString(changeText);
                }
                else
                    throw new FileNotFoundException($"File {path} not found");
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string RemoveUnusedSymbols(string text)//удаляем неиспользуемые символы
        {
            var symbolsCollection = new[] { "(", ")", "[", "]", "}", "{", "<", ">", "\\", "--", "+", "*", "=", "\n" };
            foreach (var item in symbolsCollection)
            {
                text = text.Replace(item, "");
            }
            return text;
        }

      
        private Sentence[] GetSentenceByString(string text)
        {
            List<Sentence> sentenses = new List<Sentence>();

            var tasks = new List<Task<Sentence>>();
            var sentencesArray = text
                .Split(new[] { ".", "...", "?!", "?..", "!..", "!", "?", "\n", "\t" },
                StringSplitOptions.RemoveEmptyEntries);//удаляем пробелы(пустые записи)

            foreach (var s in sentencesArray)
            {
                tasks.Add(Task.Run(() => ParserSentences(s)));
            }
            //await Task<Sentence>.WhenAll<Sentence>(tasks);
            Task.WaitAll(tasks.ToArray());
            sentenses.AddRange(tasks.Select(t => t.Result).ToArray());
            return sentenses.ToArray();
        }



        private Sentence ParserSentences(string rawSentence)
        {

            var sentence = new Sentence();
            var words = rawSentence.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words.Where(w => !(string.IsNullOrEmpty(w)) && !(string.IsNullOrWhiteSpace(w))))
            {
                var tuple = GetPunctuationFromWord(word);
                
                if (tuple.Item1 != null)
                {
                    sentence.Add(tuple.Item1);
                }
                if (tuple.Item2 != null)
                {
                    sentence.Add(tuple.Item2);
                }

            }
            return sentence;
        }


        private Tuple<Word, Punktuation > GetPunctuationFromWord(string word)
        {
            StringBuilder Punktuation = new StringBuilder("");
            while (word != "" && !char.IsLetterOrDigit(word[word.Length - 1]) == true)
            {
                Punktuation.Append(word[word.Length - 1]);
                word = word.Remove(word.Length - 1);
            }

            return new Tuple<Word,Punktuation>(
                string.IsNullOrWhiteSpace(word) ? null
                : new Word() { Value = word },
                string.IsNullOrWhiteSpace(Punktuation.ToString())
                ? null
                : new Punktuation() { Value = Punktuation.ToString() });
        }
    }
}

