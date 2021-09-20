using System;
using System.Collections.Generic;

namespace Lab01
{
    class Program
    {
        const string CDd = @"imdb3.txt";
        const string CDinitial = @"imdbInitial.txt";
        const string CDcsv = @"MoviesWith.csv";
        static void Main(string[] args)
        {
            List<IMDB> imdb = InOutHelpers.ReadData(CDd);
            InOutHelpers.WriteInitialData(imdb, CDinitial);
            imdb.FindMostProfitable(2019).PrintMostProfitable();
            Console.WriteLine(new string('-', 74));
            AllMovieInfo.FindBestDirectors().PrintBestDirectors();
            imdb.FindMoviesWith("N. Cage").PrintMoviesToCSV(CDcsv);
            Console.ReadLine();
        }
    }
}
