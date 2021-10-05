using System;
using System.Collections.Generic;

namespace Lab02
{
    class Program
    {
        const string CDdata = @"data2.txt";
        const string CDinitial = @"imdbInitial.txt";
        const string CDbothSeen = @"MatėAbu.csv";
        const string CDGenres = @"Žanrai.csv";
        static void Main(string[] args)
        {
            List<User> users = InOutHelpers.ReadData(CDdata);
            InOutHelpers.WriteInitialData(users, CDinitial);
            users[0].GetSeenWith(users[1]).PrintMoviesToCSV(CDbothSeen);
            AllMovieInfo.GetMostProfitable().PrintToScreen();
            InOutHelpers.OutputGenres(CDGenres);
            Console.Read();

            // Add User.AddFile(other files)
            // If new user added, append new data
            // Skaitym
        }
    }
}
