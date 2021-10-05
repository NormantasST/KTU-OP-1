using System;
using System.Collections.Generic;

namespace Lab02.Sav04
{
    class Program
    {
        private const string CDinput = @"data2.txt";
        private const string CDoutput = @"output.txt";
        static void Main(string[] args)
        {
            Apartment apartment = InOutHelpers.ReadData(CDinput);
            apartment.WriteData(CDoutput, "Initial Data");
            List<Flat> filteredFlats = apartment.FindFlatsWithRooms(8,3,3,500000);
            filteredFlats.WriteData(CDoutput, "Filtered Data:");
        }
    }
}
