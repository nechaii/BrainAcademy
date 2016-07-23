using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model.Initialize
{
    static class FlightNumData
    {
        static SortedList<int, string> _flightNum = null;

        static public SortedList<int, string> FlightNumFill()
        {
            _flightNum = new SortedList<int, string>();
            _flightNum[1] = "A01";
            _flightNum[2] = "A02";
            _flightNum[3] = "B01";
            _flightNum[4] = "B02";

            return _flightNum;
        }

    }
}
