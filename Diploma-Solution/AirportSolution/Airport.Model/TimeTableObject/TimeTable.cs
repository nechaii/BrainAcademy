namespace Airport.Model.TimeTableObject
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TimeTables", Schema = "Airport")]
    public class TimeTable
    {
        [Key, ForeignKey("Flight")]
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExpectedDepartureTime { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ExpectedArrivalTime { get; set; }

        [NotMapped]
        public Direct Direct { get { return this.Flight.Direct; } }

        [NotMapped]
        public Terminal Terminal { get { return this.Flight.Terminal; }}

        [NotMapped]
        public string FromPlace { get { return this.Flight.FromPlace; } }

        [NotMapped]
        public string ToPlace { get { return this.Flight.ToPlace; } }

        [Required]
        public virtual Flight Flight { get; set; }     
    }
}
