using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTableFlightManage
{
    using Airport.Model.Initialize;
    //class 

    class Program
    {
        static void ManageTimeTable(TimeTableData timeTableData)
        {
            Console.WriteLine("Управление расписанием");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A- Добавить \nB- Удалить \nC- Изменить");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.A:
                    {
                        timeTableData.AddFlight();
                    }
                    break;
                case ConsoleKey.B:
                    {
                        timeTableData.RemoveFlight();
                    }
                    break;
                case ConsoleKey.C:
                    {
                        timeTableData.ChangeFlight();
                    }
                    break;
                default:
                    {
                    }
                    break;
            }
        }

        static void ViewTimeTableDetails()
        {
            Console.WriteLine("Детали рейса");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("A- Список пасажиров \nB- Что то еще");
        }

        static void PrintMenu()
        {
            Console.WriteLine("A- Обслуживание клиентов \nB- Управление полетами \nC- Информация о рейсе");
        }

        static void MainOperation(TimeTableData timeTableData, ConsoleKey key)
        {
            //string input = Convert.ToChar(Console.ReadKey()).ToString().ToUpper();
            switch (key) 
            {
                case ConsoleKey.A:
                    {
                        throw new NotImplementedException();
                    }
                    break;
                case ConsoleKey.B:
                    {
                        ManageTimeTable(timeTableData);
                    }
                    break;
                case ConsoleKey.C:
                    {
                        ViewTimeTableDetails();
                    }
                    break;
                default:
                    {
                    }
                    break;
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.UTF8Encoding.UTF8;

            TimeTableData _timeTableData = new TimeTableData();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ожидаем");
            Console.WriteLine(_timeTableData.PrintTimeTableArrivalsData());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Отправляем");
            Console.WriteLine(_timeTableData.PrintTimeTableDepartureData());

            Console.ForegroundColor = ConsoleColor.Gray;

            while (true)
            {                
                PrintMenu();
                ConsoleKey key = Console.ReadKey().Key;
                MainOperation(_timeTableData, key);
            }

            Console.ReadKey();
        }
    }
}
