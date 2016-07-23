using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LibraryLib;

namespace LibraryUserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryUsers myLibraryUsers = new LibraryUsers();
            myLibraryUsers.PrintLibraryBooks();

            Console.WriteLine("FirstIndex:");
            Book book = myLibraryUsers[2];
            if (book != null)
                Console.WriteLine("ID: {0}, Author: {1}, Name: {2}", book.ID, book.Author, book.Name);
            else
                Console.WriteLine("Book doesn't present");

            Console.WriteLine("SecondIndex:");
            book = myLibraryUsers["Zahar Berkut"];
            if (book != null)
                Console.WriteLine("ID: {0}, Author: {1}, Name: {2}", book.ID, book.Author, book.Name);
            else
                Console.WriteLine("Book doesn't present");

            var newBook = new Book { Author = "Skovoroda Grigoriy", Name = "Sad Bogestvennyh pisen", OnStock = true };
            myLibraryUsers.AddBookToLibrary(newBook);
            myLibraryUsers.PrintLibraryBooks();

            var rbook = myLibraryUsers["Zahar Berkut"];
            if (rbook != null)
            {
                myLibraryUsers.RemoveBookFromLibrary(rbook);
                Console.WriteLine("Book has been deleted now");
            }
            else
                Console.WriteLine("Book doesn't present");
            myLibraryUsers.PrintLibraryBooks();

            Console.ReadKey();
        }
    }
}
