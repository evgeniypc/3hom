using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3dom
{
   public class Word
    {
        public static List<string> word;

        public string text { get;  set; }
        public string Value { get;  set; }

        public void GetSenteces()
        {
            word = new List<string>();
            string result = text;
            string pattern = @"([A-Za-z\d'-]+[$ \n.,!?])";
            string check = @"(^[A-Za-z])";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(result);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    string trim = match.Value;


                    if (Regex.IsMatch(trim, check) && (trim.Count() > 2))
                    {
                        word.Add(trim.Trim().Replace(" ", "").Replace("\n", "").Replace(",", "").Replace(".", "").Replace("!", "").Replace("?", "").ToString());
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
    }
}


