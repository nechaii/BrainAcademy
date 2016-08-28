namespace WebApplication2.ModelsView
{
    using System;
    using Airport.Model;
    using Airport.Model.TimeTableObject;
    using System.ComponentModel.DataAnnotations;

    public class FlightView
    {
        [Display(Name = "Flight")]
        public FlightNumber FlightNumber { get; set; }

        public FlightStatus FlightStatus { get; set; }

        [Display(Name = "From")]
        public string FromPlace { get; set; }

        [Display(Name = "To")]
        public string ToPlace { get; set; }

        [Display(Name = "Departure")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:ddd dd/MM/yyyy HH:mm}")]
        public DateTime? DepartureTime { get; set; }

        [Display(Name = "Arrival")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:ddd dd/MM/yyyy HH:mm}")]
        public DateTime? ArrivalTime { get; set; }
    }
}