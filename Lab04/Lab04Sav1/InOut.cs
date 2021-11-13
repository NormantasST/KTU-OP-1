using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04Sav1
{
    static class InOut
    {
        public static void RepetitionsSorted(string fout, LettersFrequency letters)
        {
            using (var writer = File.CreateText(fout))
            {
                char[] sortedLetters = letters.GetSortedLetterString();
                foreach (char ch in sortedLetters)
                {
                    writer.WriteLine("{0, 3:c} {1, 4:d} |{2, 3:c} {3, 4:d}", ch,
                    letters.Get(ch), Char.ToUpper(ch), letters.Get(Char.ToUpper(ch)));
                }
            }
        }

        public static void Repetitions(string fin, LettersFrequency letters)
        {
            foreach (string line in File.ReadAllLines(fin))
                foreach (char ch in line)
                    letters.Add(ch);
        }

        public static void PrintRepetitions(string fout, LettersFrequency letters)
        {
            using (var writer = File.CreateText(fout))
            {
                foreach (char ch in letters.Alphabet)
                    writer.WriteLine("{0, 3:c} {1, 4:d} |{2, 3:c} {3, 4:d}", ch,
                   letters.Get(ch), Char.ToUpper(ch), letters.Get(Char.ToUpper(ch)));
            }
        }
    }
}
