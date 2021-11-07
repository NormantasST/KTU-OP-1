using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03Sav
{
    class GroupContainer
    {
        public int Capacity { get; set; }
        public int Count { get; set; }

        private Group[] Groups;
        public GroupContainer( int capacity = 16)
        {
            Groups = new Group[capacity];
            Capacity = capacity;
            Count = 0;
        }

        public void Add(Group group)
        {
            EnsureCapacity();
            Groups[this.Count++] = group;
        }

        private void EnsureCapacity()
        {
            if (Count > Capacity)
            {
                int newCapacity = Capacity * 2;
                Group[] temp = new Group[newCapacity];
                for (int i = 0; i < this.Count; i++) // Shallow Copy
                {
                    temp[i] = this.Groups[i];
                }
                this.Capacity = newCapacity;
                this.Groups = temp;
            }
        }

        public bool Contains(string search)
        {
            for (int i = 0; i < Count; i++)
                if (Groups[i].Name == search)
                    return true;

            return false;
        }

        public void UpdateGroups(StudentContainer students)
        {
            for (int i = 0; i < Count; i++)
            {
                Group currGroup = Groups[i];
                for (int j = 0; j < students.Count; j++)
                {
                    Student currStudent = students.Get(j);
                    if (currGroup.Name == currStudent.Group)
                    {
                        currGroup.Sum += currStudent.MarkSum();
                        currGroup.Devider += currStudent.MarkCount;
                    }
                }
            }
        }

        public Group Get(int index)
        {
            Group output;
            try
            {
                output = Groups[index];
            }
            catch (Exception)
            {
                output = null;
            }

            return output;
        }

        public void Sort()
        {
            // Bubble Sort
            for (int i = 0; i < Count - 1; i++)
                for (int j = 0; j < Count - 1 - i; j++)
                    if(Groups[j].CompareTo(Groups[j+1]) < 0)
                    {
                        // Swaps
                        Group temp = Groups[j];
                        Groups[j] = Groups[j + 1];
                        Groups[j + 1] = temp;
                    }

            
        }
    }
}
