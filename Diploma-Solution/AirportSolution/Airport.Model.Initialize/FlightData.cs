using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model.Initialize
{
    using AirplaneObject;
    using Airport.Model;
    using Airport.Model.TimeTableObject;

    class FlightData
    {
        public List<Flight> _flightDataList = null;

        public FlightData()
        {
            _flightDataList = FlightListFill();
        }

        List<Flight> FlightListFill()
        {
            CustomerData _customerData = new CustomerData();
            AirlineData _airlineData = new AirlineData();


            Flight _flightA = new Flight();
            _flightA.Id = 1;
            _flightA.FlightNum = FlightNumData.FlightNumFill().Where(p => p.Key == 1).Select(p => p.Value).FirstOrDefault();
            _flightA.FligthDirect = Direct.Departures;
            _flightA.FromPlace = "Kyiv";
            _flightA.ToPlace = "Zhytomyr";
            _flightA.TerminalGate = Terminal.A;
            _flightA.FlightStatus = FlightStatus.Planned;
            _flightA.DepartureTime = null;
            _flightA.ArrivalTime = null;
            _flightA.Airplane = _airlineData._airlineList.Select(p => p.AirplaneList.Where(y => y.Name == "Bombardier_CRJ_1000").FirstOrDefault()).FirstOrDefault();
            _flightA.CustomerList = null;
            _flightA.BoardingCardList = null;
           



            Flight _flightB = new Flight()
            {
                Id = 2,
                FlightNum = FlightNumData.FlightNumFill().Where(p => p.Key == 2).Select(p => p.Value).FirstOrDefault(),
                FligthDirect = Direct.Departures,
                FromPlace = "Kyiv",
                ToPlace = "Lviv",
                TerminalGate = Terminal.A,
                FlightStatus = FlightStatus.Planned,
                DepartureTime = null,
                ArrivalTime = null,
                Airplane = (Airplane)_airlineData._airlineList.Select(p => p.AirplaneList.Where(y => y.Name == "Dassault_Falcon_900").FirstOrDefault()).FirstOrDefault(),
                CustomerList = null,
                BoardingCardList = null
            };            

            Flight _flightC = new Flight()
            {
                Id = 3,
                FlightNum = FlightNumData.FlightNumFill().Where(p => p.Key == 3).Select(p => p.Value).FirstOrDefault(),
                FligthDirect = Direct.Arrivals,
                FromPlace = "Zhytomyr",
                ToPlace = "Kyiv",
                TerminalGate = Terminal.B,
                FlightStatus = FlightStatus.Expected,
                DepartureTime = DateTime.Now.AddHours(-3),
                ArrivalTime = DateTime.Now.AddHours(1),
                Airplane = (Airplane)_airlineData._airlineList.Select(p => p.AirplaneList.Where(y => y.Name == "An-158").FirstOrDefault()).FirstOrDefault(),
                CustomerList = _customerData.CustomerListFill_B01(),
                BoardingCardList = null
            };

            Flight _flightD = new Flight()
            {
                Id = 4,
                FlightNum = FlightNumData.FlightNumFill().Where(p => p.Key == 4).Select(p => p.Value).FirstOrDefault(),
                FligthDirect = Direct.Arrivals,
                FromPlace = "Lviv",
                ToPlace = "Kyiv",
                TerminalGate = Terminal.B,
                FlightStatus = FlightStatus.Expected,
                DepartureTime = DateTime.Now.AddHours(-2),
                ArrivalTime = DateTime.Now.AddHours(1.5),
                Airplane = (Airplane)_airlineData._airlineList.Select(p => p.AirplaneList.Where(y => y.Name == "Airbus_A350").FirstOrDefault()).FirstOrDefault(),
                CustomerList = _customerData.CustomerListFill_B02(),
                BoardingCardList = null
            };

            _flightDataList = new List<Flight> { _flightA, _flightB, _flightC, _flightD };

            return _flightDataList;
        }


    }
}
