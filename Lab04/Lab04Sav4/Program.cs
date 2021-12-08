using System;
using System.Collections.Generic;
using System.IO;

namespace Lab04Sav4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string input = "Duomenys4.txt";
            const string output = "output.txt";
            string[] lines = File.ReadAllLines(input);
            TaskUtils.RemoveWords(lines, "xyz");
            InOut.WriteLines(lines, output);
        }
    }
}
