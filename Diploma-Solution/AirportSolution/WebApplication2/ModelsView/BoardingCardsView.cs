using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.ModelsView
{
    using Airport.Model.BoardingCardObject;

    public class BoardingCardsView
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateLastOperation { get; set; }
        public BoardingCardStatus? BoardingCardStatus { get; set; }
        public decimal Price { get; set; }
        public int? SeatNum { get; set; }
        public string Operation { get; set; }
    }
}