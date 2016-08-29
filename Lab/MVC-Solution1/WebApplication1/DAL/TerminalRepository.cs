using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    using System.Data.Entity;
    using WebApplication1.Models.Entities;

    public class TerminalRepository: ITerminal
    {
        DbContext _db;

        public TerminalRepository()
        {
            _db = new AirportContext();
        }

        public int Id
        {
            get; set;
        }

        public ICollection<IFlight> IFlight
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }
    }
}