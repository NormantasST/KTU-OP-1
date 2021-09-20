using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab01
{
    /// <summary>
    /// IMDB Movie Object
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

            AllMovieInfo.AddDirector(Director);
        }             
        // No found
    }
}
