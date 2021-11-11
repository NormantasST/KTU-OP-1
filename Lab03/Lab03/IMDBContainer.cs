using System;
using System.Text;

namespace Lab03
{

    /// <summary>
    /// IMDB Container Code
    /// </summary>
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

        /// <summary>
        /// IMDB Container Code
        /// </summary>
        public IMDBContainer(IMDBContainer container) : this(capacity: container.Capacity) //calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }

        /// <summary>
        /// IMDB Container Add
        /// </summary>
        public void Add(IMDB imdb)
        {
            if (this.Count == this.Capacity) //container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.Movies[this.Count++] = imdb;
        }

        /// <summary>
        /// Get by Index function
        /// </summary>
        public IMDB Get(int index)
        {
            return this.Movies[index];
        }

        /// <summary>
        /// Contains Implementation
        /// </summary>
        public bool Contains(IMDB idmb)
        {
            for (int i = 0; i < this.Count; i++)
                if (this.Movies[i].Equals(idmb))

                    return true;

            return false;
        }

        /// <summary>
        /// Ensure Capacity Implementation
        /// </summary>
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

        /// <summary>
        /// Put Function Container
        /// </summary>
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

        /// <summary>
        /// Insert Implementation
        /// </summary>
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

        /// <summary>
        /// FindIndex Container Implementation
        /// </summary>
        public int FindIndex(IMDB imdb)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Movies[i].Equals(imdb))
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// Remove Container Implementation
        /// </summary>
        public void Remove(IMDB imdb)
        {
            int index = FindIndex(imdb);
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        /// <summary>
        /// RemoveAt implementation
        /// </summary>
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

        /// <summary>
        /// CheckIndex if the index exists implementation
        /// </summary>
        private int CheckIndex(int index)
        {
            if (index >= Count)
                return Count;
            return index;
        }

        /// <summary>
        /// Selection Sort implementation
        /// </summary>
        public IMDBContainer Sort()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < Count; j++)
                    if (Movies[j].CompareTo(Movies[min_idx]) < 0)
                        min_idx = j;

                IMDB temp = Movies[min_idx];
                Movies[min_idx] = Movies[i];
                Movies[i] = temp;
            }

            return this;
        }


        /// <summary>
        /// Clears the Container
        /// </summary>
        public void Clear(int capacity = 16)
        {
            this.Movies = new IMDB[capacity];//default capacity
            Capacity = capacity;
            Count = 0;
        }

        /// <summary>
        /// ToString implementation
        /// </summary>
        public override string ToString()
        {
            return $"Element Count: {Count} Element Capacity: {Capacity}";
        }
    }
}