using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace WebApplication2.ModelsView
{
    using Airport.Model;
    using Airport.Model.TimeTableObject;
    using System.ComponentModel.DataAnnotations;

    public class TimeTableView
    {
        [Display(Name = "Flight")]
        public FlightNumber FlightNumber { get; set; }

        public FlightStatus FlightStatus { get; set; }

        [Display(Name = "From")]
        public string FromPlace { get; set; }

        [Display(Name = "To")]
        public string ToPlace { get; set; }

        [Display(Name ="Terminal")]
        public Terminal Terminal { get; set; }

        [Display(Name ="Airline")]
        public string Airline { get; set; }

        [Display(Name = "Departure")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:ddd dd/MM/yyyy HH:mm}")]
        public DateTime? ExpectedDepartureTime { get; set; }

        [Display(Name = "Arrival")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:ddd dd/MM/yyyy HH:mm}")]
        public DateTime? ExpectedArrivalTime { get; set; }
    }
}