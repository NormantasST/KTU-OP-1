using System;
using System.Collections.Generic;

namespace Lab03
{
    class Program
    {
        const string CDdata1 = @"data1-1.txt";
        const string CDdata2 = @"data1-2.txt";
        const string CDoutput = @"imdbInitial.txt";
        const string CDGenres = @"Žanrai.csv";
        static void Main(string[] args)
        {
            InOutHelpers.CreateOutputFile(CDoutput);

            User user1 = InOutHelpers.ReadUser(CDdata1);
            user1.WriteInitialData(CDoutput);
            User user2 = InOutHelpers.ReadUser(CDdata2);
            user2.WriteInitialData(CDoutput);

            InOutHelpers.PrintToScreen(AllMovieInfo.GetMostProfitable(), "Most Profitable Movies:");
            InOutHelpers.OutputGenres(CDGenres);
            InOutHelpers.ReccomendMovies(user1);
            InOutHelpers.ReccomendMovies(user2);
            
            // Selection sort and Sort ReccomendMovies
            // Add Favorite Director
        }

    }
}
