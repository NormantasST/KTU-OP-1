using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab04Sav3
{
    static class TaskUtils
    {
        private static string punctuation = "[\\s,.;:!?()\\-]+";

        public static int ProcessPalindrome(string input)
        {
            int count = 0;
            foreach (string line in File.ReadAllLines(input))
                count += GetPalindromeCount(line);

            return count;
        }
        public static int GetPalindromeCount(string line)
        {
            int count = 0;
            foreach (string word in Regex.Split(line, punctuation))
            {
                bool isPalindrome = true;
                for (int i = 0; i < word.Length / 2; i++)
                {
                    if(Char.ToLower(word[i]) != Char.ToLower(word[word.Length - 1 - i]))
                    {
                        isPalindrome = false;
                        break;
                    } 
                }

                if (isPalindrome)
                    count++;
            }

            return count;
        }
    }
}
