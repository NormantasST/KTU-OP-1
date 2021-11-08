using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03Sav
{
    class Program
    {
        const string CDinput = "input.txt";
        const string CDoutput = "output.txt";
        static void Main(string[] args)
        {
            StudentContainer students = InOut.ReadData(CDinput);
            InOut.CreateFile(CDoutput);
            InOut.WriteData(CDoutput, students, "Pradiniai duomenys:");
            GroupContainer groups = students.GetGroups();
            groups.UpdateGroups(students);
            groups.Sort();
            InOut.WriteData(CDoutput, groups, "I�rikiuotos grup�s pagal vidurkius, pavadinimus");
        }
    }
}
