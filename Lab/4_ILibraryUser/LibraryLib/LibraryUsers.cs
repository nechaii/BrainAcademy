using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;


namespace LibraryLib
{
    public class LibraryUsers: ILibraryUsers
    {
        Book[] libraryBooks = new Book[10];
        User[] libraryUsers = new User[2];

        public LibraryUsers()
        {
            libraryBooks[0] = new Book { ID = 0, Author = "Gogol Nikolay", Name = "Taras Bulba", OnStock = false };
            libraryBooks[1] = new Book { ID = 1, Author = "Gogol Nikolay", Name = "Propavhaya Gramota", OnStock = true };
            libraryBooks[2] = new Book { ID = 2, Author = "Shevchenko Taras", Name = "Kobzar", OnStock = false };
            libraryBooks[3] = new Book { ID = 3, Author = "Shevchenko Taras", Name = "Kateryna", OnStock = true };
            libraryBooks[4] = new Book { ID = 4, Author = "Franko Ivan", Name = "Zahar Berkut", OnStock = true };
            libraryBooks[5] = new Book { ID = 5, Author = "Franko Ivan", Name = "Kamenyari", OnStock = false };
            libraryBooks[6] = new Book { ID = 6, Author = "Kotsubynskiy Mihail", Name = "Tini zabutyh predkiv", OnStock = true };
            libraryBooks[7] = new Book { ID = 7, Author = "Kotsubynskiy Mihail", Name = "Son", OnStock = true };
            libraryBooks[8] = new Book { ID = 8, Author = "Kotlyarevskiy Ivan", Name = "Eneida", OnStock = false };
            libraryBooks[9] = new Book { ID = 9, Author = "Kotlyarevskiy Ivany", Name = "Moskal charivnyk", OnStock = true };

            libraryUsers[0] = new User { ID = 0, FirstName = "Dmytro", LastName = "Krasuk", Phone = "096-11-11-111" };
            libraryUsers[0].AddUserBook(libraryBooks[0]);
            libraryUsers[0].AddUserBook(libraryBooks[2]);
            libraryUsers[0].AddUserBook(libraryBooks[5]);

            libraryUsers[1] = new User { ID = 0, FirstName = "Denis", LastName = "Osyflyak", Phone = "096-22-22-222" };
            libraryUsers[1].AddUserBook(libraryBooks[8]);
        }

        public Book this[string bookName]
        {
            get
            {
                return libraryBooks != null ? libraryBooks.Where(e => e.Name == bookName).FirstOrDefault() : null;
            }
        }

        public Book this[int bookID]
        {
            get
            {
                return libraryBooks != null ? libraryBooks.Where(e => e.ID == bookID).FirstOrDefault() : null;
            }
        }

        public void AddBookToLibrary(Book newBook)
        {
            if (libraryBooks == null)
            {
                libraryBooks = new Book[1];
                libraryBooks[0] = new Book { ID = 0, Author = newBook.Author, Name = newBook.Name, OnStock = newBook.OnStock };
            }
            else
            {
                int flag = libraryBooks.Length;
                newBook.ID = flag;
                Book[] tmpBooks = new Book[flag + 1];
                for (int i = 0; i < libraryBooks.Length; i++)
                {
                    tmpBooks[i] = libraryBooks[i];
                }
                tmpBooks[flag] = newBook;
                libraryBooks = tmpBooks;
            }
        }

        public void RemoveBookFromLibrary(Book newBook)
        {
            if (libraryBooks != null)
            {
                int flag = libraryBooks.Length;
                --flag;
                Book[] tmpBooks = new Book[flag];


                for (int i = 0, j=0; i < libraryBooks.Length-1; i++, j++)
                {
                    if (libraryBooks[i].ID != newBook.ID)
                        tmpBooks[i] = libraryBooks[j];
                    else
                        j++;
                        tmpBooks[i] = libraryBooks[j];
                }
                libraryBooks = tmpBooks;
            }
        }

        public void DeleteBookFromLibrary()
        {
            throw new NotImplementedException();
        }

        public void PrintLibraryBooks()
        {
            Console.WriteLine("Book to give");
            IEnumerable<Book> bookOnStock = libraryBooks.Where(e => e.OnStock == true).ToList();
            foreach (Book book in bookOnStock)
            {
                Console.WriteLine("ID: {0}, Author: {1}, Name: {2}",book.ID,book.Author,book.Name);
            }

            IEnumerable<Book> bookOffStock = libraryBooks.Where(e => e.OnStock == false).ToList();

            //ArrayList usersWithBook = new ArrayList();

            Console.WriteLine("Book on handS");

            foreach (Book book in bookOffStock)
            {
                Console.WriteLine("ID: {0}, Author: {1}, Name: {2}", book.ID, book.Author, book.Name);

                foreach (User user in libraryUsers)
                {
                    if (user.GetUserBook(book) != null)
                    {
                        Console.WriteLine(" \t ID: {0}, FirstName: {1}, LastName: {2}", user.ID, user.FirstName, user.LastName);
                    }
                }
            }
        }
    }
}
