using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableFlightManage
{
    using Airport.Model.Initialize;

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.UTF8Encoding.UTF8;

            TimeTableData _timeTableData = new TimeTableData();
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(_timeTableData.PrintTimeTableArrivalsData());

            Console.ReadKey();


        }
    }
}
