using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace _3dom
{
   public class Punktuation
    {
        public static List<string> Punct;
        internal string Value;
        public string text;

        public void GetSenteces()
        {
            Punct = new List<string>();
            string results = text;
            string pattern = @"([,.!?])";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(results);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    Punct.Add(match.Value);
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
    }
}

