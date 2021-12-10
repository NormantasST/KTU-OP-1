using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    /// <summary>
    /// Saves Important Information For ALL IMDB Class Objects
    /// </summary>
    static class AllMovieInfo
    {
        private static IMDBContainer AllMovies { get; set; }
        private static Dictionary<string, int> DirectorPopularity;
        private static Dictionary<string, Record> MovieTitleSearch;
        private static Dictionary<string, IMDBContainer> GenreSearch;
        private static Dictionary<Record, Dictionary<User, bool>> MovieUsers; // First Key -> Movie, Second Key - User, Returns if the User Has seen the movie
        
        /// <summary>
        /// AllMovieInfo Static Constructor
        /// </summary>
        static AllMovieInfo()
        {
            AllMovies = new IMDBContainer();
            DirectorPopularity = new Dictionary<string, int>();
            MovieTitleSearch = new Dictionary<string, Record>();
            MovieUsers = new Dictionary<Record, Dictionary<User, bool>>();
            GenreSearch = new Dictionary<string, IMDBContainer>();
        }

       
        /// <summary>
        /// Returns reccomended Movies
        /// </summary>
        public static IMDBContainer GetReccomendedMovies(User user)
        {
            IMDBContainer output = new IMDBContainer();

            for (int i = 0; i < AllMovies.Count; i++)
            {
                Record imdb = AllMovies.Get(i);
                if (MovieUsers[imdb].ContainsKey(user) == false)
                    output.Add(imdb);
            }

            return output.Sort();
        }

        /// <summary>
        /// Gets Movies that all users have seen
        /// </summary>
        internal static List<Record> GetAllSeen(List<User> users)
        {
            List<Record> allSeen = new List<Record>();
            for (int i = 0; i < AllMovies.Count; i++)
            {
                Record record = AllMovies.Get(i);
                if(HasSeen(users, record))
                    allSeen.Add(record);

            }

            return allSeen;
        }

        /// <summary>
        /// Checks if the selected users have seen the provided record
        /// </summary>
        private static bool HasSeen(List<User> users, Record record)
        {
            foreach (User user in users)
                if (MovieUsers[record].ContainsKey(user) == false)
                    return false;

            return true;
        }

        /// <summary>
        /// Adds the movie to the AllMovieInfo Class. Adds the User who has seen the movie
        /// </summary>
        public static void AddMovie(Record imdb, User user)
        {

            if (!MovieTitleSearch.ContainsKey(imdb.Name)) // If Movie Does Not Exist, Add The movie
                AddMovie(imdb);

            AddUser(imdb, user); // Adds the User to the Movie User Container
            
        }
        
        /// <summary>
        /// Returns IMDB object by it's title
        /// </summary>
        public static Record GetMovieByTitle(string title)
        {
            if (MovieTitleSearch.ContainsKey(title))
                return MovieTitleSearch[title];
            else
                return null;
        }

        /// <summary>
        /// Adds a movie to a genre. If Genre does not exist, creates the genre.
        /// </summary>
        private static void AddToGenre(Record imdb)
        {
            if (!GenreSearch.ContainsKey(imdb.Genre)) // Adds the genre if it does not exist
                GenreSearch.Add(imdb.Genre, new IMDBContainer());
            GenreSearch[imdb.Genre].Add(imdb);

        }
        /// <summary>
        /// Adds the movie to AllMovieInfo If it does not exist
        /// </summary>
        private static void AddMovie(Record imdb)
        {
            MovieTitleSearch.Add(imdb.Name, imdb);
            AddToGenre(imdb);
            AllMovies.Add(imdb);
        }
        /// <summary>
        /// Adds User as a person who has seen the movie
        /// </summary>

        private static void AddUser(Record imdb, User user)
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
                Record imdb = user1.GetMovieByIndex(i);
                if (MovieUsers[imdb].ContainsKey(user2))
                    output.Add(imdb);
            }

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
