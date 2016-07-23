using System;

namespace LibraryLib
{
    public class Book : IBook
    {
        int id;
        string author;
        string name;
        bool onStock;
        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool OnStock
        {
            get
            {
                return onStock;
            }

            set
            {
                onStock = value;
            }
        }
    }
}
