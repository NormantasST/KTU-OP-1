using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03Sav
{
    class StudentContainer
    {
        public int Capacity { get; set; }
        public int Count { get; set; }
        public string Faculty { get; set; }
        private Student[] Students;

        public StudentContainer(string faculty, int capacity = 16)
        {
            Faculty = faculty;
            Students = new Student[capacity];
            Capacity = capacity;
            Count = 0;
        }

        public void Add(Student student)
        {
            EnsureCapacity();
            Students[this.Count++] = student;
        }

        private void EnsureCapacity()
        {
            if (Count > Capacity)
            {
                int newCapacity = Capacity * 2;
                Student[] temp = new Student[newCapacity];
                for (int i = 0; i < this.Count; i++) // Shallow Copy
                {
                    temp[i] = this.Students[i];
                }
                this.Capacity = newCapacity;
                this.Students = temp;
            }
        }

        public Student Get(int index)
        {
            Student output;
            try
            {
                output = Students[index];
            }
            catch (Exception)
            {
                output = null;
            }

            return output;
        }

        public GroupContainer GetGroups()
        {
            GroupContainer groupContainer = new GroupContainer();
            for (int i = 0; i < Count; i++)
                if (groupContainer.Contains(Students[i].Group) == false)
                    groupContainer.Add(new Group(Students[i].Group));

            return groupContainer;
        }
    }
}
