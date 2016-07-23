namespace Airport.Model.CustomerObject
{
    using System;
    using Airport.Model.BoardingCardObject;
    public class Customer:IDisposable
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DocumentSeries { get; set; }
        public string DocumentNum { get; set; }
        public DocumentType DocType { get; set; }
        public Sex CustomerSex { get; set; }
        public DateTime DateBorn { get; set; }
        public string Nationality { get; set; }
        public BoardingCard BoardingCard { get; set; }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
