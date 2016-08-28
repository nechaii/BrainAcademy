using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRightInitializationDB.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Students", Schema = "Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50), Required]
        public string FirstName { get; set; }

        [MaxLength(50), Required]
        public string LastName { get; set; }

        [MaxLength(10), Required]
        public string StudNum { get; set; }

        public int? GroupId { get; set; }

        public Group Group { get; set; }
    }
}
