namespace WebApplication1.Migrations
{
    using Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication1.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.DAL.AirportContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebApplication1.DAL.AirportContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            List<PassengerRepository> passengerRepositoryList = new List<PassengerRepository>();
            for (int i = 0; i < 20; i++)
            {
                 PassengerRepository passengerRepository = new PassengerRepository() { Id = i,FirstName="Joy"+1,SecondName="JoyS"+i, Gender="Male",Number=i*10+"",Series="AA"+1};

                passengerRepositoryList.Add(passengerRepository);
            }

            TerminalRepository terminalRepository = new TerminalRepository() {Id=1, Name = "A" };

            FlightRepository flightRepository = new FlightRepository() {
                Id=1,
                ArrivalTime = DateTime.UtcNow.AddHours(2),
                DepartureTime = DateTime.UtcNow.AddHours(-1),
                Number = "Flight-A01",
                TerminalId= terminalRepository.Id,
                Terminal = terminalRepository,
                Passenger = passengerRepositoryList };

            passengerRepositoryList.ForEach(p => p.FlightId = flightRepository.Id);

            context.Flights.AddOrUpdate(flightRepository);
            context.Terminals.AddOrUpdate(terminalRepository);
            passengerRepositoryList.ForEach(p => context.Passengers.AddOrUpdate(p));
            context.SaveChanges();

            //flightRepository.Passenger = passengerRepositoryList;
            //flightRepository.Terminal = terminalRepository;
            //context.Terminals.Add(terminalRepository);
            //passengerRepositoryList.ForEach(p => context.Passengers.Add(p));



        }
    }
}
