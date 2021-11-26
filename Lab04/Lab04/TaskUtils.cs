using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    /// <summary>
    /// TaskUtils Static Class for Computations
    /// </summary>
    static class TaskUtils
    {
        /// <summary>
        /// Gets words that appear in both string[] arrays
        /// </summary>
        private static List<string> GetDuplicates(string[] words1, string[] words2)
        {
            List<string> output = new List<string>();
            foreach (string word in words1)
                if (words2.Contains(word) && !output.Contains(word))
                    output.Add(word);
            
            return output;
        }

        /// <summary>
        /// Sorts srings by their length
        /// </summary>
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

        /// <summary>
        /// Returns words all in lowercase
        /// </summary>
        private static void LowerCaseStrings(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
                words[i] = words[i].ToLower();

        }

        /// <summary>
        /// Gets common words
        /// </summary>
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

        /// <summary>
        /// Get's words' count in words[] array from commonWords
        /// </summary>
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

        /// <summary>
        /// Gets longest sentence
        /// </summary>
        public static string LongestSentence(string[] sentences)
        {
            string longestSentence = "";
            foreach (string sentence in sentences)
                if (sentence.Length > longestSentence.Length)
                    longestSentence = sentence;

            return longestSentence;
            
        }

        /// <summary>
        /// Gets in what line the sentence starts
        /// </summary>
        public static int GetSentenceStart(string text, string sentence)
        {
            text = text.Remove(text.IndexOf(sentence));
            return text.Split('\n').Length;
        }
    }
}
