using System;

namespace U4._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys.txt";
            char[] punctuation = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };
            Console.WriteLine("Sutampančių žodžių {0, 3:d}", TaskUtils.Process(CFd, new string(punctuation)));
        }
    }
}
