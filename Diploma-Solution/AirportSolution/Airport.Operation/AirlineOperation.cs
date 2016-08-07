
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Operation
{
    using Airport.Model;
    using Model.AirplaneObject;

    public class AirlineOperation
    {
        public Airline Create(string name, string address, string phone)
        {
            Airline airline = new Airline()
            {
                Name = name,
                Address = address,
                Phone = phone,
                Airplane = null
            };

            return airline;
        }

        public void BindToAirplane(Airline airline, ICollection<Airplane> airplane)
        {
            airline.Airplane = airplane;
        }

        public void BindToAirplane(Airline airline, Airplane airplane)
        {
            airline.Airplane.Add(airplane);
        }
    }
}
