
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Operation
{
    using Airport.Model;
    using Model.AirplaneObject;

    public class AirplaneOperation
    {
        public Airplane Create(string name, string model)
        {
            Airplane airplane = new Airplane()
            {
                DateAdded = DateTime.UtcNow,
                Name = name,
                Model = model,
                Seat = null,
                Flight = null,
                Airline = null
            };

            return airplane;
        }
        public List<Seat> CreateSeat(int count = 10, SeatType seatType = SeatType.Econom,int k=0)
        {
            List<Seat> seat = new List<Seat>(count);
            for (int i = 1; i <= count; i++)
            {
                seat.Add(new Seat() { SeatNum = i+k, SeatType = seatType });
            }
            return seat;
        }

        public void BindToSeat(Airplane airplane, ICollection<Seat> seat)
        {
            airplane.Seat = seat;
        }

        public void AddSeat(Airplane airplane, Seat seat)
        {
            airplane.Seat.Add(seat);
        }

        public void BindToAirLine(Airline airline, ICollection<Airplane> airplane)
        {
            foreach(var item in airplane)
                item.Airline = airline;
        }


    }
}
