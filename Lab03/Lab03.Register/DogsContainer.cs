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
        public DogsContainer()
        {
            this.dogs = new Dog[16];//default capacity
        }
        public void Add(Dog dog)
        {
            this.dogs[this.Count++] = dog;
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

        public Dog Put(Dog dog, int index)
        {
            Dog otherDog = dogs[index];

            dogs[index] = dog;

            return otherDog;
        }

        public Dog Insert(Dog dog, int index)
        {
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
            if (index == -1)
                return;
            else
            {
                dogs[index] = null;
                Count--;
                for (int i = index; i < Count-1; i++)
                {
                    dogs[index] = dogs[index + 1];
                }
            }
        }

        public void RemoveAt(int index)
        {
            if (index < Count)
            {
                Count--;
                dogs[index] = null;
                for (int i = index; i < Count - 1; i++)
                {
                    dogs[index] = dogs[index + 1];
                }
            }
        }


    }
}
