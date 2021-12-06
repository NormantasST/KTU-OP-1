using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Register
{
    class AnimalsComparatorByName : AnimalsComparator
    {
        public override int Compare(Animal a, Animal b)
        {
            int comparison = a.Name.CompareTo(b.Name);
            if (comparison == 0)
                comparison = a.ID.CompareTo(b.ID);

            return comparison;
        }
    }
}
