using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab01
{
    /// <summary>
    /// IMDB movi
    /// </summary>
    class IMDB
    {
        public string       Name     { get; set; }
        public int          Date     { get; set; }
        public string       Genre    { get; set; }
        public string       Studio   { get; set; }
        public string       Director { get; set; }
        public List<string> Actors   { get; set; }
        public int          Revenue  { get; set; }

        public static NewLass newClass { get; set; }

        private static Dictionary<string, int> DirectorPopularity = new Dictionary<string, int>();
       
        public IMDB(string name,
                    int    date,
                    string genre,
                    string studio,
                    string director,
                    string actor1,
                    string actor2,
                    int    revenue)
        {
            Name     = name;
            Date     = date;
            Genre    = genre;
            Director = director;
            Revenue  = revenue;
            Studio   = studio;

            Actors = new List<string>();
            Actors.Add(actor1);
            Actors.Add(actor2);

            newClass = new NewLass();

            AddDirector(Director);
        }             
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

        private void AddDirector(string director)
        {
            /// <summary>
            /// Records how many movies a director has directed. 
            /// </summary>
             
            if (DirectorPopularity.ContainsKey(director) == false)
                DirectorPopularity.Add(director, 0);

            DirectorPopularity[director]++;
        }

        public static List<IMDB> FindMostProfitable(List<IMDB> movies)
        {
            /// <summary>
            /// Finds the most profitable movies
            /// </summary>
            
            List<IMDB> output = new List<IMDB>();
            int profitability = 0;

            foreach (IMDB movie in movies)
            {
                if(profitability < movie.Revenue)
                {
                    profitability = movie.Revenue;
                    output.Clear();
                    output.Add(movie);
                }
                else if(profitability == movie.Revenue)
                {
                    output.Add(movie);
                }
            }

            return output;
        }
        public static List<IMDB> FindMoviesWith(string actor, List<IMDB> movies)
        {
            List<IMDB> output = new List<IMDB>();

            foreach (IMDB movie in movies)
                if (movie.Actors.Contains(actor))
                    output.Add(movie);

            return output;
        }
        // Ekrane spausdintu skilciu pavadinimus, sutvarkyti metus, txt skiltys, csv ;, skilciu pavadinimai, remove static
    }
}
