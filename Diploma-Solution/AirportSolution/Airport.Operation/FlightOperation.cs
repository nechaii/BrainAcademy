
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Operation
{
    using Airport.Model;
    using Model.AirplaneObject;
    using Model.BoardingCardObject;
    using Model.CustomerObject;
    using Model.TimeTableObject;

    public class FlightOperation
    {
        public Flight _flight { get; set; }

        public Flight Create(DateTime departureTime, DateTime arrivalTime,FlightStatus flightStatus, FlightNumber flightNumber, Direct direct, string fromPlace, string toPlace, Terminal terminal = Terminal.A)
        {
            Flight newFlight = new Flight()
            {
                DateAdded = departureTime > arrivalTime ? arrivalTime.AddHours(-2): departureTime.AddHours(-2),
                DepartureTime = departureTime,
                ArrivalTime = arrivalTime,
                FlightStatus = flightStatus,
                FlightNumber = flightNumber,
                Direct = direct,
                Terminal = terminal,
                FromPlace = fromPlace,
                ToPlace = toPlace,
                Airplane = null,
                BoardingCard = null
            };
            return newFlight;
        }

        public void BindToAirplane(Flight flight, Airplane airplane)
        {
            flight.Airplane = airplane;
        }

        public void CreateBoardingCard(Flight flight)
        {
            ICollection<Seat> seat = flight.Airplane.Seat;

            BoardingCardOperation boardingCardOperation = new BoardingCardOperation();
            List<BoardingCard> boardingCard = new List<BoardingCard>();

            foreach (var item in seat)
            {
                boardingCard.Add(boardingCardOperation.Create(item));
            }

            flight.BoardingCard = boardingCard;
        }

        public void SetPrice(Flight flight, decimal price, SeatType seatType)
        {
            List<int> st = flight.Airplane.Seat.Where(m => m.SeatType == seatType).Select(t => t.SeatNum).ToList();
            List<BoardingCard> bt = flight.BoardingCard.ToList();           

            foreach (int item in st)
            { 
                bt.ForEach(p =>  { if (p.SeatNum != null && p.SeatNum == item) { p.Price = price; } });
            }
        }

        public void CreateCustomer(Flight flight)
        {
            CustomerOperation customerOperation = new CustomerOperation();
            ICollection<BoardingCard> boardingCard = flight.BoardingCard;

            int i = 1;
            foreach (var item in boardingCard)
            {
                var t = (i > 64 && i < 91) ? "A" + (char)i : "B"  ;
                item.Customer = customerOperation.Create("Luk"+i, "Lukas"+i, "Clone"+i, t , "Num"+i, DocumentType.ElectronicIdentityCard, Sex.Male, DateTime.UtcNow.AddYears(-10), "R2D2");
                i++;
            }
        }

        public void BindToTimeTable(TimeTable timeTable, Flight flight)
        {
            timeTable.Flight = flight;
        }

        public void Disable()
        {
            throw new NotImplementedException();
        }
    }
}
