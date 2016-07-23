namespace CarCollection
{
    class Car
    {
        public string Name { get; set; }

        public Car()
        { }

        public override string ToString()
        {
            return Name;
        }
    }
}
