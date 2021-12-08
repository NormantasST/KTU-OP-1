using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Lab04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string input1 = "Knyga1.txt";
            const string input2 = "Knyga2.txt";
            const string output = "Rodikliai.txt";

            char[] sentenceChar = { '!', '?', '.' };
            char[] punctuation = {' ','.', ',', '!', '?', '.', ':', ';', '(', ')', '\t', '\r', '\n', '\'', '"' };

            // Reads Data
            string text1 = InOut.ReadText(input1);
            string text2 = InOut.ReadText(input2);

            // Creates Sentence List
            string[] sentences1 = text1.Split(sentenceChar);
            string[] sentences2 = text2.Split(sentenceChar);

            // Creates word List
            string[] words1 = text1.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            string[] words2 = text2.Split(punctuation, StringSplitOptions.RemoveEmptyEntries);
            
            // Creates Intial File
            InOut.CreateFile(output);

            // Common Word Count
            List<string> CommonWords = TaskUtils.GetCommonWords(words1, words2);
            InOut.WriteWordRepetitions(CommonWords, 
                                       TaskUtils.GetRepetition(CommonWords, words1), 
                                       output, $"{input1} Common Word Count:");

            InOut.WriteWordRepetitions(CommonWords, 
                                       TaskUtils.GetRepetition(CommonWords, words2), 
                                       output, $"{input2} Common Word Count:");

            // Sentences
            InOut.WriteLongestSentence(output, 
                                       $"{input1} Longest Sentence Info:", 
                                       sentences1, 
                                       text1);

            InOut.WriteLongestSentence(output, 
                                       $"{input2} Longest Sentence Info:", 
                                       sentences2, 
                                       text2);

            InOut.WriteString("ManoKnyga.txt", TaskUtils.WriteBook(text1, text2));
        }
    }
}
