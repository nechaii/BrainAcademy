
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Operation
{
    using Airport.Model.TimeTableObject;

    class TimeTableOperation
    {
        public TimeTable Create()
        {
            TimeTable timeTable = new TimeTable()
            {
                ExpectedDepartureTime = null,
                ExpectedArrivalTime = null,
                Flight = null
            };

            return timeTable;
        }

    }
}
