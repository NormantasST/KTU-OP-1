using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
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
        /// Reads Data, returns List IMDB Object
        /// </summary>
        /// <param name="filePath">Input File Object</param>
        /// <returns></returns>
        public static User ReadUser(string filePath)
        {
            User user;
            using (StreamReader sr = new StreamReader(filePath))
            {
                // Adds New User Data
                string[] data = new string[3];
                data[0] = sr.ReadLine();
                data[1] = sr.ReadLine();
                data[2] = sr.ReadLine().Trim();
                user = new User(data[0], DateTime.Parse(data[1]), data[2]);

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

            }
            return user;
        }

        /// <summary>
        /// Outputs movie genres to csv file
        /// </summary>
        /// <param name="outputFile"></param>
        public static void OutputGenres(string outputFile)
        {
            string[] genres = AllMovieInfo.GetAllGenres();
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                if (genres.Length > 0)
                {
                    foreach (var genre in genres)
                    {
                        sw.Write(genre);
                        IMDBContainer genreCollection = AllMovieInfo.GetMoviesWithGenre(genre);
                        for (int i = 0; i < genreCollection.Count; i++)
                        {
                            IMDB imdb = genreCollection.Get(i);
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
        public static void PrintToScreen(this IMDBContainer movies, string header)
        {
            char splitter = '|';
            Console.WriteLine(header);

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

                for (int i = 0; i < movies.Count; i++)
                    Console.WriteLine(movies.Get(i).ToString(splitter));
            }
            else
                Console.WriteLine("No Movies Found");

            Console.WriteLine();
        }

        public static void PrintStrings(string[] strings, string header)
        {
            Console.WriteLine(header);
            for (int i = 0; i < strings.Length; i++)
                Console.WriteLine(strings[i]);

            Console.WriteLine();
        }

        public static void ReccomendMovies(User user)
        {
            string[] nameElements = user.Name.Split(' ');
            using (StreamWriter sw = new StreamWriter($"Rekomendacija_{nameElements[0]}_{nameElements[1]}.csv"))
            {
                char splitter = ';';
                sw.WriteLine($"{"Name",tSize}{splitter}" +
                                    $"{"Date",tSize}{splitter}" +
                                    $"{"Genre",tSize}{splitter}" +
                                    $"{"Studio",tSize}{splitter}" +
                                    $"{"Director",tSize}{splitter}" +
                                    $"{"Actor 1",tSize}{splitter}" +
                                    $"{"Actor 2",tSize}{splitter}" +
                                    $"{"Revenue",-10}{splitter}");

                IMDBContainer reccomendedMovies = AllMovieInfo.GetReccomendedMovies(user).Sort();

                for (int i = 0; i < reccomendedMovies.Count; i++)
                    sw.WriteLine(reccomendedMovies.Get(i).ToString(';'));

            }
        }
    }
}
