using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    static class InOut
    {
        // Punctuation string
        private static char[] punctuation = { ' ', '.', ',', '!', '?', '.', ':', ';', '(', ')', '\t', '\r', '\n', '\'', '"' };

        /// <summary>
        /// Creates file for output
        /// </summary>
        public static void CreateFile(string output)
        {
            new StreamWriter(output).Close();
        }

        /// <summary>
        /// Writes words that appear in both files
        /// </summary>
        public static void WriteWordRepetitions(List<string> commonWords, Dictionary<string, int> repetitions, string output, string header)
        {
            using (StreamWriter sw = new StreamWriter(output, append: true))
            {
                sw.WriteLine(header);
                sw.WriteLine(new string('-', header.Length));
                foreach (string word in commonWords)
                    sw.WriteLine($"{word, 25}: {repetitions[word]}");

                sw.WriteLine();
            }
        }

        /// <summary>
        /// Reads text
        /// </summary>
        public static string ReadText(string input)
        {
            return File.ReadAllText(input, Encoding.UTF8);
        }

        /// <summary>
        /// Writes The longest sentence per file
        /// </summary>
        public static void WriteLongestSentence(string output, string header, string[] sentences, string text)
        {
            using (StreamWriter sw = new StreamWriter(output, append:true))
            {
                sw.WriteLine(header);
                sw.WriteLine(new string('-', header.Length));
                string sentence = TaskUtils.LongestSentence(sentences);
                sw.WriteLine($"Longest Sentence is: {sentence}");
                sw.WriteLine($"Symbol Count: {sentence.Length} Word Count: {sentence.Split(punctuation, StringSplitOptions.RemoveEmptyEntries).Length}");
                sw.WriteLine($"Line Where the Sentence Starts: {TaskUtils.GetSentenceStart(text, sentence)}");
                sw.WriteLine();
            }
        }

        /// <summary>
        /// Writes a string to output
        /// </summary>
        public static void WriteString(string output, string text)
        {
            using (StreamWriter sw = new StreamWriter(output))
                sw.WriteLine(text);
            
        }
    }
}
