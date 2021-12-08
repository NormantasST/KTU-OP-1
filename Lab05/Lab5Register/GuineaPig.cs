using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Register
{
    internal class GuineaPig : Animal
    {
        public GuineaPig(int id, string name, string breed, DateTime birthDate, Gender gender) : base(id, name, breed, birthDate, gender)
        {
        }
        public override bool RequiresVaccination { get { return false; } }

        public new string ToString(string splitter)
        {
            return $"{"GuineaPig",fSize}|{ID,fSize}{splitter}{Name,fSize}{splitter}{Breed,fSize}{splitter}{BirthDate,fSize * 3 / 2:yyyy-MM-dd}{splitter}{Gender,fSize}{splitter}";
        }

        public override string ToString()
        {
            return ToString("|");
        }
    }
}
