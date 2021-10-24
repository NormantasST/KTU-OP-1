using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03.Register
{
    class Dog
    {
        private const int VaccinationDuration = 100;
        public int ID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime LastVaccinationDate { get; set; }
        public Gender Gender { get; set; }
        public bool RequiresVaccination()
        {
            if (LastVaccinationDate.Equals(DateTime.MinValue))
            {
                return true;
            }
            return LastVaccinationDate.AddYears(VaccinationDuration).CompareTo(DateTime.Now) < 0;
        }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - this.BirthDate.Year;
                if (this.BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;
            }
        }


        /// <summary>
        /// Costructor
        /// </summary>
        public Dog(int id, string name, string breed, DateTime birthDate, Gender gender)
        {
            this.ID = id;
            this.Name = name;
            this.Breed = breed;
            this.BirthDate = birthDate;
            this.Gender = gender;
        }

        public int CompareTo(Dog other)
        {
            int comparison = Breed.CompareTo(other.Breed);
            if (comparison == 0)
                comparison = this.Gender.CompareTo(other.Gender);

            return comparison;
        }

        public override bool Equals(object other)
        {
            return this.ID == ((Dog)other).ID;
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public override string ToString()
        {
            return $"{ID,10}|{Name,-20}|";
        }
    }
}
