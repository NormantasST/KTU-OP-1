using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03.Register
{
    class DogsContainer
    {
        private Dog[] dogs;
        public int Count { get; private set; }
        public int Capacity { get; set; }
        public DogsContainer(int capacity = 16)
        {
            this.dogs = new Dog[capacity];//default capacity
            Capacity = capacity;
            Count = 0;
        }
        public void Add(Dog dog)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.dogs[this.Count++] = dog;
        }

        public void Sort()
        {
            for (int i = 0; i < Count - 1; i++)
                for (int j = 0; j < Count - 1 - i; j++)
                    if(dogs[j].CompareTo(dogs[j+1]) > 0)
                    {
                        Dog temp = dogs[j];
                        dogs[j] = dogs[j + 1];
                        dogs[j + 1] = temp;
                    }
        }


        public Dog Get(int index)
        {
            return this.dogs[index];
        }
        public bool Contains(Dog dog)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.dogs[i].Equals(dog))
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
                Dog[] temp = new Dog[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.dogs[i];
                }
                this.Capacity = minimumCapacity;
                this.dogs = temp;
            }

        }
            public Dog Put(Dog dog, int index)
        {
            index = CheckIndex(index);
            if (index == Count)
                Count++;

            Dog otherDog = dogs[index];
            dogs[index] = dog;

            return otherDog;
        }

        public Dog Insert(Dog dog, int index)
        {
            index = CheckIndex(index);
            for(int i = Count - 1; i >= index; i--)
            {
                dogs[i + 1] = dogs[i];
            }

            Count++;
            dogs[index] = dog;

            return dog;
        }

        public int FindIndex(Dog dog)
        {
            for (int i = 0; i < Count; i++)
            {
                if (dogs[i].Equals(dog))
                    return i;
            }
            return -1;
        }

        public void Remove(Dog dog)
        {
            int index = FindIndex(dog);
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
                    dogs[i] = dogs[i + 1];
                dogs[Count] = null;
                Count--;

            }
        }

        private int CheckIndex(int index)
        {
            if (index >= Count)
                return Count;
            return index;
        }


    }
}
