using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class EventDTO:BaseDTO
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        public int MaxParticipants { get; set; }
        public int? OrganisationId { get; set; }
        public virtual OrganisationDTO Organisation { get; set; }
        public ICollection<UserDTO> Participants { get; set; }
    }
}
