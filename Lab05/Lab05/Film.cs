using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    /// <summary>
    /// Film Class, Inherited from Record
    /// </summary>
    class Film : Record
    {
        public int RealeaseDate { get; set; }
        public string Director { get; set; }
        public int Revenue { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        public Film(string name, string genre, string studio, string actor1, string actor2, int date, string director, int revenue) : base(name, genre, studio, actor1, actor2)
        {
            RealeaseDate = date;
            Director = director;
            Revenue = revenue;
        }

        /// <summary>
        /// ToString() Override
        /// </summary>
        public override string ToString()
        {
            return ToString('|');
        }

        /// <summary>
        /// ToString(char splitter) Override
        /// </summary>
        public override string ToString(char splitter)
        {

            string output = $"{"Film",-20}{splitter}" +
                   base.ToString(splitter) +
                   $"{RealeaseDate,-20}{splitter}" +
                   $"{Director, -20}{splitter}" +
                   $"{Revenue, 20}{splitter}";

            return output;
        }
    }
}
