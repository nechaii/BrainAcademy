using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneLibrary
{
    [System.AttributeUsage(
        System.AttributeTargets.Class | 
        System.AttributeTargets.Struct 
        /* | System.AttributeTargets.All*/, AllowMultiple = true, Inherited = true)]
    public class AirplaneTypeAttribute : System.Attribute
    {
        int vercion;
        public int Vercion { get { return vercion; } set { vercion = value; } }
        public AirplaneTypes Type { get; set; }

        public AirplaneTypeAttribute()
        {
            Type = AirplaneTypes.TurboProp;
        }

        public AirplaneTypeAttribute(AirplaneTypes airplaneType)
        {
            Type = airplaneType;
        }
    }
}
