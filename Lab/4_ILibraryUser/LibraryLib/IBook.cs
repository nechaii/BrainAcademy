namespace LibraryLib
{
    interface IBook
    {
        int ID { get; set; }
        string Author { get; set; }
        string Name { get; set; }
        bool OnStock { get; set; }
    }
}
