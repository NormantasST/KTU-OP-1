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
        /// REwrites Initial Data. Takes List<IMDB>, string outputPath. Returns void
        /// </summary>
        /// <param name="movies">List IMDB object</param>
        /// <param name="outputPath"> output path to where to write the data</param>
        public static void WriteInitialData(List<IMDB> movies, string outputPath)
        {
       


            using (StreamWriter sw = new StreamWriter(outputPath))
            {
                sw.WriteLine($"{"Name",tSize}|" +
                             $"{"Date",tSize}|" +
                             $"{"Genre",tSize}|" +
                             $"{"Studio",tSize}|" +
                             $"{"Director",tSize}|" +
                             $"{"Actors",(tSize * 2) - 1}|" +
                             $"{"Revenue",-10}|");

                foreach (IMDB movie in movies)
                    sw.WriteLine($"{movie.Name,tSize}|" +
                                 $"{movie.Date,-tSize}|" +
                                 $"{movie.Genre,tSize}|" +
                                 $"{movie.Studio,tSize}|" +
                                 $"{movie.Director,tSize}|" +
                                 $"{movie.Actors[0],tSize}|" +
                                 $"{movie.Actors[1],tSize}|" +
                                 $"{movie.Revenue,10}|");
            }
        }
        
        /// <summary>
        /// Writes Data to Output File
        /// </summary>
        /// <param name="movies">List IMDB Object</param>
        /// <param name="ouputPath">Output File Path</param>
        public static void PrintMoviesToCSV(this List<IMDB> movies, string ouputPath)
        {
            using (StreamWriter sw = new StreamWriter(ouputPath))
            {
                sw.WriteLine($"{"Name",tSize};{"Date",tSize};{"Studio",tSize}");
                foreach (IMDB movie in movies)
                    sw.WriteLine($"{movie.Name};{movie.Date};{movie.Studio}");
            }

        }


        /// <summary>
        /// Reads Data, returns List IMDB Object
        /// </summary>
        /// <param name="filePath">Input File Object</param>
        /// <returns></returns>
        public static List<User> ReadData(string filePath)
        {

            List<User> output = new List<User>();
            using (StreamReader sr = new StreamReader(filePath))
            {
                User user = null;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(';');
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
                    else // Adds a new User
                    {
                        user = new User(data[0], DateTime.Parse(data[1]), data[2]);
                        output.Add(user);
                    }

                }
            }

            return output;
        }
    }
}
