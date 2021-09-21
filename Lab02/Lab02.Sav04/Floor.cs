using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02.Sav04
{
    /// <summary>
    /// Floor Class Object
    /// </summary>
    class Floor
    {
        public List<Flat> Flats { get; set; }
        public int FloorNum { get; set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        public Floor(int floorNum)
        {
            FloorNum = floorNum;
            Flats = new List<Flat>();
        }
        /// <summary>
        /// Adds a flat to this specified Floor Class Object
        /// </summary>
        public void AddFlat(Flat flat)
        {
            Flats.Add(flat);
        }
    }
}
