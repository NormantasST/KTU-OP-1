using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab04
{
    static class TaskUtils
    {

        private static List<string> GetDuplicates(string[] words1, string[] words2)
        {
            List<string> output = new List<string>();
            foreach (string word in words1)
                if (words2.Contains(word) && !output.Contains(word))
                    output.Add(word);
            
            return output;
        }

        private static List<string> LengthSort(this List<string> data)
        {
            for (int i = 0; i < data.Count - 1; i++)
                for (int j = 0; j < data.Count - 1 - i; j++)
                    if (data[j].Length < data[j+1].Length)
                    {
                        string temp = data[j];
                        data[j] = data[j+1];
                        data[j+1] = temp;
                    }
            
            return data;
        }

        private static void LowerCaseStrings(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
                words[i] = words[i].ToLower();

        }

        public static List<string> GetCommonWords(string[] words1, string[] words2)
        {
            LowerCaseStrings(words1);
            LowerCaseStrings(words2);
            List<string> output = GetDuplicates(words1, words2);
            output.LengthSort();

            // Trims Count
            if (output.Count > 10)
                output.RemoveRange(10, output.Count - 10);
            return output;
        }

        public static Dictionary<string, int> GetRepetition(List<string> commonWords, string[] words)
        {
            Dictionary<string,int> repetition = new Dictionary<string,int>();

            foreach (string word in words)
            {
                if (commonWords.Contains(word))
                {
                    if (repetition.ContainsKey(word))
                        repetition[word]++;
                    else
                        repetition.Add(word, 1);
                }
            }

            return repetition;
        }

        public static string LongestSentence(string[] sentences)
        {
            string longestSentence = "";
            foreach (string sentence in sentences)
                if (sentence.Length > longestSentence.Length)
                    longestSentence = sentence;

            return longestSentence.Trim();
            
        }

        public static int GetSentenceStart(string text, string sentence)
        {
            text = text.Remove(text.IndexOf(sentence));
            int line =  text.Split('\r').Length;
            return line;
        }

        public static string WriteBook(string text1, string text2)
        {
            string main = text1;
            string other = text2;
            string output = "";
            while(main != "")
            {
                string word = "empty";
                word = Regex.Match(other, @"\w+", RegexOptions.IgnoreCase).Value;
                
                int index = main.IndexOf(word);
                if (index == -1)
                {
                    output += main + " ";
                    break;
                }
                else
                {
                    output += main.Substring(0, index);
                    main = main.Remove(0, index + word.Length);
                }

                // Swaps strings
                string temp = main;
                main = other;
                other = temp;
            }
            output += other;
            return output;

        }
    }
}
