using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.Entities
{
    public interface IPassenger
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        string Series { get; set; }
        string Number { get; set; }
        string Gender { get; set; }

        int? FlightId { get; set; }
        IFlight Flight { get; set; }
    }
}