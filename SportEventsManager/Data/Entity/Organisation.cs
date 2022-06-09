using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Organisation:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public int? UserId { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Event> HostedEvents { get; set; }  
    }
}
