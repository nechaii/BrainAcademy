namespace Airport.Model
{
    using System;
    using System.Collections.Generic;
    using Airport.Model.AirplaneObject;
    using Airport.Model.TimeTableObject;
    using Airport.Model.CustomerObject;
    using BoardingCardObject;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Flights", Schema = "Airport")]
    public class Flight
    {
        [Key]
        public int Id { get; set; }

        [Column("Created", TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DepartureTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ArrivalTime { get; set; }

        public FlightStatus FlightStatus { get; set; }

        public FlightNumber FlightNumber { get; set; }

        public Direct Direct { get; set; }

        public Terminal Terminal { get; set; }

        [MaxLength(100), Required]
        public string FromPlace { get; set; }

        [MaxLength(100), Required]
        public string ToPlace { get; set; }

        public int? AirplaneId { get; set; }
        public Airplane Airplane { get; set; }

        public virtual TimeTable TimeTable { get; set; }

        public ICollection<BoardingCard> BoardingCard { get; set; }        

        public Flight()
        {
            BoardingCard = new HashSet<BoardingCard>();
        }

    }
}
