using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab05
{
    /// <summary>
    /// IMDB Movie Object
    /// </summary>
    public abstract class Record
    {
        public string       Name     { get; set; }
        public string       Genre    { get; set; }
        public string       Studio   { get; set; }
        public List<string> Actors   { get; set; }
        

        /// <summary>
        /// Constructor
        /// </summary>
        public Record(string name,
                    string genre,
                    string studio,
                    string actor1,
                    string actor2)
        {
            Name     = name;
            Genre    = genre;
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
            return this.Name == ((Record)otherObj).Name;
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
        public virtual string ToString(char splitter)
        {

            return $"{this.Name,-20}{splitter}" +
                    $"{this.Genre,-20}{splitter}" +
                    $"{this.Studio,-20}{splitter}" +
                    $"{this.Actors[0],-20}{splitter}" +
                    $"{this.Actors[1],-20}{splitter}";
        }

        /// <summary>
        /// Compare To Method implementation
        /// </summary>
        internal int CompareTo(Record record)
        {
            int comparison = Genre.CompareTo(record.Genre);
            if (comparison == 0)
                comparison = Name.CompareTo(record.Name);

            return comparison;
        }
    }
}
