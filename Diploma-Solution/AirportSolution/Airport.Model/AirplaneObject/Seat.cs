namespace Airport.Model.AirplaneObject
{
    using BoardingCardObject;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    //[ComplexType] when dataelation 1 to 1
    [Table("Seats",Schema = "Airport")]
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        //[Column("SeatNum", TypeName = "numeric")]
        public int SeatNum { get; set; }

        [Required]
        public SeatType SeatType { get; set; }

        /*два поля для 1 ко многим*/
        public int? AirplaneId { get;set;}

        public virtual Airplane Airplane { get; set; }

        public Seat()
        {

        }
    }
}
