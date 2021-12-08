using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Register
{
    class Dog : Animal
    {
        private const int VaccinationDuration = 1;
        public bool Aggresive { get; set; }
        public Dog(int id, string name, string breed, DateTime birthDate,
        Gender gender, bool aggresive) : base(id, name, breed, birthDate, gender)
        {
            this.Aggresive = aggresive;
        }
        public override bool RequiresVaccination
        {
            get
            {
                if (LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddYears(VaccinationDuration)
               .CompareTo(DateTime.Now) < 0;
            }
        }

        public new string ToString(string splitter)
        {
            return $"{"DOG",fSize}|{ID,fSize}{splitter}{Name,fSize}{splitter}{Breed,fSize}{splitter}{BirthDate,fSize * 3 / 2:yyyy-MM-dd}{splitter}{Gender,fSize}{splitter}{Aggresive,fSize / 2}";
        }

        public override string ToString()
        {
            return ToString("|");
        }
    }

}
