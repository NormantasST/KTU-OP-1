using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab04Sav4
{
    static class TaskUtils
    {
        private static List<string> LowerCaseList(List<string> words)
        {
            List<string> output = new List<string>();
            foreach (string word in words)
                output.Add(word.ToLower());
            return output;
        }
    
        public static string RemoveWords(this string text, List<string> words)
        {
            List<string> lowerCaseWords = LowerCaseList(words);
            string newText = text;
            foreach (string word in lowerCaseWords)
                while (text != (newText = Regex.Replace(text, $@"((?<=[^A-z])|^)xyz[^A-Z^a-z\r]+", "", RegexOptions.ECMAScript)))
                {
                    text = newText;
                }
            
            text = newText;
            return text;

        }
    }
}
