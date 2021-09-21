using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02
{
    class User
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public List<IMDB> Movies { get; set; }

        public User(string name, DateTime birthDate, string city)
        {
            City = city;
            Name = name;
            Movies = new List<IMDB>();
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
            Movies.Add(imdb); // Adds the movie to this User's catologue
        }
    }
}
