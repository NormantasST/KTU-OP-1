using System;
using System.Text;

namespace Lab03
{
    class IMDBContainer
    {
        
        private IMDB[] Movies;
        public int Count { get; private set; }
        public int Capacity { get; set; }
        public IMDBContainer(int capacity = 16)
        {
            this.Movies = new IMDB[capacity];//default capacity
            Capacity = capacity;
            Count = 0;
        }

        public IMDBContainer(IMDBContainer container) : this(capacity: container.Capacity) //calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public void Add(IMDB imdb)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.Movies[this.Count++] = imdb;
        }

              
        public void Sort()
        {
            for (int i = 0; i < Count - 1; i++)
                for (int j = 0; j < Count - 1 - i; j++)
                    if (Movies[j].CompareTo(Movies[j + 1]) > 0)
                    {
                        IMDB temp = Movies[j];
                        Movies[j] = Movies[j + 1];
                        Movies[j + 1] = temp;
                    }
        }

        public IMDB Get(int index)
        {
            return this.Movies[index];
        }
        public bool Contains(IMDB idmb)
        {
            for (int i = 0; i < this.Count; i++)
                if (this.Movies[i].Equals(idmb))

                    return true;

            return false;
        }

        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                IMDB[] temp = new IMDB[minimumCapacity];
                for (int i = 0; i < this.Count; i++) // Shallow Copy
                {
                    temp[i] = this.Movies[i];
                }
                this.Capacity = minimumCapacity;
                this.Movies = temp;
            }

        }
        public IMDB Put(IMDB imdb, int index)
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

            IMDB otherDog = Movies[index];
            Movies[index] = imdb;

            return otherDog;
        }

        public IMDB Insert(IMDB dog, int index)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }

            index = CheckIndex(index);
            for (int i = Count - 1; i >= index; i--)
            {
                Movies[i + 1] = Movies[i];
            }

            Count++;
        Movies[index] = dog;

            return dog;
        }

        public int FindIndex(IMDB imdb)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Movies[i].Equals(imdb))
                    return i;
            }
            return -1;
        }

        public void Remove(IMDB imdb)
        {
            int index = FindIndex(imdb);
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
                    Movies[i] = Movies[i + 1];
                Movies[Count] = null;
                Count--;

            }
        }

        private int CheckIndex(int index)
        {
            if (index >= Count)
                return Count;
            return index;
        }

        public void Clear(int capacity = 16)
        {
            this.Movies = new IMDB[capacity];//default capacity
            Capacity = capacity;
            Count = 0;
        }
    }
}