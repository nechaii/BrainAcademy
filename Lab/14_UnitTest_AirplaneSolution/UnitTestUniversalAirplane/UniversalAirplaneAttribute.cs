using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestUniversalAirplane
{
    using AirplaneLibrary;

    [TestClass]
    public class UniversalAirplaneAttribute
    {
        [TestMethod]
        public void CheckUniversalAirplane_CountAttribute()
        {
            Type universalAirplane = typeof(UniversalAirplane);
            dynamic[] attributessList = universalAirplane.GetCustomAttributes(false);
            int flag = attributessList.GetLength(0);

            Assert.AreEqual(2, flag);
        }

        [TestMethod]
        public void CheckUniversalAirplane_ValueAttribute()
        {
            Type universalAirplane = typeof(UniversalAirplane);
            object[] attributessList = universalAirplane.GetCustomAttributes(false);

            AirplaneTypes jetAirplaneTypes = AirplaneTypes.Jet;
            AirplaneTypes cargoPlaneAirplaneTypes = AirplaneTypes.CargoPlane;

            int cnt = 0;

            foreach (var att in attributessList)
            {
                var flag = att as AirplaneTypeAttribute;
                if (flag.Type == jetAirplaneTypes)
                    cnt++;
                else if (flag.Type == cargoPlaneAirplaneTypes)
                    cnt++;
                else
                    cnt = 0;
            }
            Assert.AreEqual(2, cnt);
        }
    }
}
