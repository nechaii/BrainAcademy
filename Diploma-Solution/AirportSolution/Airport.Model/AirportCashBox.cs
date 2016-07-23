namespace Airport.Model
{
    using System.Collections.Generic;
    using Airport.Model.CustomerObject;
    using Airport.Model.AirplaneObject;
    using BoardingCardObject;
    using System;

    class AirportCashBox
    {
        public int Id { get; set; }
        public Flight Flight { get;set;}
        //public BoardingCard BoardingCard { get; set; }
        public Customer Customer { get; set; }
        public DateTime DateOperation { get; set; }
        public OperationType OperationType { get; set; }
    }

    public enum OperationType
    {
        Sale,
        Return
    }
}
