using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model.Initialize
{
    using Airport.Model.AirplaneObject;

    public class AirplaneData
    {
        List<Airplane> _airplainList = null;

        public AirplaneData()
        {
            //AirplaneListFill();
        }

        public List<Airplane> AirplaneListFill()
        {
            //1
            List<Seat> AN_158_Seat = new List<Seat>();
            for (int i = 1; i <= 99; i++)
                AN_158_Seat.Add(new Seat() { Id = i, SeatTypePlace = SeatType.Econom });
            Airplane AN_158 = new Airplane() {Id = 1, Model = "An-158", SeatTypeList = AN_158_Seat};

            //2
            List<Seat> Airbus_A350_Seat = new List<Seat>();
            for (int i = 1; i <= 270; i++)
                Airbus_A350_Seat.Add(new Seat() { Id = i, SeatTypePlace = SeatType.Econom });
            for (int i = 1; i <= 312; i++)
                Airbus_A350_Seat.Add(new Seat() { Id = i, SeatTypePlace = SeatType.Turist });
            Airplane Airbus_A350 = new Airplane() { Id = 1, Model = "Airbus_A350", SeatTypeList = Airbus_A350_Seat};

            //3
            List<Seat> Boeing_737_Seat = new List<Seat>();
            for (int i = 1; i <= 100; i++)
                Boeing_737_Seat.Add(new Seat() { Id = i, SeatTypePlace = SeatType.Turist });
            for (int i = 1; i <= 10; i++)
                Airbus_A350_Seat.Add(new Seat() { Id = i, SeatTypePlace = SeatType.Vip });
            Airplane Boeing_737 = new Airplane() { Id = 1, Model = "Boeing_737", SeatTypeList = Airbus_A350_Seat };

            //4            
            List<Seat> Bombardier_CRJ_1000_Seat = new List<Seat>();
            for (int i = 1; i <= 100; i++)
                Bombardier_CRJ_1000_Seat.Add(new Seat() { Id = i, SeatTypePlace = SeatType.Turist });
            Airplane Bombardier_CRJ_1000 = new Airplane() { Id = 1, Model = "Bombardier_CRJ_1000", SeatTypeList = Airbus_A350_Seat };

            //5            
            List<Seat> Dassault_Falcon_900_Seat = new List<Seat>();
            for (int i = 1; i <= 100; i++)
                Dassault_Falcon_900_Seat.Add(new Seat() { Id = i, SeatTypePlace = SeatType.Vip });
            Airplane Dassault_Falcon_900 = new Airplane() { Id = 1, Model = "Dassault_Falcon_900", SeatTypeList = Airbus_A350_Seat };

            _airplainList = new List<Airplane> { AN_158, Airbus_A350, Boeing_737, Bombardier_CRJ_1000, Dassault_Falcon_900 };

            return _airplainList;
        }
    }
}
