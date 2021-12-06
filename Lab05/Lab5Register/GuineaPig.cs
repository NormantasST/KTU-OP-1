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
    }
}
