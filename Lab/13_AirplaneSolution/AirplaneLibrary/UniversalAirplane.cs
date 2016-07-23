namespace AirplaneLibrary
{
    using System;
    using AirplaneBehavior;


    [AirplaneTypeAttribute(AirplaneTypes.CargoPlane)]
    [AirplaneType(AirplaneTypes.Jet, Vercion = 5)]
    public class UniversalAirplane: IBehavior
    {
        string name;
        int pilotCount;

        public string Name {
            get {
                return this.name;
            }
            set {
                this.name = value;
            }
        }

        public int PilotCount {
            get
            {
                return this.pilotCount;
            }
            set
            {
                this.pilotCount = value;
            }
        }

        public UniversalAirplane()
        {
            this.name = "UniversalAirplane";
            this.pilotCount = 1;
        }

        public UniversalAirplane(string name):this()
        {
            this.name = name;
        }

        public UniversalAirplane(string name, int cnt)
        {
            this.name = name;
            this.pilotCount = cnt;
        }


        public void Fly()
        {
            Console.WriteLine(this.Name + " is flying");
        }

        public void TakeOff()
        {
            Console.WriteLine(this.Name + " is takeoff");
        }

        // у меня студия 15 и рефлексия не увидела прайвет.
        //private void GetFlightAttendant()
        //{
        //    Console.WriteLine(this.Name + " going to call flight attendant");
        //}

        public void GetFlightAttendant(string str)
        {
            Console.WriteLine(this.Name + " going to call flight attendant" + str);
        }
    }
}
