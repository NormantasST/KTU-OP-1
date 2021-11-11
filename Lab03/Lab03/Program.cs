using System;
using System.Collections.Generic;

namespace Lab03
{
    class Program
    {
        // Output/Input location path declarations
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

            // Most profitable
            InOutHelpers.PrintToScreen(AllMovieInfo.GetMostProfitable(), "Most Profitable Movies:");

            // Movie reccomendations
            InOutHelpers.PrintStrings(user1.GetFavoriteDirector(), $"{user1.Name} Favorite Director(s):");
            InOutHelpers.PrintStrings(user2.GetFavoriteDirector(), $"{user2.Name} Favorite Director(s):");

            // Genres
            InOutHelpers.OutputGenres(CDGenres);

            // Movie Reccomendation
            InOutHelpers.ReccomendMovies(user1);
            InOutHelpers.ReccomendMovies(user2);

            Console.Read();
        }

    }
}
