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
        
        public static void RemoveWords(this string[] lines, string word)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = Regex.Replace(lines[i], $@"(?<![A-ząčęėįšųūžĄČĘĖĮŠŲŪŽ]){word}(\?|!|\.|,|:|;|\s|$)+", "", RegexOptions.IgnoreCase); 
            }
        }
    }
}
