using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Entities
{
    public interface ITerminal
    {
        int Id { get; set; }
        string Name { get; set; }

        ICollection<IFlight> IFlight { get;set;}
    }
}