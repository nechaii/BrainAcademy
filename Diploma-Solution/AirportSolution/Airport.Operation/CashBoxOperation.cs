using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Operation
{
    using Airport.Model;
    using Model.BoardingCardObject;

    public class CashBoxOperation
    {
        Flight flight = null;

        CashBox Create(BoardingCard boardingCard)
        {
            CashBox cashBox = new CashBox()
            {
                DateOperation = DateTime.UtcNow.AddMinutes(20),
                Rate = 0.02m,//some rate, we have to make money
                Sum = boardingCard.Price * 0.02m + boardingCard.Price,
                BoardingCard = boardingCard

            };
            boardingCard.BoardingCardStatus = BoardingCardStatus.Sold;
            boardingCard.DateAdded = flight.DateAdded.AddMinutes(10);
            boardingCard.DateLastOperation = flight.DateAdded.AddMinutes(20);

            return cashBox;
        }

        public ICollection<CashBox> SoldOperation(Flight flight)
        {
            this.flight = flight;

            ICollection<CashBox> cashBox = new List<CashBox>(flight.BoardingCard.Count()); 

            foreach (var item in flight.BoardingCard)
            {
                item.CashBox = Create(item);
            }
            return cashBox;
        }
    }

}
