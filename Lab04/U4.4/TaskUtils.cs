using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace U4._4
{
    class TaskUtils
    {
        public static int ProcessPalindrome(string fin, string punctuation)
        {
            string[] lines = File.ReadAllLines(fin, Encoding.UTF8);
            int equal = 0;
            foreach (string line in lines)
                if (line.Length > 0)
                    equal += FirstEqualLast(line, punctuation);
            return equal;
        }

        private static int FirstEqualLast(string line, string punctuation)
        {
            string[] parts = Regex.Split(line, punctuation);
            int equal = 0;
            foreach (string word in parts)
                if (word.Length > 0) // empty words at the end of line
                    if (Char.ToLower(word[0]) == Char.ToLower(word[word.Length - 1]))
                        equal++;
            return equal;
        }
    }
}
