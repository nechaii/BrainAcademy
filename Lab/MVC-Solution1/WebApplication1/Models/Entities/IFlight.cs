using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entities
{
    using DAL;
    using System.ComponentModel.DataAnnotations.Schema;

    public interface IFlight
    {
        int Id { get; set; }
        string Number { get; set; }
        DateTime? ArrivalTime { get; set; }
        DateTime? DepartureTime { get; set; }

        int? TerminalId { get; set; }
        ITerminal Terminal { get; set; }

        ICollection<PassengerRepository> Passenger { get; set; }
    }
}
