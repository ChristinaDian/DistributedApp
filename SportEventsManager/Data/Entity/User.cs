using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class User:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(8, ErrorMessage = "The password must be at least 8 characters!")]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Town { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Event> MyEvents { get; set; }

    }
}
