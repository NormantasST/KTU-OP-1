using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02
{
    /// <summary>
    /// Saves Important Information For ALL IMDB Class Objects
    /// </summary>
    static class AllMovieInfo
    {
        private static List<IMDB> AllMovies { get; set; }
        private static Dictionary<string, int> DirectorPopularity;
        private static Dictionary<string, IMDB> MovieTitleSearch;
        private static Dictionary<string, List<IMDB>> GenreSearch;
        private static Dictionary<IMDB, Dictionary<User, bool>> MovieUsers; // First Key -> Movie, Second Key - User, Returns if the User Has seen the movie
        static AllMovieInfo()
        {
            AllMovies = new List<IMDB>();
            DirectorPopularity = new Dictionary<string, int>();
            MovieTitleSearch = new Dictionary<string, IMDB>();
            MovieUsers = new Dictionary<IMDB, Dictionary<User, bool>>();
            GenreSearch = new Dictionary<string, List<IMDB>>();
        }

        /// <summary>
        /// Finds Directors With The Most Movies Directed. Returns List String Object.
        /// </summary>
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
        /// Adds the movie to the AllMovieInfo Class. Adds the User who has seen the movie
        /// </summary>
        public static void AddMovie(IMDB imdb, User user)
        {

            if (!MovieTitleSearch.ContainsKey(imdb.Name)) // If Movie Does Not Exist, Add The movie
                AddMovie(imdb);

            AddUser(imdb, user); // Adds the User to the Movie User List
            
        }
        
        /// <summary>
        /// Returns IMDB object by it's title
        /// </summary>
        public static IMDB GetMovieByTitle(string title)
        {
            if (MovieTitleSearch.ContainsKey(title))
                return MovieTitleSearch[title];
            else
                return null;
        }

        /// <summary>
        /// Adds a movie to a genre. If Genre does not exist, creates the genre.
        /// </summary>
        private static void AddToGenre(IMDB imdb)
        {
            if (!GenreSearch.ContainsKey(imdb.Genre)) // Adds the genre if it does not exist
                GenreSearch.Add(imdb.Genre, new List<IMDB>());
            GenreSearch[imdb.Genre].Add(imdb);

        }
        /// <summary>
        /// Adds the movie to AllMovieInfo If it does not exist
        /// </summary>
        private static void AddMovie(IMDB imdb)
        {
            MovieTitleSearch.Add(imdb.Name, imdb);
            AddToGenre(imdb);
            AddDirector(imdb.Director);
            AllMovies.Add(imdb);
        }
        /// <summary>
        /// Adds User as a person who has seen the movie
        /// </summary>

        private static void AddUser(IMDB imdb, User user)
        {
            if (!MovieUsers.ContainsKey(imdb))
                MovieUsers.Add(imdb, new Dictionary<User, bool>());

            MovieUsers[MovieTitleSearch[imdb.Name]].Add(user, true);
        }


        /// <summary>
        /// Adds a Movie Tally To The Director
        /// </summary>
        /// <param name="director"></param>
        private static void AddDirector(string director)
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
