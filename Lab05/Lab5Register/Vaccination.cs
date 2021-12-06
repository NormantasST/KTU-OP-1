using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Register
{
    class Vaccination
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public Vaccination(int ID, DateTime date)
        {
            this.ID = ID;
            this.Date = date;
        }
        public static bool operator <(Vaccination vaccination, DateTime date)
        {
            return vaccination.Date.CompareTo(date) < 0;
        }
        public static bool operator >(Vaccination vaccination, DateTime date)
        {
            return vaccination.Date.CompareTo(date) > 0;
        }
    }

}
