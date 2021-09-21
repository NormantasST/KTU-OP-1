using System;
using System.Collections.Generic;

namespace Lab02
{
    class Program
    {
        const string CDdata = @"data.txt";
        const string CDinitial = @"imdbInitial.txt";
        const string CDbothSeen = @"MatėAbu.csv";
        const string CDGenres = @"Žanrai.csv";
        static void Main(string[] args)
        {
            List<User> users = InOutHelpers.ReadData(CDdata);
        }
    }
}
