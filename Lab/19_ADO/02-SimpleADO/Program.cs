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
            Console.OutputEncoding = System.Text.UTF8Encoding.UTF8;
            Console.WindowHeight = 20;
            Console.WindowWidth = 120;

            MyFrameWorkDB _myFrameWorkDB = new MyFrameWorkDB();
            List<Student> _std1 = _myFrameWorkDB._studentList;

            foreach (var p in _std1)
            {
                Console.WriteLine("ID: {0}, FirstName: {1}, LastName: {2}, Grade: {3}, AvgGrade: {4}, Birthdate: {5:D}", p.ID, p.FirstName, p.LastName, p.Grade, p.AvgGrade, p.Birthdate);
            }

            Console.WriteLine(new string('-',50));

            Dictionary<string,string> _std2 = _myFrameWorkDB._student;
            foreach (KeyValuePair<string, string> p in _std2)
            {
                Console.WriteLine("{0}: {1}",p.Key,p.Value);
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("AfterUpdate");

            foreach (KeyValuePair<string, string> p in _std2)
            {
                Console.WriteLine("{0}: {1}", p.Key, p.Value);
            }

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("AfterInsert");
            _myFrameWorkDB.GetStudent();
            foreach (var p in _std1)
            {
                Console.WriteLine("ID: {0}, FirstName: {1}, LastName: {2}, Grade: {3}, AvgGrade: {4}, Birthdate: {5:D}", p.ID, p.FirstName, p.LastName, p.Grade, p.AvgGrade, p.Birthdate);
            }

            Console.ReadKey();
        }
    }
}
