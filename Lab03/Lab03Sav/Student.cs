using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03Sav
{
    class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Group { get; set; }
        public double Average { get; set; }

        private int[] Marks;
        public int MarkCount { get; set; }

        public Student(string lastName, string firstName, string group, int[] marks)
        {
            LastName = lastName;
            FirstName = firstName;
            Group = group;
            Marks = marks;
            MarkCount = marks.Length;
        }

        public int GetMark(int index)
        {
            int mark;
            try
            {
                mark = Marks[index];
            }
            catch (Exception)
            {
                mark = 0;
            }

            return mark;
        }

        public int GetSum()
        {
            int sum = 0;
            foreach (int mark in Marks)
                sum += mark;

            return sum;
        }

        public override string ToString()
        {
            string output = $"|{LastName,-20}|{FirstName,-20}|{Group,-10}|{MarkCount,10}|";
            foreach (int mark in Marks)
                output += $"{mark,3} ";

            return output;
        }

        public int MarkSum()
        {
            int sum = 0;
            for (int i = 0; i < MarkCount; i++)
                sum += Marks[i];

            return sum;
        }
    }
}
