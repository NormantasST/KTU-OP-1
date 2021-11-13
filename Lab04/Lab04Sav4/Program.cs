using System;
using System.Collections.Generic;

namespace Lab04Sav4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string input = "data.txt";
            const string output = "output.txt";
            List<string> words = new List<string>("lorem;ipsum;ut;in;fugiat".Split(';'));
            List<string> lines = InOut.ReadLines(input);
            lines.RemoveWords(words);
            lines.WriteLines(output);
        }
    }
}
