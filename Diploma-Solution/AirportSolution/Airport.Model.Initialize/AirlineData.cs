using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model.Initialize
{
    using Airport.Model;
    public class AirlineData
    {
        public List<Airline> _airlineList = null;

        public AirlineData()
        {
            _airlineList=AirlineListFill();
        }

        List<Airline> AirlineListFill()
        {
            AirplaneData _airplaneData = new AirplaneData();

            Airline _airline = new Airline() {Id=1, Name="UkraineAirline", Address="Ukraine, Kyiv, Golosievska 17 st., 7 floor", Phone="+380502598898",AirplaneList=_airplaneData.AirplaneListFill()};

            _airlineList = new List<Airline>() { _airline };

            return _airlineList;
        }
    }
}
