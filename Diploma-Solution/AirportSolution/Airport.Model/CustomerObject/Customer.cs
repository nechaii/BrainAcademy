namespace Airport.Model.CustomerObject
{
    using System;
    using Airport.Model.BoardingCardObject;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    [Table("Customers", Schema = "Airport")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Column("Created", TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }

        [MaxLength(100), Required]
        public string FirstName { get; set; }

        [MaxLength(100),Required]
        public string MiddleName { get; set; }

        [MaxLength(100),Required]
        public string LastName { get; set; }

        [MaxLength(10), Required]
        public string DocumentSeries { get; set; }

        [MaxLength(20), Required]
        public string DocumentNum { get; set; }

        [Required]
        public DocumentType DocumentType { get; set; }

        [Required]
        public Sex Sex { get; set; }

        [Column("DateBorn", TypeName = "datetime2")]
        public DateTime DateBorn { get; set; }

        [Required]
        public string Nationality { get; set; }

        public virtual ICollection<BoardingCard> BoardingCard { get; set; }

        public Customer()
        {
            BoardingCard = new HashSet<BoardingCard>();
        }
    }
}
