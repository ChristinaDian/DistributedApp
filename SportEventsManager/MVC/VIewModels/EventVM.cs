using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.VIewModels
{
    public class EventVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Town { get; set; }
        [Required]
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        public int MaxParticipants { get; set; }
        public int? OrganisationId { get; set; }
        public virtual OrganisationVM Organisation { get; set; }
        public ICollection<UserVM> Participants { get; set; }

        public EventVM() { }

        public EventVM(EventDTO eventDTO)
        {
            Id = eventDTO.Id;
            Name = eventDTO.Name;
            StartDate = eventDTO.StartDate;
            EndDate = eventDTO.EndDate;
            Town = eventDTO.Town;
            Address = eventDTO.Address;
            Price = eventDTO.Price;
            MaxParticipants = eventDTO.MaxParticipants;
            OrganisationId = eventDTO.OrganisationId;
            Organisation = new OrganisationVM
            {
                Id = eventDTO.Organisation.Id,
                Name = eventDTO.Organisation.Name,
                Description = eventDTO.Organisation.Description,
            };
            Participants = new List<UserVM>();
        }
    }
}