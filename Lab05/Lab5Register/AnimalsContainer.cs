using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Register
{
    class AnimalsContainer
    {
        private Animal[] animals;
        public int Count { get; private set; }
        public int Capacity { get; set; }
        public AnimalsContainer(int capacity = 16)
        {
            this.animals = new Animal[capacity];//default capacity
            Capacity = capacity;
            Count = 0;
        }

        public List<Animal> GetList()
        {
            List<Animal> list = new List<Animal>();
            for (int i = 0; i < Count; i++)
                list.Add(this.animals[i]);
            return list;
        }

        public AnimalsContainer(AnimalsContainer container) : this(capacity: container.Capacity) //calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public void Add(Animal animal)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.animals[this.Count++] = animal;
        }

        public void Sort()
        {
            Sort(new AnimalsComparator());
        }

        public void Sort(AnimalsComparator comparator)
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Animal a = this.animals[i];
                    Animal b = this.animals[i + 1];
                    if (comparator.Compare(a, b) > 0)
                    {
                        this.animals[i] = b;
                        this.animals[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }

        public Animal Get(int index)
        {
            return this.animals[index];
        }
        public bool Contains(Animal animal)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.animals[i].Equals(animal))
                {
                    return true;
                }
            }
            return false;
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Animal[] temp = new Animal[minimumCapacity];
                for (int i = 0; i < this.Count; i++) // Shallow Copy
                {
                    temp[i] = this.animals[i];
                }
                this.Capacity = minimumCapacity;
                this.animals = temp;
            }

        }
        public Animal Put(Animal animal, int index)
        {
            index = CheckIndex(index);
            if (index == Count)
            {
                if (this.Count == this.Capacity) //container is full
                {
                    EnsureCapacity(this.Capacity * 2);
                }
                Count++;
            }

            Animal otherAnimal = animals[index];
            animals[index] = animal;

            return otherAnimal;
        }

        public Dog Insert(Dog dog, int index)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }

            index = CheckIndex(index);
            for(int i = Count - 1; i >= index; i--)
            {
                animals[i + 1] = animals[i];
            }

            Count++;
            animals[index] = dog;

            return dog;
        }

        public int FindIndex(Animal animal)
        {
            for (int i = 0; i < Count; i++)
            {
                if (animals[i].Equals(animal))
                    return i;
            }
            return -1;
        }

        public void Remove(Animal animal)
        {
            int index = FindIndex(animal);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < Count)
            {
                // Checks if element exists, if does, removes
                for (int i = index; i < Count; i++)
                    animals[i] = animals[i + 1];
                animals[Count] = null;
                Count--;

            }
        }

        private int CheckIndex(int index)
        {
            if (index >= Count)
                return Count;
            return index;
        }

        public AnimalsContainer Intersect(AnimalsContainer other)
        {
            AnimalsContainer result = new AnimalsContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Animal current = this.animals[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
    }
}
