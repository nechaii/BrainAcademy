using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_SimpleADO
{
    class Program
    {
        static void Main(string[] args)
        {
            MyFrameWorkDB _myFrameWorkDB = new MyFrameWorkDB();
            List<Student> student = _myFrameWorkDB.GetStudent();

            foreach (var p in student)
            {
                Console.WriteLine("ID: {0}, FirstName: {1}, LastName: {2}, Grade: {3}, AvgGrade: {4}, Birthdate: {5}", p.ID, p.FirstName, p.LastName, p.Grade, p.AvgGrade, p.Birthdate);
            }
            

            Console.ReadKey();
        }
    }
}
