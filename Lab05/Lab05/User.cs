using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05
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

        /// <summary>
        /// User Constructor with IMDBContainer 
        /// </summary>
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
        public void AddMovie(Record imdb)
        {
            Record temp = AllMovieInfo.GetMovieByTitle(imdb.Name);
            if (temp != null) // If the movie exists, copies the existing movie
                imdb = temp;
                
            AllMovieInfo.AddMovie(imdb, this); // Adds the movie to all movie catalogue
            movies.Add(imdb); // Adds the movie to this User's catologue
        }

        /// <summary>
        /// Returns MovieCount
        /// </summary>
        public int GetMovieCount()
        {
            return movies.Count;
        }

        public Record GetMovieByIndex(int index)
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


        /// <summary>
        /// Returns All Actors in a List
        /// </summary>
        private List<string> GetAllActors()
        {
            List<string> actors = new List<string>();
            for (int i = 0; i < movies.Count; i++)
            {
                Record record = movies.Get(i);
                actors.Add(record.Actors[0]);

                if(record.Actors[1] != record.Actors[0]) // Checks for duplicates
                    actors.Add(record.Actors[1]);
            }

            return actors;
        }

        /// <summary>
        /// GetsFavorite Director for provided User
        /// </summary>
        public List<string> GetFavoriteActors()
        {
            List<string> favoriteActors = new List<string>();
            int moviesInMax = 0;

            List<string> actors = GetAllActors();

            for (int i = 0; i < actors.Count; i++)
            {
                string currActor = actors[i];
                int moviesIn = 0;
                for (int j = i; j < actors.Count; j++)
                    if (actors[j] == currActor)
                        moviesIn++;

                // Resets
                if (moviesIn > moviesInMax)
                {
                    moviesInMax = moviesIn;
                    favoriteActors.Clear();
                }

                // Adds users
                if (moviesInMax == moviesIn)
                {
                    favoriteActors.Add(currActor);
                }
            }

            return favoriteActors;
        }

    }
}
