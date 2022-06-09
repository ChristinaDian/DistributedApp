using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    public class Event : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public int MaxParticipants { get; set; }
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        public int? OrganisationId { get; set; }
        public virtual Organisation Organisation { get; set; }

        public virtual ICollection<User> Participants { get; set; }


    }
}
