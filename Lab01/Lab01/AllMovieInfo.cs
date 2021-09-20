using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01
{
    /// <summary>
    /// Saves Important Information For ALL IMDB Class Objects
    /// </summary>
    static class AllMovieInfo
    {
        private static Dictionary<string, int> DirectorPopularity = new Dictionary<string, int>();

        /// <summary>
        /// Finds Directors With The Most Movies Directed. Returns List String Object.
        /// </summary>
        /// <returns></returns>
        public static List<string> FindBestDirectors()
        {
            List<string> directors = new List<string>();
            int filmsDirected = 0;

            foreach (string key in DirectorPopularity.Keys)
            {

                if (filmsDirected < DirectorPopularity[key])
                {
                    filmsDirected = DirectorPopularity[key];
                    directors.Clear();
                    directors.Add(key);
                }
                else if (filmsDirected == DirectorPopularity[key])
                {
                    directors.Add(key);
                }
            }

            return directors;
        }

        /// <summary>
        /// Adds a Movie Tally To The Director
        /// </summary>
        /// <param name="director"></param>
        public static void AddDirector(string director)
        {
            /// <summary>
            /// Records how many movies a director has directed. 
            /// </summary>

            if (DirectorPopularity.ContainsKey(director) == false)
                DirectorPopularity.Add(director, 0);

            DirectorPopularity[director]++;
        }
    }
}
