using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
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
        /// InfoString for Console or .txt files
        /// </summary>
        private static string InfoStringText(char splitter)
        {
            return $"{"Type",tSize}{splitter}" +
                    $"{"Name",tSize}{splitter}" +
                    $"{"Genre",tSize}{splitter}" +
                    $"{"Studio",tSize}{splitter}" +
                    $"{"Actor 1",tSize}{splitter}" +
                    $"{"Actor 2",tSize}{splitter}" +
                    $"{"Episodes/Date",tSize}{splitter}" +
                    $"{"Start Year/Director",tSize}{splitter}" +
                    $"{"Status/Revenue",tSize}{splitter}" +
                    $"{"End Year (Serial)",tSize}{splitter}";
        }


        /// <summary>
        /// InfoString used for CSV files for easy access
        /// </summary>
        private static string InfoStringCSV(char splitter)
        {
            return $"{"Type"}{splitter}" +
                    $"{"Name"}{splitter}" +
                    $"{"Genre"}{splitter}" +
                    $"{"Studio"}{splitter}" +
                    $"{"Actor 1"}{splitter}" +
                    $"{"Actor 2"}{splitter}" +
                    $"{"Episodes/Date"}{splitter}" +
                    $"{"Start Year/Director"}{splitter}" +
                    $"{"Status/Revenue"}{splitter}" +
                    $"{"End Year (Serial)"}{splitter}";
        }

        /// <summary>
        ///  Writes movies that all users have seen
        /// </summary>
        internal static void AllSeen(List<User> users, string fileOutput)
        {
            List<Record> allSeen = AllMovieInfo.GetAllSeen(users);
            using (StreamWriter sw = new StreamWriter(fileOutput))
            {
                sw.WriteLine(InfoStringCSV(';'));
                if (allSeen.Count > 0)
                    foreach (Record record in allSeen)
                        sw.WriteLine(record.ToString(';'));
                else
                    sw.WriteLine("No Data Found");
            }
        }

        /// <summary>
        /// Writes Initial data from List User Object
        /// </summary>
        public static void WriteInitialData(this User user, string outputPath)
        {
            using (StreamWriter sw = new StreamWriter(outputPath, append:true))
            {
                sw.WriteLine();
                sw.WriteLine($"{user.Name,tSize}|{user.BirthDate.ToShortDateString(),tSize}|{user.City,tSize}");
                sw.WriteLine();
                sw.WriteMovieList(user);
            }
        }

        /// <summary>
        /// REwrites Initial Data. Takes List<IMDB>, string outputPath. Returns void
        /// </summary>
        /// <param name="movies">List IMDB object</param>
        /// <param name="outputPath"> output path to where to write the data</param>
        public static void WriteMovieList(this StreamWriter sw, User user)
        {
            char splitter = '|';

            if (user.GetMovieCount() > 0)
            {
                sw.WriteLine(InfoStringText(splitter));

                for (int i = 0; i < user.GetMovieCount(); i++)
                {
                    Record record = user.GetMovieByIndex(i);
                    sw.WriteLine(record);
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
                    data = line.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    string type = data[0].ToLower();
                    string name = data[1];
                    string genre = data[2];
                    string studio = data[3];
                    string actor1 = data[4];
                    string actor2 = data[5];
                    switch (type)
                    {
                        case "f": // FILM
                            int date = int.Parse(data[6]);
                            string director = data[7];
                            int revenue = int.Parse(data[8]);
                            user.AddMovie(new Film(name, genre, studio, actor1, actor2, date, director, revenue));
                            break;
                        case "s": // SERIAL
                            int episodeCount = int.Parse(data[6]);
                            int startYear = int.Parse(data[7]);
                            bool status = bool.Parse(data[8]);
                            if (status == false)
                            {
                                int endYear = int.Parse(data[7]);
                                user.AddMovie(new Serial(name, genre, studio, actor1, actor2, episodeCount, startYear, endYear, status));
                            }
                            else
                                user.AddMovie(new Serial(name, genre, studio, actor1, actor2, episodeCount, startYear, status));
                            break;
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
                            Record imdb = genreCollection.Get(i);
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
        /// Reccomends User movies. Outputs to "[FirstName]_[LastName].csv" file format.
        /// </summary>
        public static void ReccomendMovies(User user)
        {
            string[] nameElements = user.Name.Split(' ');
            using (StreamWriter sw = new StreamWriter($"Rekomendacija_{nameElements[0]}_{nameElements[1]}.csv"))
            {
                char splitter = ';';
                sw.WriteLine(InfoStringCSV(splitter));

                IMDBContainer reccomendedMovies = AllMovieInfo.GetReccomendedMovies(user);
                if (reccomendedMovies.Count > 0)
                    for (int i = 0; i < reccomendedMovies.Count; i++)
                        sw.WriteLine(reccomendedMovies.Get(i).ToString(';'));
                else
                    sw.WriteLine("No Data Found");

            }
        }

        /// <summary>
        /// Prints Favorite Actors
        /// </summary>
        public static void PrintFavoriteActors(this User user)
        {
            Console.WriteLine($"{user.Name} Favorite actors are: ");
            List<string> actors = user.GetFavoriteActors();
            if (actors.Count > 0)
                foreach (string actor in actors)
                    Console.WriteLine(actor);

            else
                Console.WriteLine("No Actor Found");

            Console.WriteLine();

        }
    }
}