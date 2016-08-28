using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    using BoardingCardObject;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CashBoxes", Schema = "Airport")]
    public class CashBox
    {
        [Key, ForeignKey("BoardingCard")]
        public int Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? DateOperation { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public decimal Rate { get; set; }

        [Required]
        public virtual BoardingCard BoardingCard { get; set; }

        public CashBox()
        {
            
        }
    }
}
