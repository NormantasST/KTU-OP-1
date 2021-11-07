using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03Sav
{
    class Group
    {
        public string Name { get; set; }
        public int Sum { get; set; }
        public int Devider { get; set; }
        public double Average { get { return (double)Sum / Devider; } }

        public Group (string name)
        {
            Name = name;
            Sum = 0;
            Devider = 0;
        }

        public int CompareTo(Group other)
        {
            int comparison = Average.CompareTo(other.Average);
            if (comparison == 0)
                comparison = other.Name.CompareTo(Name);

            return comparison;
        }

        public override string ToString()
        {
            return $"{Average,10:f}|{Name,-20}";
        }
    }
}
