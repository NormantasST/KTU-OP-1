using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02.Sav04
{

    /// <summary>
    /// Class Object For Apartment (Physical) Object In Real Life
    /// </summary>
    class Apartment
    {
        public List<Flat> Flats { get; set; }
        
        private int flatCount;
        public int FlatCount { get { return flatCount; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Apartment floor count</param>
        public Apartment(int size)
        {
            flatCount = 0;
            Flats = new List<Flat>();
            
        }

        /// <summary>
        /// Adds a flat to and automatically selects the floor
        /// </summary>
        /// <param name="flat">Flat Class Object</param>
        public void AddFlat(Flat flat)
        {
            Flats.Add(flat);
            flatCount++;
        }
        
        /// <summary>
        /// Filters for Flats in apartment
        /// </summary>
        /// <returns>list Flat Object</returns>
        public List<Flat> FindFlatsWithRooms(int roomCount, int minFloor, int maxFloor, double maxPrice)
        {
            List<Flat> flats = new List<Flat>();
            foreach (Flat flat in Flats)
                if (flat.RoomCount == roomCount && flat.Price <= maxPrice && flat.FloorNum >= minFloor && flat.FloorNum <= maxFloor)
                    flats.Add(flat);
            
                


            return flats;
        }
    }
}
