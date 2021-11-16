using System;
using System.Collections.Generic;
using System.IO;

namespace Lab04Sav4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Char.IsLetter('!'));
            const string input = "Duomenys4.txt";
            const string output = "output.txt";
            List<string> words = new List<string>("xyz".Split(';'));
            string text = File.ReadAllText(input);
            text = text.RemoveWords(words);
            text.WriteLines(output);
        }
    }
}
