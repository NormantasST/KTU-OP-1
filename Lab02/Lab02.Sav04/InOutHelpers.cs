using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab02.Sav04
{
    /// <summary>
    /// File Input, Output static Helper Class
    /// </summary>
    static class InOutHelpers
    {
        private const int fSize = -20; // Format Size for strings

        /// <summary>
        /// Reads data from .txt file
        /// </summary>
        public static Apartment ReadData(string fileName)
        {
            Apartment apartment = new Apartment(9);
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] values = line.Split(';');
                Flat flat = new Flat(int.Parse(values[0]),
                                     int.Parse(values[1]),
                                     int.Parse(values[2]),
                                     double.Parse(values[3]),
                                     values[4]);

                apartment.AddFlat(flat);
            }
            return apartment;
        }

        /// <summary>
        /// Writes data from Apartmment class object
        /// </summary>
        public static void WriteData(this Apartment apartment, string fileName, string infoText)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteHeader(infoText);
                if (apartment.FlatCount <= 0)
                    sw.WriteLine("No Data Found");
                else
                    foreach (Floor floor in apartment.Floors)
                        floor.Flats.WriteFloor(sw);

                sw.WriteLine();
            }
        }
        /// <summary>
        /// Writes Data from List Flat Object
        /// </summary>
        public static void WriteData(this List<Flat> flats, string fileName, string infoText)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteHeader(infoText);
                if (flats.Count == 0)
                    sw.WriteLine("No Data Found");
                else
                    flats.WriteFloor(sw);
                sw.WriteLine();
            }
        }

        /// <summary>
        /// Writed WriteData Header
        /// </summary>
        public static void WriteHeader(this StreamWriter sw, string infoText)
        {
            sw.WriteLine(infoText);
            sw.WriteLine(GetHeader());
        }

        /// <summary>
        /// Gets Header Info
        /// </summary>
        public static string GetHeader() => string.Format($"{"Flat Number", fSize}|{"Area",fSize}|{"Room Count",fSize}|{"Price",fSize}|{"Phone Number",fSize}|");

        /// <summary>
        /// Takes in List of Flats, Outputs to StreamWriter
        /// </summary>
        public static void WriteFloor(this List<Flat> flats, StreamWriter sw)
        {
            foreach (Flat flat in flats)
                sw.WriteLine($"{flat.RoomNum,-fSize}|{flat.Area,-fSize}|{flat.RoomCount,-fSize}|{flat.Price,-fSize}|{flat.PhoneNumber,-fSize}|");
            
        }
    }
}
