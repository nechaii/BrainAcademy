using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRightInitializationDB.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Groups", Schema = "Student")]
    public class Group
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public GroupNum GroupNum { get; set; }

        public ICollection<Student> Student { get; set; }

        public Group()
        {
            Student = new HashSet<Student>();
        }
    }
}
