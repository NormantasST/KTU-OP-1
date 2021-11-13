using System;
using System.Collections.Generic;

namespace U4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CFd = "Duomenys2.txt";
            const string CFr = "Rezultatai.txt";
            List<int> No = InOut.LongestLine(CFd);
            InOut.RemoveLine(CFd, CFr, No);
        }
    }
}
