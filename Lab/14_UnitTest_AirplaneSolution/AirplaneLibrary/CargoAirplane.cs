namespace AirplaneLibrary
{
    using System;
    using AirplaneBehavior;


    [AirplaneType(AirplaneTypes.CargoPlane)]
    public class CargoAirplane: IBehavior
    {
        public CargoAirplane()
        {
        }

        public void Fly()
        {
            Console.WriteLine("CargoAirplane is flying");
        }

        public void TakeOff()
        {
            Console.WriteLine("CargoAirplane is takeoff");
        }
    }
}
