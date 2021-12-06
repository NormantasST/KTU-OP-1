using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5Register
{
    class AnimalsRegister
    {
        private List<Animal> AllAnimals;

        private int count;
        public int MyProperty { get; set; }
        public int Count { get { return count; } }
        public AnimalsRegister()
        {
            AllAnimals = new List<Animal>();
            count = 0;
        }

        public AnimalsRegister(List<Animal> animals)
        {
            AllAnimals = new List<Animal>();
            count = animals.Count;
            foreach (Animal animal in animals)
            {
                this.AllAnimals.Add(animal);
            }
        }
        public void Add(Animal animal)
        {
            AllAnimals.Add(animal);
            count++;
        }

        /// <summary>
        /// Finds Animal By Index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Animal</returns>
        public Animal Get(int index)
        {
            Animal output;

            try
            {
                output = AllAnimals[index];
            }
            catch (Exception)
            {
                output = null;
            }

            return output;
        }

        public int CountByGender(Gender gender)
        {
            int count = 0;
            foreach (Animal animal in this.AllAnimals)
            {
                if (animal.Gender.Equals(gender))
                {
                    count++;
                }
            }
            return count;
        }

        public List<string> FindBreeds()
        {
            List<string> Breeds = new List<string>();
            foreach (Animal animal in this.AllAnimals)
            {
                string breed = animal.Breed;
                if (!Breeds.Contains(breed)) // uses List method Contains()
                {
                    Breeds.Add(breed);
                }
            }
            return Breeds;
        }

        public List<Animal> FilterByBreed(string breed)
        {
            List<Animal> Filtered = new List<Animal>();
            foreach (Animal animal in this.AllAnimals)
            {
                if (animal.Breed.Equals(breed)) // uses string method Equals()
                {
                    Filtered.Add(animal);
                }
            }
            return Filtered;
        }

        public Animal FindOldestAnimal()
        {
            return this.FindOldestAnimal(this.AllAnimals);
        }
        public Animal FindOldestAnimal(string breed)
        {
            List<Animal> Filtered = this.FilterByBreed(breed);
            return this.FindOldestAnimal(Filtered);
        }
        private Animal FindOldestAnimal(List<Animal> animals)
        {
            Animal oldest = animals[0];
            for (int i = 1; i < animals.Count; i++) //starts on index value 1
            {
                if (DateTime.Compare(oldest.BirthDate, animals[i].BirthDate) > 0)
                {
                    oldest = animals[i];
                }
            }
            return oldest;
        }

        private Animal FindAnimalByID(int ID)
        {
            foreach (Animal animal in this.AllAnimals)
            {
                if (animal.ID == ID)
                {
                    return animal;
                }
            }
            return null;
        }

        public bool Contains(Animal animal)
        {
            return AllAnimals.Contains(animal);
        }

        /// <summary>
        /// Filters for Unvaccinated Animals
        /// </summary>
        /// <returns>List Animal Object</returns>
        public List<Animal> FilterByVaccinationExpired()
        {
            List<Animal> filtered = new List<Animal>();
            foreach (Animal animal in this.AllAnimals)
                if (animal.RequiresVaccination)
                    filtered.Add(animal);
            
            return filtered;
        }

        public void UpdateVaccinationsInfo(List<Vaccination> Vaccinations)
        {
            foreach (Vaccination vaccination in Vaccinations)
            {
                Animal animal = this.FindAnimalByID(vaccination.ID);
                if (animal != null && vaccination > animal.LastVaccinationDate)
                {
                    animal.LastVaccinationDate = vaccination.Date;
                }
            }
        }

        public int CountAggresiveDogs()
        {
            int count = 0;
            for (int i = 0; i < this.AllAnimals.Count; i++)
            {
                Animal animal = this.AllAnimals[i];
                if (animal is Dog && (animal as Dog).Aggresive)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
