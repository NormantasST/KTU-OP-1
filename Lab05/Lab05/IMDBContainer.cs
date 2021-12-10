using System;
using System.Text;

namespace Lab05
{

    /// <summary>
    /// IMDB Container Code
    /// </summary>
    class IMDBContainer
    {

        private Record[] Movies;
        public int Count { get; private set; }
        public int Capacity { get; set; }
        public IMDBContainer(int capacity = 16)
        {
            this.Movies = new Record[capacity];//default capacity
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
        public void Add(Record imdb)
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
        public Record Get(int index)
        {
            return this.Movies[index];
        }

        /// <summary>
        /// Contains Implementation
        /// </summary>
        public bool Contains(Record idmb)
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
                Record[] temp = new Record[minimumCapacity];
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
        public Record Put(Record imdb, int index)
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

            Record otherDog = Movies[index];
            Movies[index] = imdb;

            return otherDog;
        }

        /// <summary>
        /// Insert Implementation
        /// </summary>
        public Record Insert(Record dog, int index)
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
        public int FindIndex(Record imdb)
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
        public void Remove(Record imdb)
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
        /// Clears the Container
        /// </summary>
        public void Clear(int capacity = 16)
        {
            this.Movies = new Record[capacity];//default capacity
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

        /// <summary>
        /// Bubble Sort
        /// </summary>
        /// <returns></returns>
        public IMDBContainer Sort()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - 1 - i; j++)
                    if(Movies[j].CompareTo(Movies[j+1]) > 0)
                    {
                        // SWAP
                        Record temp = Movies[j];
                        Movies[j] = Movies[j + 1];
                        Movies[j+1] = temp;
                    }
            }

            return this;
        }
    }
}