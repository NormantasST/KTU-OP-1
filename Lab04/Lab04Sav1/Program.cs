using System;

namespace Lab04Sav1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            const string CFr = "Rezultatai.txt";
            const string CFrSorted = "Rezultatai_Sorted.txt";
            LettersFrequency letters = new LettersFrequency();
            InOut.Repetitions(CFd, letters);
            Console.WriteLine($"Sorted letter string: {new string(letters.GetSortedLetterString())}");
            InOut.RepetitionsSorted(CFrSorted, letters);
            InOut.PrintRepetitions(CFr, letters);
        }
    }
}
