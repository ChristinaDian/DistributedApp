using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class OrganisationDTO:BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public virtual UserDTO Owner { get; set; }
        public ICollection<EventDTO> HostedEvents { get; set; }
    }
}
