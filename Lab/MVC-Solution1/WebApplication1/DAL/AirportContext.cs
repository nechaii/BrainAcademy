using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.DAL
{
    using System.Data.Entity;
    using WebApplication1.Models.Entities;

    //Enable-Migrations –EnableAutomaticMigrations
    //Enable-Migrations -ContextTypeName WebApplication1.DAL.AirportContext -Force
    //Update-Database –Verbose
    //Configuration.cs - AutomaticMigrationsEnabled = true;

    public class AirportContext: DbContext
    {
        public AirportContext() : base("AirportContext") { }

        public DbSet<FlightRepository> Flights { get; set; }
        public DbSet<PassengerRepository> Passengers { get; set; }
        public DbSet<TerminalRepository> Terminals { get; set; }
    }
}