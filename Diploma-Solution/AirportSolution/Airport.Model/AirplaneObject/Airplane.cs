namespace Airport.Model.AirplaneObject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Airplanes", Schema = "Airport")]
    public class Airplane
    {
        //[Column("AirplaneId", TypeName ="ntext")]
        [Key]
        public int Id { get; set; }

        [Column("Created", TypeName ="datetime2")]
        public DateTime DateAdded { get; set; }

        [MaxLength(50), Required]
        public string Name { get; set; }

        [MaxLength(50), Required]
        public string Model { get; set; }

        public virtual ICollection<Seat> Seat { get; set; }

        public virtual ICollection<Flight> Flight { get; set; }

        /*два поля для 1 ко многим*/
        public int? AirlineId { get; set; }

        public virtual Airline Airline { get; set; }

        public Airplane()
        {
            this.Seat = new HashSet<Seat>();
        }
    }
}
