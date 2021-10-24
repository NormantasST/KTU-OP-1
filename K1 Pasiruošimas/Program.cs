// Stankevičius Normantas IFF-1/4
using System;
using System.Collections.Generic;
using System.IO;

namespace K1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reads Data and Outputs Initial Data
            new StreamWriter("Rezultatai.txt").Close();
            BookStore bookStore = InOut.InputBooks("Knyga.txt");
            InOut.Print(bookStore, "Rezultatai.txt", "Knygyno Informacija:");
            List<Book> soldBooks = InOut.InputSoldBooks("Parduota.txt");
            InOut.Print(soldBooks, "Rezultatai.txt", "Parduotų Knygų sąrašas:");
            
            // Updates BookStore
            bookStore.AddSalePrice(soldBooks);
            InOut.Print(bookStore, "Rezultatai.txt", "Atnaujintas Knygyno Informacija:");
            InOut.Print(soldBooks, "Rezultatai.txt", "Atnaujintas Parduotų Knygų sąrašas:");

            // Calculates left Sum:
            using (StreamWriter sw = new StreamWriter("Rezultatai.txt", append: true))
                sw.WriteLine($"Likusi atsiskaityti suma su platintojais: {bookStore.Sum(), 0:f}");
        }
    }
    
    /// <summary>
    /// Book store class
    /// </summary>
    class BookStore
    {
        private List<Book> Books;

        /// <summary>
        /// Constructor without list
        /// </summary>
        public BookStore()
        {
            Books = new List<Book>();
        }

        /// <summary>
        /// Constructor with List
        /// </summary>
        public BookStore(List <Book> books)
        {
            Books = books;
        }

        /// <summary>
        /// Finds index of Most expensive specified book
        /// </summary>
        /// <param name="book"></param>
        private int IndexMaxPrice(Book book)
        {
            Book currBook = new Book(book.Name);
            int index = -1;
            for (int i = 0; i < GetCount(); i++)
            {
                if (Books[i] >= book && Books[i] >= currBook)
                {
                    index = i;
                    currBook = GetBook(index);
                }
            }

            return index;
        }

        public void AddSalePrice(List<Book> books)
        {
            foreach (Book book in books)
            {
                int index = IndexMaxPrice(book);
                Book bookStoreBook = GetBook(index);
                book.Price = bookStoreBook.Price;
                bookStoreBook.Quantity--;
            }
        }

        /// <summary>
        /// Returns Count
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            return Books.Count;
        }

        /// <summary>
        /// Returns book by it's index
        /// </summary>
        /// <param name="index"></param>
        public Book GetBook(int index)
        {
            try
            {
                Book output = Books[index];
                return output;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Adds a book
        /// </summary>
        public void AddBook(Book book)
        {
            Books.Add(book);
        }

        /// <summary>
        /// Returns the sum of all book price
        /// </summary>
        public decimal Sum()
        {
            decimal sum = 0;
            foreach (Book book in Books)
            {
                sum += decimal.Parse((book.Quantity * book.Price).ToString());
            }
            return sum;
        }
    }

    /// <summary>
    /// Book Class
    /// </summary>
    class Book
    {
        public string Distributor { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        /// <summary>
        /// Default Initialization
        /// </summary>
        public Book(string distributor, string name, int qty, double price)
        {
            Distributor = distributor;
            Name = name;
            Quantity = qty;
            Price = price;
        }

        /// <summary>
        /// Name ONLY Initialization
        /// </summary>
        public Book(string name)
        {
            Name = name;
            Distributor = "";
            Quantity = 1;
            Price = 0;
        }

        public static bool operator <= (Book lhs, Book rhs)
        {
            if (lhs.Name == rhs.Name && rhs.Quantity > 0 && lhs.Price <= rhs.Price)
                return true;
            else
                return false;
        }
        public static bool operator >= (Book lhs, Book rhs)
        {
            if (lhs.Name == rhs.Name && lhs.Quantity > 0 && lhs.Price >= rhs.Price)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return $"{Distributor, -20}|{Name,-20}|{Quantity,10}|{Price,10:f}|";
        }
    }

    /// <summary>
    /// File Input, Output helper class
    /// </summary>
    static class InOut
    {
        /// <summary>
        /// Reads Bookstore's data from txt file
        /// Reads Bookstore's data from txt file
        /// </summary>
        public static BookStore InputBooks(string fileName)
        {
            BookStore output = new BookStore();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                string[] elements = line.Split(';');
                Book book = new Book(elements[0], elements[1], int.Parse(elements[2]), double.Parse(elements[3]));
                output.AddBook(book);
            }

            return output;
        }

        /// <summary>
        /// Reads data from Sold Book
        /// </summary>
        public static List<Book> InputSoldBooks(string fileName)
        {
            List<Book> books = new List<Book>();
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                Book book = new Book(line);
                books.Add(book);
            }

            return books;
        }

        /// <summary>
        /// Prints BookStore data
        /// </summary>
        public static void Print(BookStore books, string fileName, string header)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine(header);
                sw.WriteLine(new string('-', 64));
                sw.WriteLine($"{"Platintojas",-20}|{"Pavadinimas",-20}|{"Kiekis",10}|{"Kaina",10}|");
                sw.WriteLine(new string('-', 64));

                if(books.GetCount() > 0)
                    for (int i = 0; i < books.GetCount(); i++)
                        sw.WriteLine(books.GetBook(i).ToString());
                else
                    sw.WriteLine("Knygų nėra");

                sw.WriteLine(new string('-', 64));
                sw.WriteLine();
            }
        }

        /// <summary>
        /// Prints List<Book> Data
        /// </summary>
        public static void Print(List<Book> books, string fileName, string header)
        {
            using (StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine(header);
                sw.WriteLine(new string('-', 64));
                sw.WriteLine($"{"Platintojas",-20}|{"Pavadinimas",-20}|{"Kiekis",10}|{"Kaina",10}|");
                sw.WriteLine(new string('-', 64));

                if (books.Count > 0)
                    foreach (Book book in books)
                        sw.WriteLine(book.ToString());
                else
                    sw.WriteLine("Knygų nėra");

                sw.WriteLine(new string('-', 64));
                sw.WriteLine();
            }
        }
    }
}
