﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDB_App
{
    using Airport.Model;
    using Airport.Model.AirplaneObject;
    using System.Data;
    using System.Data.Entity;
    using Airport.Operation;
    using Airport.Model.TimeTableObject;

    class SomeClass
    {
        public DateTime? ExpectedArrivalTime { get; set; }
        public DateTime? ExpectedDepartureTime { get; set; }
        public FlightNumber? FlightNumber { get; set; }
        public Terminal? Terminal { get; set; }
        public string Airline { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new AirportDBInitializer());
            //CreateAirLine();
            //CreateTimeTable();


            using (AirportContext db = new AirportContext())
            {
                var timeTable = db.TimeTables.Join(db.Flights,
                    t => t.Id,
                    f => f.Id,
                    (t, f) => new { t, f }).Join(
                    db.Airplanes,
                    ff => ff.f.AirplaneId,
                    a => a.Id,
                    (ff,a) => new {ff,a}).Join(
                    db.Airlines,
                    aa => aa.a.AirlineId,
                    ar => ar.Id,
                    (aa,ar) => new {aa,ar}
                    );

                foreach (var item in timeTable)
                {
                    Console.WriteLine("{0}, {1}, {2}, {3}", item.aa.ff.t.ExpectedArrivalTime,item.aa.ff.f.FlightNumber,item.aa.a.Name,item.ar.Name);
                }
            }
            Console.ReadKey();

        }

        private static void CreateTimeTable()
        {
            throw new NotImplementedException();
        }

        public static void CreateAirLine()
        {
            //Company
            AirlineOperation airlineOperation = new AirlineOperation();
            Airline airline = airlineOperation.Create("BraineAcademy", "Konstantinivska 15 St.", "050-500-49-27");

            //Airplaines
            AirplaneOperation airplaneOperation = new AirplaneOperation();
            Airplane aN_158 = airplaneOperation.Create(name: "Antonov", model: "An-158");
            List<Seat> aN_158_Seat = airplaneOperation.CreateSeat(100, SeatType.Econom);
            airplaneOperation.BindToSeat(aN_158, aN_158_Seat);

            Airplane airbus_A350 = airplaneOperation.Create(name: "Airbus", model: "airbus_A350");
            List<Seat> airbus_A350_Seat = airplaneOperation.CreateSeat(20, SeatType.Turist);
            airbus_A350_Seat.AddRange(airplaneOperation.CreateSeat(50, SeatType.Econom, airbus_A350_Seat.Count()+1));
            airplaneOperation.BindToSeat(airbus_A350, airbus_A350_Seat);

            Airplane boeing_737 = airplaneOperation.Create(name: "Boeing", model: "boeing_737");
            List<Seat> boeing_737_Seat = airplaneOperation.CreateSeat(80, SeatType.Turist);
            boeing_737_Seat.AddRange(airplaneOperation.CreateSeat(10, SeatType.Vip, boeing_737_Seat.Count()+1));
            airplaneOperation.BindToSeat(boeing_737, boeing_737_Seat);

            Airplane bombardier_CRJ_1000 = airplaneOperation.Create(name: "Bombardier", model: "bombardier_CRJ_1000");
            List<Seat> bombardier_CRJ_1000_Seat = airplaneOperation.CreateSeat(50, SeatType.Turist);
            airplaneOperation.BindToSeat(bombardier_CRJ_1000, bombardier_CRJ_1000_Seat);

            Airplane dassault_Falcon_900 = airplaneOperation.Create(name: "Bombardier", model: "dassault_Falcon_900");
            List<Seat> dassault_Falcon_900_Seat = airplaneOperation.CreateSeat(10, SeatType.Vip);
            airplaneOperation.BindToSeat(dassault_Falcon_900, dassault_Falcon_900_Seat);

            //Bind planes to company
            airplaneOperation.BindToAirLine(airline, new List<Airplane> { aN_158, airbus_A350, boeing_737, bombardier_CRJ_1000, dassault_Falcon_900 });

            //Fligh
            FlightOperation flightOperation = new FlightOperation();
            Flight flightA01 = flightOperation.Create(DateTime.Now.AddHours(2), DateTime.Now.AddHours(4), FlightStatus.Departed, FlightNumber.A01, Direct.Departures, "Kiyv", "Lviv", Terminal.A);
            Flight flightA02 = flightOperation.Create(DateTime.Now.AddHours(3), DateTime.Now.AddHours(5), FlightStatus.Departed, FlightNumber.A02, Direct.Departures, "Kiyv", "DNR", Terminal.A);
            Flight flightB01 = flightOperation.Create(DateTime.Now.AddHours(-1), DateTime.Now.AddMinutes(40), FlightStatus.Arrived, FlightNumber.B01, Direct.Arrivals, "Krakov", "Kiyv", Terminal.B);
            Flight flightB02 = flightOperation.Create(DateTime.Now.AddHours(-2), DateTime.Now.AddMinutes(20), FlightStatus.Arrived, FlightNumber.B02, Direct.Arrivals, "Praga", "Kiyv", Terminal.B);

            flightOperation.BindToAirplane(flightA01, aN_158);
            flightOperation.BindToAirplane(flightA02, airbus_A350);
            flightOperation.BindToAirplane(flightB01, boeing_737);
            flightOperation.BindToAirplane(flightB02, bombardier_CRJ_1000);

            //Create ticket
            flightOperation.CreateBoardingCard(flightA01);
            flightOperation.CreateBoardingCard(flightA02);
            flightOperation.CreateBoardingCard(flightB01);
            flightOperation.CreateBoardingCard(flightB02);

            //Set price
            SeatType econom = SeatType.Econom;
            decimal ecoPrice = 123.45m;
            SeatType turist = SeatType.Turist;
            decimal turPrice = 99.90m;
            SeatType vip = SeatType.Vip;
            decimal vipPrice = 10000.00m;

            flightOperation.SetPrice(flightA01, ecoPrice, econom);
            flightOperation.SetPrice(flightA01, turPrice, turist);
            flightOperation.SetPrice(flightA01, vipPrice, vip);

            flightOperation.SetPrice(flightA02, ecoPrice, econom);
            flightOperation.SetPrice(flightA02, turPrice, turist);
            flightOperation.SetPrice(flightA02, vipPrice, vip);

            flightOperation.SetPrice(flightB01, ecoPrice, econom);
            flightOperation.SetPrice(flightB01, turPrice, turist);
            flightOperation.SetPrice(flightB01, vipPrice, vip);

            flightOperation.SetPrice(flightB02, ecoPrice, econom);
            flightOperation.SetPrice(flightB02, turPrice, turist);
            flightOperation.SetPrice(flightB02, vipPrice, vip);

            //Create customers
            flightOperation.CreateCustomer(flightA01);
            flightOperation.CreateCustomer(flightA02);
            flightOperation.CreateCustomer(flightB01);
            flightOperation.CreateCustomer(flightB02);

            //Create cashbox and cashbox operations
            CashBoxOperation cashBoxOperation = new CashBoxOperation();
            List<CashBox> cashBox = new List<CashBox>();
            cashBox.AddRange(cashBoxOperation.SoldOperation(flightA01));
            cashBox.AddRange(cashBoxOperation.SoldOperation(flightA02));
            cashBox.AddRange(cashBoxOperation.SoldOperation(flightB01));
            cashBox.AddRange(cashBoxOperation.SoldOperation(flightB02));

            //Bind with TimeTable
            ICollection<Flight> flights = new List<Flight> { flightA01, flightA02, flightB01, flightB02 };
            ICollection<TimeTable> timeTable = new TimeTableOperation().CreateTimeTable(flights);

            //save to DB
            using (AirportContext airPortCtx = new AirportContext())
            {
                try
                {
                    /*List<Flight> flights = new List<Flight> { flightA01, flightA02, flightB01, flightB02 };
                    flights.ForEach(p => airPortCtx.Flights.Add(p));*/

                    //airPortCtx.Flights.AddRange(new List<Flight> { flightA01, flightA02, flightB01, flightB02});
                    airPortCtx.TimeTables.AddRange(timeTable);

                    //airPortCtx.Airlines.Add(airline);
                    //timeTable.ForEach();

                    airPortCtx.SaveChanges();
                }

                catch (Exception e)
                {
                    Console.WriteLine("error" + e.Message);
                }
            }
            Console.WriteLine("Finish");
            Console.ReadKey();
        }
    }
}
