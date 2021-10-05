using System;
using System.Collections.Generic;
using System.Text;

namespace Lab02.Sav04
{
    /// <summary>
    /// 1 Flat Class Object
    /// </summary>
    class Flat
    {
        public int RoomNum { get; set; }
        public int FloorNum { get; set; }
        public int RoomCount { get; set; }
        public double Area { get; set; }

        public double Price { get; set; }
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Flat(int roomNum, int floorNum, double area, int roomCount, double price, string phoneNumber)
        {
            RoomNum     = roomNum;
            FloorNum    = floorNum;
            RoomCount   = roomCount;
            Area        = area;
            Price       = price;
            PhoneNumber = phoneNumber;
        }

    }
}
