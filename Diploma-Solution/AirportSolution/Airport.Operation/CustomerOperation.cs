
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Operation
{
    using Airport.Model.CustomerObject;

    class CustomerOperation
    {

        public Customer Create(string firstName, string middleName, string lastName, string documentSeries, string documentNum, DocumentType documentType, Sex sex, DateTime dateBorn, string nationality)
        {
            Customer customer = new Customer()
            {
                DateAdded = DateTime.UtcNow,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                DocumentSeries = documentSeries,
                DocumentNum = documentNum,
                DocumentType = documentType,
                Sex = sex,
                DateBorn = dateBorn,
                Nationality = nationality,
                BoardingCard = null
            };
            return customer;
        }

    }
}
