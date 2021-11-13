using System;

namespace Lab04Sav1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LetterFrequency letters = new LetterFrequency();
            InOut.Repetitions("input.txt", letters);
            InOut.PrintRepetitions("ouput.txt", letters);
        }
    }
}
