using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model.Initialize
{
    using AirplaneObject;
    using Airport.Model.TimeTableObject;

    public class TimeTableData
    {
        List<TimeTable> _timeTableList = null;

        public TimeTableData()
        {
            _timeTableList = TimeTableListFill();
        }

        public void AddFlight(TimeTable timeTable)
        {
            //_timeTableList.Add(timeTable);
            Console.WriteLine("Was added");
        }

        public void RemoveFlight(TimeTable timeTable)
        {
            //_timeTableList.Remove(timeTable);
            Console.WriteLine("Was deleted");
        }

        public void ChangeFlight(TimeTable timeTable)
        {
            //_timeTableList.(timeTable);
            Console.WriteLine("Was changed");
        }

        public void GetAllPassenger(TimeTable timeTable)
        {
            //_timeTableList.(timeTable);
            Console.WriteLine("This is list of passengers");
        }

        List<TimeTable> TimeTableListFill()
        {
            FlightData _flightData = new FlightData();

            TimeTable _timeTableA = new TimeTable
            {
                Id = 1,
                ExpectedDepartureTime = null,
                ExpectedArrivalTime = null,
                FligthDirect = Direct.Departures,
                Flight = (Flight)_flightData._flightDataList.Where(p => p.Id == 1).FirstOrDefault()
            };

            TimeTable _timeTableB = new TimeTable
            {
                Id = 2,
                ExpectedDepartureTime = null,
                ExpectedArrivalTime = null,
                FligthDirect = Direct.Departures,
                Flight = (Flight)_flightData._flightDataList.Where(p => p.Id == 2).FirstOrDefault()
            };

            TimeTable _timeTableC = new TimeTable
            {
                Id = 3,
                ExpectedDepartureTime = null,
                ExpectedArrivalTime = (DateTime)_flightData._flightDataList.Where(p => p.Id == 3).Select(p=> p.ArrivalTime).FirstOrDefault(),
                FligthDirect = Direct.Arrivals,
                Flight = (Flight)_flightData._flightDataList.Where(p => p.Id == 3).FirstOrDefault()
            };

            TimeTable _timeTableD = new TimeTable
            {
                Id = 4,
                ExpectedDepartureTime = null,
                ExpectedArrivalTime = (DateTime)_flightData._flightDataList.Where(p => p.Id == 4).Select(p => p.ArrivalTime).FirstOrDefault(),
                FligthDirect = Direct.Arrivals,
                Flight = (Flight)_flightData._flightDataList.Where(p => p.Id == 4).FirstOrDefault()
            };

            return _timeTableList = new List<TimeTable> { _timeTableA, _timeTableB, _timeTableC, _timeTableD };
        }

        public StringBuilder PrintTimeTableArrivalsData()
        {
            StringBuilder _timeTablePrint = new StringBuilder();
            int counter = 1;

            var _timeTableArrivals = _timeTableList.Where(p => p.FligthDirect == Direct.Arrivals);

            foreach (TimeTable _t in _timeTableArrivals)
            {
                counter++;
                new string('*',120);
                _timeTablePrint.AppendFormat("№: {0}, рейс: {1}, направление: {2}, статус: {3}, прибытие {4:g}, терминал {5} \n", _t.Id, _t.Flight.FlightNum,_t.Flight.FromPlace+" "+ _t.Flight.ToPlace, _t.Flight.FlightStatus, _t.ExpectedArrivalTime, _t.Flight.TerminalGate);
            }           

            return _timeTablePrint;
        }

        public StringBuilder PrintTimeTableDepartureData()
        {
            StringBuilder _timeTablePrint = new StringBuilder();
            int counter = 1;

            var _timeTableArrivals = _timeTableList.Where(p => p.FligthDirect == Direct.Departures);

            foreach (TimeTable _t in _timeTableArrivals)
            {
                counter++;
                new string('*', 120);
                _timeTablePrint.AppendFormat("№: {0}, рейс: {1}, направление: {2}, статус: {3}, отправка {4:g}, терминал {5} \n", _t.Id, _t.Flight.FlightNum, _t.Flight.FromPlace + " " + _t.Flight.ToPlace, _t.Flight.FlightStatus, _t.ExpectedArrivalTime, _t.Flight.TerminalGate);
            }

            return _timeTablePrint;
        }
    }
}
