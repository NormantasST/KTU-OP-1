using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    /// <summary>
    /// Task Utilities For Console And Extension Methods For Filtering
    /// </summary>
    static class TaskUtils
    {
        private const int tSize = -20;

        /// <summary>
        /// Prints Most Profitable Movies
        /// </summary>
        /// <param name="movies">List IMDB Object</param>
        public static void PrintMostProfitable(this List<IMDB> movies)
        {
            if (movies.Count == 0)
                Console.WriteLine("No Movies Found");
            else
            {
                Console.WriteLine($"{"Name",-20}|{"Director",-20}|{"Revenue",-20}");
                foreach (IMDB movie in movies)
                {
                    Console.WriteLine($"{movie.Name,-20}|{movie.Director,-20}|{movie.Revenue,6}");
                }
            }
        }

        /// <summary>
        /// Prints Directors in "PrintBestDirectors" format
        /// </summary>
        /// <param name="directors">List IMDB Object</param>
        public static void PrintBestDirectors(this List<string> directors)
        {
            Console.WriteLine("Best Directors: ");
            if (directors.Count == 0)
                Console.WriteLine("No Directors Found");
            else
                foreach (string director in directors)
                    Console.WriteLine(director);       
        }

        /// <summary>
        /// Finds Movies With Given Actor (string)
        /// </summary>
        /// <param name="movies">List IMDB object</param>
        /// <param name="actor">Actor Name to Be Searched</param>
        /// <returns></returns>
        public static List<IMDB> FindMoviesWith(this List<IMDB> movies, string actor)
        {
            List<IMDB> output = new List<IMDB>();

            foreach (IMDB movie in movies)
                if (movie.Actors.Contains(actor))
                    output.Add(movie);

            return output;
        }

        /// <summary>
        /// Finds Most Profitable Movies in a given year (int)
        /// </summary>
        /// <param name="movies">List IMDB object</param>
        /// <param name="year">int year when the movie was released</param>
        /// <returns></returns>
        public static List<IMDB> FindMostProfitable(this List<IMDB> movies, int year)
        {

            List<IMDB> output = new List<IMDB>();
            int profitability = 0;

            Console.WriteLine($"Most Profitable Movies in Year: {year}");
            foreach (IMDB movie in movies)
            {
                if (movie.Date == year)
                {
                    if (profitability < movie.Revenue)
                    {
                        profitability = movie.Revenue;
                        output.Clear();
                        output.Add(movie);
                    }
                    else if (profitability == movie.Revenue)
                    {
                        output.Add(movie);
                    }
                  
                }
            }

            return output;
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
                    Console.WriteLine($"{movie.Name,tSize}{splitter}" +
                                    $"{movie.Date,-tSize}{splitter}" +
                                    $"{movie.Genre,tSize}{splitter}" +
                                    $"{movie.Studio,tSize}{splitter}" +
                                    $"{movie.Director,tSize}{splitter}" +
                                    $"{movie.Actors[0],tSize}{splitter}" +
                                    $"{movie.Actors[1],tSize}{splitter}" +
                                    $"{movie.Revenue,10}{splitter}");
            }
            else
                Console.WriteLine("No Movies Found");
        }

    }
}
