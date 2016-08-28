
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Operation
{
    using Airport.Model.TimeTableObject;
    using Model;

    public class TimeTableOperation
    {
        TimeTable Create(Flight flight)
        {
            TimeTable timeTable = new TimeTable()
            {
                ExpectedDepartureTime = flight.DepartureTime,
                ExpectedArrivalTime = flight.ArrivalTime,
                Flight = flight
            };

            return timeTable;
        }

        public ICollection<TimeTable> CreateTimeTable(ICollection<Flight> flight)
        {
            List<TimeTable> timeTable = new List<TimeTable>(flight.Count());

            foreach (var item in flight)
            {
                timeTable.Add(Create(item));
            }
            return timeTable;
        }

    }
}
