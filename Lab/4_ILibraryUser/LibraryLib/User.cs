using System;
using System.Linq;

namespace LibraryLib
{
    public class User : IUser
    {
        int id;
        string firstName;
        string lastName;
        string phone;
        Book[] userBooks = null;

        public void AddUserBook(Book book)
        {
            if (userBooks == null)
            {
                userBooks = new Book[1];
                userBooks[0] = new Book { ID = book.ID, Author = book.Author, Name = book.Name, OnStock = book.OnStock };
            }
            else
            {
                int flag = userBooks.Length;
                Book[] tmpBooks = new Book[flag + 1];
                for (int i = 0; i < userBooks.Length; i++)
                {
                    tmpBooks[i] = userBooks[i];
                }
                tmpBooks[flag] = book;
                userBooks = tmpBooks;
            }
        }

        public Book GetUserBook(Book book)
        {
            return userBooks != null ? userBooks.Where(e => e.ID == book.ID).FirstOrDefault() : null;
        }


        public int ID {
            get {
                return id;
            }
            set {
                id = value;
            }
        }
        public string FirstName {
            get {
                return firstName;
            }
            set {
                firstName = value;
            }
        }
        public string LastName {
            get {
                return lastName;
            }
            set {
                lastName = value;
            }
        }
        public string Phone {
            get {
                return phone;
            }
            set {
                phone = value;
            }
        }
    }
}
