using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace K2_Pasiruošimas
{
    static class TaskUtils
    {
        public static void PerformTask(string fd, string fr)
        {
            string noNumbers = "";
            using (StreamReader sr = new StreamReader(fd))
            {
                string punctuation = sr.ReadLine();
                string line;
                using (StreamWriter sw = new StreamWriter(fr))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string longestWord = FindWord1Line(line, punctuation);
                        string newLine = EditLine(line, punctuation, longestWord);
                        sw.WriteLine(newLine);
                        string noNumberWord = FindWord2Line(line, punctuation);
                        noNumberWord = Regex.Match(noNumberWord, @"\w+").Value;
                        noNumbers += $"{noNumberWord}\r\n";
                    }
                    sw.WriteLine(noNumbers);
                }
                
            }
        }

        public static string FindWord2Line(string line, string punctuation)
        {
            string outputWord = "";
            foreach (Match match in Regex.Matches(line, $@"({punctuation}|^)\w+"))
            {
                string word = Regex.Match(match.Value, @"\w+").Value;
                if (NoDigits(word))
                    outputWord = match.Value;
            }
            return outputWord;
        }

        public static string EditLine(string line, string punctuation, string word)
        {
            Match match = Regex.Match(line,$@"({punctuation}|^){word}");
            line = match.Value + "" + line.Remove(match.Index, match.Value.Length);
            return line;
        }

        public static string FindWord1Line(string line, string punctuation)
        {
            string[] words = Regex.Split(line, punctuation);
            string longestWord = "";
            foreach (string word in words)
                if(NumberDifferentVowelsInLine(word) >= 3)
                    if(word.Length > longestWord.Length)
                        longestWord = word;
            
            return longestWord;
        }

        public static int NumberDifferentVowelsInLine(string line)
        {
            line = line.ToLower();
            int vowelCount = 0;
            string vowels = "aeiuo";
            foreach (char vowel in vowels)
            {
                if (line.Contains(vowel))
                    vowelCount++;
            }

            return vowelCount;
        }

        public static bool NoDigits(string line)
        {
            string digits = "0123456789";

            foreach (char digit in digits)
                if (line.Contains(digit))
                    return false;
            return true;
        }
    }
}
