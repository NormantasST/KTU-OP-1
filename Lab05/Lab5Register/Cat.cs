using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Register
{
    class Cat : Animal
    {
        private const int VaccinationDurationMonths = 6;
        public Cat(int id, string name, string breed, DateTime birthDate,
        Gender gender) : base(id, name, breed, birthDate, gender)
        {
        }
        public override bool RequiresVaccination
        {
            get
            {
                if (this.LastVaccinationDate.Equals(DateTime.MinValue))
                {
                    return true;
                }
                return LastVaccinationDate.AddMonths(VaccinationDurationMonths).CompareTo(DateTime.Now) < 0;
            }
        }
    }
}
