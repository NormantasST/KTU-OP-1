using System;

namespace Lab02.Sav04
{
    class Program
    {
        private const string CDinput = @"data.txt";
        private const string CDoutput = @"output.txt";
        static void Main(string[] args)
        {
            Apartment apartment = InOutHelpers.ReadData(CDinput);
            apartment.WriteData(CDoutput, "Initial Data");
            apartment.FindFlatsWithRooms(2, 2, 4, 300).WriteData(CDoutput, "Filtered Data:");
        }
    }
}
