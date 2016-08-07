namespace Airport.Model.BoardingCardObject
{
    using Airport.Model.AirplaneObject;
    using Airport.Model.CustomerObject;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BoardingCards",Schema= "Airport")]
    public class BoardingCard
    {
        [Key]        
        public int Id { get; set; }

        [Column("Created", TypeName = "datetime2")]
        public DateTime? DateAdded { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateLastOperation { get; set; }

        [NotMapped]
        public DateTime? DepartureTime { get { return this.Flight.DepartureTime; } }

        [NotMapped]
        public FlightNumber? FlightNumber { get { return this.Flight.FlightNumber; } }

        public BoardingCardStatus? BoardingCardStatus { get; set; }

        [Required]
        public decimal Price { get; set; }       

        public int? SeatId { get; set; }

        public Seat Seat { get; set; }

        public int? CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int? FlightId { get; set; }
        public Flight Flight { get; set; }

        public virtual CashBox CashBox { get; set; }

        public BoardingCard()
        {

        }
    }
}
