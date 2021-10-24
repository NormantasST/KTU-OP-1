using System;
using System.Collections.Generic;

namespace Lab02
{
    class Program
    {
        const string CDdata1 = @"data2-1.txt";
        const string CDdata2 = @"data2-2.txt";
        const string CDinitial = @"imdbInitial.txt";
        const string CDbothSeen = @"MatėAbu.csv";
        const string CDGenres = @"Žanrai.csv";
        static void Main(string[] args)
        {
            InOutHelpers.CreateOutputFile(CDinitial);

            List<User> users = new List<User>();
            users.Add(CDdata1).WriteInitialData(CDinitial);
            users.Add(CDdata2).WriteInitialData(CDinitial);

            users[0].GetSeenWith(users[1]).PrintMoviesToCSV(CDbothSeen);
            AllMovieInfo.GetMostProfitable().PrintToScreen();
            InOutHelpers.OutputGenres(CDGenres);
            Console.Read();

            int b = 1;
            b.ToString();

        }

    }
}
