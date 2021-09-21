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
        public List<Floor> Floors { get; set; }
        
        private int flatCount;
        public int FlatCount { get { return flatCount; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="size">Apartment floor count</param>
        public Apartment(int size)
        {
            flatCount = 0;
            Floors = new List<Floor>(new Floor[size]);
            for (int i = 0; i < Floors.Count; i++)
                Floors[i] = new Floor(i + 1);
            
        }

        /// <summary>
        /// Adds a flat to and automatically selects the floor
        /// </summary>
        /// <param name="flat">Flat Class Object</param>
        public void AddFlat(Flat flat)
        {
            Floors[flat.FloorNum - 1].AddFlat(flat);
            flatCount++;
        }
        
        /// <summary>
        /// Filters for Flats in apartment
        /// </summary>
        /// <returns>list Flat Object</returns>
        public List<Flat> FindFlatsWithRooms(int roomCount, int minFloor, int maxFloor, double maxPrice)
        {
            List<Flat> flats = new List<Flat>();
            foreach (Floor floor in Floors)
                foreach (Flat flat in floor.Flats)
                    if (flat.RoomCount == roomCount && flat.Price <= maxPrice && flat.FloorNum >= minFloor && flat.FloorNum <= maxFloor)
                        flats.Add(flat);
                
            

            return flats;
        }
    }
}
