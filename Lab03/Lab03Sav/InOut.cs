using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab03Sav
{
    static class InOut
    {
        public static StudentContainer ReadData(string file)
        {  
            string[] lines = File.ReadAllLines(file);
            StudentContainer output = new StudentContainer(lines[0]);
            for (int i = 1; i < lines.Length; i++)
            {
                string[] elements = lines[i].Split(';');
                string firstName = elements[1];
                string lastName = elements[0];
                string group = elements[2];

                // Reads Marks
                int markCount = int.Parse(elements[3]);
                int[] marks = new int[markCount];
                for (int j = 0; j < markCount; j++)
                    marks[j] = int.Parse(elements[4 + j]);

                Student temp = new Student(lastName, firstName, group, marks);
                output.Add(temp);
            }

            return output;
        }

        public static void WriteData(string file, StudentContainer sc, string header)
        {
            using (StreamWriter sw = new StreamWriter(file, append:true))
            {
                sw.WriteLine(header);
                sw.WriteLine(new string('-', 92));
                sw.WriteLine(sc.Faculty);
                sw.WriteLine(new string('-', 92));
                sw.WriteLine($"|{"LastName",-20}|{"FirstName",-20}|{"Group",-10}|{"MarkCount",-10}");
                sw.WriteLine(new string('-', 92));
                for (int i = 0; i < sc.Count; i++)
                    sw.WriteLine(sc.Get(i));
                sw.WriteLine();
            }
        }

        public static void WriteData(string file, GroupContainer gc, string header)
        {
            using (StreamWriter sw = new StreamWriter(file, append: true))
            {
                sw.WriteLine(header);
                sw.WriteLine(new string('-', 92));
                sw.WriteLine($"{"Average",-10}|{"Name",-20}");
                sw.WriteLine(new string('-', 92));
                for (int i = 0; i < gc.Count; i++)
                    sw.WriteLine(gc.Get(i));
                sw.WriteLine();
            }
        }

        public static void CreateFile(string file) => new StreamWriter(file).Close();

    }
}
