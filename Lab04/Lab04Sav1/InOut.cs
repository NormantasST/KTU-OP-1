using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04Sav1
{
    class InOut
    {
        public static void PrintRepetitions(string fout, LetterFrequency letters)
        {
            using (StreamWriter sw = new StreamWriter(fout))
                foreach (char letter in letters.Alphabet)
                    sw.WriteLine($"{letter,3} {letters.Get(letter),3} | {Char.ToLower(letter),3} {letters.Get(Char.ToLower(letter)),3}");
            
        }
        public static void Repetitions(string fin, LetterFrequency letters)
        {
            using (StreamReader reader = new StreamReader(fin))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    foreach (char letter in line)
                        letters.Add(letter);
            }
        }
    }
}
