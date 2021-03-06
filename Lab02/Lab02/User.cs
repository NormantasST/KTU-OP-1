using System;
using System.Text;

namespace Lab03
{
    /// <summary>
    /// User Class Object.
    /// Saves Name, BirthDate, City, Seen Movies
    /// </summary>
    class User
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }

        private IMDBContainer movies;

        public User(string name, DateTime birthDate, string city)
        {
            City = city;
            Name = name;
            movies = new IMDBContainer();
            BirthDate = birthDate;
        }

        public User(string name, DateTime birthDate, string city, IMDBContainer _movies)
        {
            City = city;
            Name = name;
            movies = _movies;
            BirthDate = birthDate;
        }

        /// <summary>
        /// Adds the movie to users catologue
        /// </summary>
        public void AddMovie(IMDB imdb)
        {
            IMDB temp = AllMovieInfo.GetMovieByTitle(imdb.Name);
            if (temp != null) // If the movie exists, copies the existing movie
                imdb = temp;
                
            AllMovieInfo.AddMovie(imdb, this); // Adds the movie to all movie catalogue
            movies.Add(imdb); // Adds the movie to this User's catologue
        }

        public int GetMovieCount()
        {
            return movies.Count;
        }

        public IMDB GetMovieByIndex(int index)
        {
            try
            {
                return movies.Get(index);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Comparison Methods
        /// </summary>
        public static bool operator < (User user1, User user2)
        {
            return user1.GetMovieCount() < user2.GetMovieCount();
        }
        public static bool operator > (User user1, User user2)
        {
            return user1.GetMovieCount() < user2.GetMovieCount();
        }

        /// <summary>
        /// ToString() override
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Name} {this.BirthDate} {this.City}";
        }
    }
}
