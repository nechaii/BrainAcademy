namespace LibraryLib
{
    interface IUser
    {
        int ID { get; set; }
        string FirstName { get; }
        string LastName { get; }
        string Phone { get; set; }
        void AddUserBook(Book book);
        Book GetUserBook(Book book);
    }
}
