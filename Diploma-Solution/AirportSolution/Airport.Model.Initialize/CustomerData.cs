using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model.Initialize
{
    using Airport.Model.CustomerObject;
    using Airport.Model.BoardingCardObject;
    using Airport.Model.AirplaneObject;

    class CustomerData
    {
        List<Customer> _flightDataList = null;

        public CustomerData()
        { }

        public List<Customer> CustomerListFill_B01()
        {
            _flightDataList = new List<Customer>();
            Random _ran = new Random(12);                        

            for (int i = 1; i <= 27; i++)
            {
                Customer _customer = new Customer()
                {
                    Id = i,
                    FirstName = "Jo_BotName-" + i.ToString(),
                    MiddleName = "Jo_BotmiddleName-" + i.ToString(),
                    LastName = "Jo_BotLastName-" + i.ToString(),
                    DocumentSeries = "A-" + i.ToString(),
                    DocumentNum = "00" + i.ToString(),
                    DocType = DocumentType.Passport,
                    CustomerSex = Sex.Male,
                    DateBorn = new DateTime(1985, 01, 01),
                    Nationality = "Ukrainian",
                    BoardingCard = new BoardingCard()
                    {
                        Id = i,
                        Price = 45.27,
                        SeatType = SeatType.Econom,
                        Status = BoardingCardStatus.Sold,
                        FlightNum = FlightNumData.FlightNumFill().Where(p => p.Key == 3).Select(p => p.Value).FirstOrDefault()
                    }
                };
                    _flightDataList.Add(_customer);              
            }
            return _flightDataList;
        }

        public List<Customer> CustomerListFill_B02()
        {
            _flightDataList = new List<Customer>();
            Random _ran = new Random(12);

            for (int i = 1; i <= 50; i++)
            {
                Customer _customer = new Customer()
                {
                    Id = i,
                    FirstName = "Tom_BotName-" + i.ToString(),
                    MiddleName = "BotmiddleName-" + i.ToString(),
                    LastName = "BotLastName-" + i.ToString(),
                    DocumentSeries = "A-" + i.ToString(),
                    DocumentNum = "00" + i.ToString(),
                    DocType = DocumentType.Passport,
                    CustomerSex = Sex.Male,
                    DateBorn = new DateTime(1986, 02, 02),
                    Nationality = "Ukrainian",
                    BoardingCard = new BoardingCard()
                    {
                        Id = i,
                        Price = 45.27,
                        SeatType = SeatType.Econom,
                        Status = BoardingCardStatus.Sold,
                        FlightNum = FlightNumData.FlightNumFill().Where(p => p.Key == 4).Select(p => p.Value).FirstOrDefault(),
                    }
                };

                    _flightDataList.Add(_customer);
            }

            for (int i = 1; i <= 30; i++)
            {
                Customer _customer = new Customer()
                {
                    Id = i,
                    FirstName = "BotName-" + i.ToString(),
                    MiddleName = "BotmiddleName-" + i.ToString(),
                    LastName = "BotLastName-" + i.ToString(),
                    DocumentSeries = "A-" + i.ToString(),
                    DocumentNum = "00" + i.ToString(),
                    DocType = DocumentType.Passport,
                    CustomerSex = Sex.Male,
                    DateBorn = new DateTime(1987, 03, 03),
                    Nationality = "Ukrainian",
                    BoardingCard = new BoardingCard()
                    {
                        Id = i,
                        Price = 125.27,
                        SeatType = SeatType.Turist,
                        Status = BoardingCardStatus.Sold,
                        FlightNum = FlightNumData.FlightNumFill().Where(p => p.Key == 4).Select(p => p.Value).FirstOrDefault(),
                    }
                };
                    _flightDataList.Add(_customer);
            }
            return _flightDataList;
        }

    }
}
