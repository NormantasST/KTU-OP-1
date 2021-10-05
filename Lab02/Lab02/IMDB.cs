using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab02
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
        }

        /// <summary>
        /// Equals() Method Override
        /// </summary>
        public override bool Equals(object otherObj)
        {
            return this.Name == ((IMDB)otherObj).Name;
        }


        /// <summary>
        /// Returns IMDB.Name's hashcode
        /// </summary>
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        /// <summary>
        /// ToString() override
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ToString('|');
        

        /// <summary>
        /// ToString()
        /// </summary>
        /// <returns></returns>
        public string ToString(char splitter)
        {
            
            return  $"{this.Name,-20}{splitter}" +
                    $"{this.Date,20}{splitter}" +
                    $"{this.Genre,-20}{splitter}" +
                    $"{this.Studio,-20}{splitter}" +
                    $"{this.Director,-20}{splitter}" +
                    $"{this.Actors[0],-20}{splitter}" +
                    $"{this.Actors[1],-20}{splitter}" +
                    $"{this.Revenue,10}{splitter}";
        }
    }
}
