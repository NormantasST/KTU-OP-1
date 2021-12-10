using System;
using System.Collections.Generic;

namespace Lab05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Paths:
            const string FD1 = "data1-1.txt";
            const string FD2 = "data1-2.txt";
            const string FD3 = "data1-3.txt";
            const string FOgenres = "Žanrai.csv";
            const string FOseenAll = "MatėVisi.csv";
            const string FOmain = "output.txt";

            // Reads Initial Data and Rewrites initial Data
            InOutHelpers.CreateOutputFile(FOmain);
            List<User> users = new List<User>();
            users.Add(InOutHelpers.ReadUser(FD1)); 
            InOutHelpers.WriteInitialData(users[0], FOmain);
            users.Add(InOutHelpers.ReadUser(FD2));
            InOutHelpers.WriteInitialData(users[1], FOmain);
            users.Add(InOutHelpers.ReadUser(FD3));
            InOutHelpers.WriteInitialData(users[2], FOmain);
            //users.Add(InOutHelpers.ReadUser("data1-4.txt"));
            //InOutHelpers.WriteInitialData(users[3], FOmain);

            // T1 Prints User's favorite actor/actors
            users[0].PrintFavoriteActors();
            users[1].PrintFavoriteActors();
            users[2].PrintFavoriteActors();
            //users[3].PrintFavoriteActors();

            // T2 Seen Both
            InOutHelpers.AllSeen(users, FOseenAll);


            // T3 Reccomendation csv Files 
            InOutHelpers.ReccomendMovies(users[0]);
            InOutHelpers.ReccomendMovies(users[1]);
            InOutHelpers.ReccomendMovies(users[2]);
            //InOutHelpers.ReccomendMovies(users[3]);

            // T4 Outputs Genres
            InOutHelpers.OutputGenres(FOgenres);
        }
    }
}
