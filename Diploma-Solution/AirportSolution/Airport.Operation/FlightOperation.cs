
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
    using Model.TimeTableObject;

    public class FlightOperation
    {
        public Flight _flight { get; set; }

        public Flight Create(DateTime departureTime, DateTime arrivalTime, FlightNumber flightNumber, Direct direct, string fromPlace, string toPlace, Terminal terminal = Terminal.A)
        {
            Flight newFlight = new Flight()
            {
                DateAdded = DateTime.UtcNow,
                DepartureTime = departureTime,
                ArrivalTime = arrivalTime,
                FlightStatus = FlightStatus.Planned,
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
            foreach(BoardingCard item in flight.BoardingCard.Where(p => p.Seat.SeatType == seatType))            
            {
                item.Price = price;
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
