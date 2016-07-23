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
                using (Customer _customer = new Customer())
                {
                    _customer.Id = i;
                    _customer.FirstName = "Jo_BotName-" + i.ToString();
                    _customer.MiddleName = "Jo_BotmiddleName-" + i.ToString();
                    _customer.LastName = "Jo_BotLastName-" + i.ToString();
                    _customer.DocumentSeries = "A-"+i.ToString();
                    _customer.DocumentNum = "00" + i.ToString();
                    _customer.DocType = DocumentType.Passport;
                    _customer.CustomerSex = Sex.Male;
                    _customer.DateBorn = new DateTime(1985, _ran.Next(), _ran.Next(20));
                    _customer.Nationality = "Ukrainian";
                    _customer.BoardingCard = new BoardingCard() {
                        Id = i,
                        Price = 45.27,
                        SeatType = SeatType.Econom,
                        Status =BoardingCardStatus.Sold,
                        FlightNum = FlightNumData.FlightNumFill().Where(p => p.Key == 3).Select(p => p.Value).FirstOrDefault(),
                    };

                    _flightDataList.Add(_customer);
                }                
            }
            return _flightDataList;
        }

        public List<Customer> CustomerListFill_B02()
        {
            _flightDataList = new List<Customer>();
            Random _ran = new Random(12);

            for (int i = 1; i <= 50; i++)
            {
                using (Customer _customer = new Customer())
                {
                    _customer.Id = i;
                    _customer.FirstName = "Tom_BotName-" + i.ToString();
                    _customer.MiddleName = "BotmiddleName-" + i.ToString();
                    _customer.LastName = "BotLastName-" + i.ToString();
                    _customer.DocumentSeries = "A-" + i.ToString();
                    _customer.DocumentNum = "00" + i.ToString();
                    _customer.DocType = DocumentType.Passport;
                    _customer.CustomerSex = Sex.Male;
                    _customer.DateBorn = new DateTime(1985, _ran.Next(), _ran.Next(20));
                    _customer.Nationality = "Ukrainian";
                    _customer.BoardingCard = new BoardingCard()
                    {
                        Id = i,
                        Price = 45.27,
                        SeatType = SeatType.Econom,
                        Status = BoardingCardStatus.Sold,
                        FlightNum = FlightNumData.FlightNumFill().Where(p => p.Key == 4).Select(p => p.Value).FirstOrDefault(),
                    };

                    _flightDataList.Add(_customer);
                }
            }

            for (int i = 1; i <= 30; i++)
            {
                using (Customer _customer = new Customer())
                {
                    _customer.Id = i;
                    _customer.FirstName = "BotName-" + i.ToString();
                    _customer.MiddleName = "BotmiddleName-" + i.ToString();
                    _customer.LastName = "BotLastName-" + i.ToString();
                    _customer.DocumentSeries = "A-" + i.ToString();
                    _customer.DocumentNum = "00" + i.ToString();
                    _customer.DocType = DocumentType.Passport;
                    _customer.CustomerSex = Sex.Male;
                    _customer.DateBorn = new DateTime(1985, _ran.Next(), _ran.Next(20));
                    _customer.Nationality = "Ukrainian";
                    _customer.BoardingCard = new BoardingCard()
                    {
                        Id = i,
                        Price = 125.27,
                        SeatType = SeatType.Turist,
                        Status = BoardingCardStatus.Sold,
                        FlightNum = FlightNumData.FlightNumFill().Where(p => p.Key == 4).Select(p => p.Value).FirstOrDefault(),
                    };

                    _flightDataList.Add(_customer);
                }
            }
            return _flightDataList;
        }

    }
}
