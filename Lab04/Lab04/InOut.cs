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
        private static char[] punctuation = { ' ', '.', ',', '!', '?', '.', ':', ';', '(', ')', '\t', '\r', '\n', '\'', '"' };

        public static void CreateFile(string output)
        {
            new StreamWriter(output).Close();
        }

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

        public static void Write(string[] sentences, string output, string header)
        {
            using (StreamWriter sw = new StreamWriter(output, append: true))
            {
                sw.WriteLine(header);
                sw.WriteLine(new string('-', header.Length));
                foreach (string line in sentences)
                    sw.Write(line);

                sw.WriteLine();
                sw.WriteLine();
            }
        }

        public static string ReadText(string input)
        {
            return File.ReadAllText(input, Encoding.UTF8);
        }

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
    }
}
