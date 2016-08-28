
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Operation
{
    using Airport.Model;
    using Model.AirplaneObject;
    using Model.BoardingCardObject;

    class BoardingCardOperation
    {
        public BoardingCard Create(Seat seat)
        {
            BoardingCard _boardingCard = new BoardingCard()
            {
                DateAdded = DateTime.UtcNow,
                DateLastOperation = DateTime.UtcNow,
                BoardingCardStatus = BoardingCardStatus.InStock,
                Price = 0,
                SeatNum = seat.SeatNum,
                Customer = null,
                Flight = null
            };

            return _boardingCard;
        }

    }
}
