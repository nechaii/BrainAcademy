namespace LibraryLib
{
    interface ILibraryUsers
    {
        Book this[string bookName] { get; }
        void AddBookToLibrary(Book newBook);
        void DeleteBookFromLibrary();
        void PrintLibraryBooks();
        //void PassBookToUser();
        //void ReceiveBookFromUser();
    }
}
