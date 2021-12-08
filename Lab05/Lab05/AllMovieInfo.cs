using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    /// <summary>
    /// Saves Important Information For ALL IMDB Class Objects
    /// </summary>
    static class AllMovieInfo
    {
        private static IMDBContainer AllMovies { get; set; }
        private static Dictionary<string, int> DirectorPopularity;
        private static Dictionary<string, IMDB> MovieTitleSearch;
        private static Dictionary<string, IMDBContainer> GenreSearch;
        private static Dictionary<IMDB, Dictionary<User, bool>> MovieUsers; // First Key -> Movie, Second Key - User, Returns if the User Has seen the movie
        static AllMovieInfo()
        {
            AllMovies = new IMDBContainer();
            DirectorPopularity = new Dictionary<string, int>();
            MovieTitleSearch = new Dictionary<string, IMDB>();
            MovieUsers = new Dictionary<IMDB, Dictionary<User, bool>>();
            GenreSearch = new Dictionary<string, IMDBContainer>();
        }

        public static IMDBContainer GetReccomendedMovies(User user)
        {
            IMDBContainer output = new IMDBContainer();

            for (int i = 0; i < AllMovies.Count; i++)
            {
                IMDB imdb = AllMovies.Get(i);
                if (MovieUsers[imdb].ContainsKey(user) == false)
                    output.Add(imdb);
            }

            return output;
        }

        /// <summary>
        /// Adds the movie to the AllMovieInfo Class. Adds the User who has seen the movie
        /// </summary>
        public static void AddMovie(IMDB imdb, User user)
        {

            if (!MovieTitleSearch.ContainsKey(imdb.Name)) // If Movie Does Not Exist, Add The movie
                AddMovie(imdb);

            AddUser(imdb, user); // Adds the User to the Movie User Container
            
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
                GenreSearch.Add(imdb.Genre, new IMDBContainer());
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

        /// <summary>
        /// Gets Movies that both users have seen
        /// </summary>
        /// <param name="user1"></param>
        /// <param name="user2"></param>
        /// <returns></returns>
        public static IMDBContainer GetSeenWith(this User user1, User user2)
        {
            IMDBContainer output = new IMDBContainer();

            for(int i = 0; i < user1.GetMovieCount(); i++)
            {
                IMDB imdb = user1.GetMovieByIndex(i);
                if (MovieUsers[imdb].ContainsKey(user2))
                    output.Add(imdb);
            }

            return output;
        }

        /// <summary>
        /// Gets the most profitable movies
        /// </summary>
        public static IMDBContainer GetMostProfitable()
        {
            int profit = int.MinValue;
            IMDBContainer output = new IMDBContainer();
            for (int i = 0; i < AllMovies.Count; i++)
            {
                IMDB imdb = AllMovies.Get(i);
                if(profit < imdb.Revenue)
                {
                    profit = imdb.Revenue;
                    output.Clear();
                }

                if (profit == imdb.Revenue)
                    output.Add(imdb);
            }

            output.Sort();

            return output;
        }

        /// <summary>
        /// Returns all the keys of GenreSearch Object
        /// </summary>
        public static string[] GetAllGenres()
        {
            return GenreSearch.Keys.ToArray();
        }

        /// <summary>
        /// Return all the movies with specified genre
        /// </summary>
        public static IMDBContainer GetMoviesWithGenre(string key)
        {
            if (GenreSearch.ContainsKey(key))
                return GenreSearch[key];
            else
                return new IMDBContainer();
        }
    }
}
