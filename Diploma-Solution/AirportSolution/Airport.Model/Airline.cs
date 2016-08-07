namespace Airport.Model
{
    using System.Collections.Generic;
    using Airport.Model.AirplaneObject;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Airlines", Schema = "Airport")]
    public class Airline
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; }

        [MaxLength(200), Required]
        public string Address { get; set; }

        [MaxLength(50), Required]
        public string Phone { get; set; }

        public virtual ICollection<Airplane> Airplane { get; set; }

        public Airline()
        {
            this.Airplane = new HashSet<Airplane>();
        }
    }
}
