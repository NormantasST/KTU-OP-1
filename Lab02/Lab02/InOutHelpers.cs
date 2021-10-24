using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    /// <summary>
    /// File Input Output Helper
    /// </summary>
    static class InOutHelpers
    {
        // Text formatting const
        private const int tSize = -20;

        /// <summary>
        /// Creates output file from scratch
        /// </summary>
        /// <param name="outputPath"></param>
        public static void CreateOutputFile(string outputPath)
        {
            if (File.Exists(outputPath))
                File.Delete(outputPath);

            StreamWriter sw = new StreamWriter(outputPath);
            sw.WriteLine("Initial Data:");
            sw.Close();
        }


        /// <summary>
        /// Writes Initial data from List User Object
        /// </summary>
        public static void WriteInitialData(this User user, string outputPath)
        {
            using (StreamWriter sw = new StreamWriter(outputPath, append:true))
            {
                sw.WriteLine();
                sw.WriteLine($"{user.Name,tSize}|{user.BirthDate,tSize}|{user.City,tSize}");
                sw.WriteLine();
                sw.WriteMovieList(user, '|');
            }
        }

        /// <summary>
        /// REwrites Initial Data. Takes List<IMDB>, string outputPath. Returns void
        /// </summary>
        /// <param name="movies">List IMDB object</param>
        /// <param name="outputPath"> output path to where to write the data</param>
        public static void WriteMovieList(this StreamWriter sw, User user, char splitter)
        {
            if (user.GetMovieCount() > 0)
            {
                sw.WriteLine($"{"Name",tSize}{splitter}" +
                                $"{"Date",tSize}{splitter}" +
                                $"{"Genre",tSize}{splitter}" +
                                $"{"Studio",tSize}{splitter}" +
                                $"{"Director",tSize}{splitter}" +
                                $"{"Actor 1",tSize}{splitter}" +
                                $"{"Actor 2", tSize}{splitter}" +
                                $"{"Revenue",-10}{splitter}");

                for (int i = 0; i < user.GetMovieCount(); i++)
                {
                    IMDB movie = user.GetMovieByIndex(i);
                    sw.WriteLine(movie.ToString(splitter));
                }
            }
            else
                sw.WriteLine("No Movies Found");
        }
        
        /// <summary>
        /// Writes Data to Output File
        /// </summary>
        /// <param name="movies">List IMDB Object</param>
        /// <param name="outputPath">Output File Path</param>
        public static void PrintMoviesToCSV(this List<IMDB> movies, string outputPath)
        {
            using (StreamWriter sw = new StreamWriter(outputPath))
            {
                WriteMovieList(sw, new User("temp",DateTime.Today,"temp",movies), ';');
            }

        }


        /// <summary>
        /// Reads Data, returns List IMDB Object
        /// </summary>
        /// <param name="filePath">Input File Object</param>
        /// <returns></returns>
        public static User Add(this List<User> list, string filePath)
        {

            List<User> output = new List<User>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                // Adds New User Data
                string[] data = new string[3];
                data[0] = sr.ReadLine();
                data[1] = sr.ReadLine();
                data[2] = sr.ReadLine().Trim();
                User user = new User(data[0], DateTime.Parse(data[1]), data[2]);
                list.Add(user);

                // Adds User's Movies
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    data = line.Split(';');
                    if (data.Length == 8) // Adds a movie for the user
                    {
                        IMDB imdb = new IMDB(data[0],
                                             int.Parse(data[1]),
                                             data[2],
                                             data[3],
                                             data[4],
                                             data[5],
                                             data[6],
                                             int.Parse(data[7]));
                        user.AddMovie(imdb);
                    }
                }

                return user;
            }
        }

        /// <summary>
        /// Outputs movie genres to csv file
        /// </summary>
        /// <param name="outputFile"></param>
        public static void OutputGenres(string outputFile)
        {
            List<string> genres = AllMovieInfo.GetAllGenres();
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                if (genres.Count > 0)
                {
                    foreach (var genre in genres)
                    {
                        sw.Write(genre);
                        foreach (IMDB imdb in AllMovieInfo.GetMoviesWithGenre(genre))
                        {
                            sw.Write($";{imdb.Name}");
                        }
                        sw.WriteLine();
                    }
                }
                else
                    sw.WriteLine("No Data Found");
            }
        }

        /// <summary>
        /// Print to screen function
        /// </summary>
        /// <param name="movies"></param>
        public static void PrintToScreen(this List<IMDB> movies)
        {
            char splitter = '|';
            Console.WriteLine("Most Profitable Movies");

            if (movies.Count > 0)
            {
                Console.WriteLine($"{"Name",tSize}{splitter}" +
                                $"{"Date",tSize}{splitter}" +
                                $"{"Genre",tSize}{splitter}" +
                                $"{"Studio",tSize}{splitter}" +
                                $"{"Director",tSize}{splitter}" +
                                $"{"Actor 1",tSize}{splitter}" +
                                $"{"Actor 2",tSize}{splitter}" +
                                $"{"Revenue",-10}{splitter}");

                foreach (IMDB movie in movies)
                    Console.WriteLine(movie.ToString(splitter));
            }
            else
                Console.WriteLine("No Movies Found");
        }
    }
}
