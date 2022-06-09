using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.VIewModels
{
    public class OrganisationVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Display(Name = "Owner")]
        public int? UserId { get; set; }
        public virtual UserVM Owner { get; set; }
        public ICollection<EventVM> HostedEvents { get; set; }

        public OrganisationVM() { }

        public OrganisationVM(OrganisationDTO organisationDTO)
        {
            Id = organisationDTO.Id;
            Name = organisationDTO.Name;
            Description = organisationDTO.Description;
            UserId = organisationDTO.UserId;
            Owner = new UserVM
            {
                Id = organisationDTO.Owner.Id,
                Username = organisationDTO.Owner.Username,
                Password = organisationDTO.Owner.Password,
                FirstName = organisationDTO.Owner.FirstName,
                LastName = organisationDTO.Owner.LastName,
                Age = organisationDTO.Owner.Age,
                Town = organisationDTO.Owner.Town
            };
            HostedEvents = new List<EventVM>();
        }
    }
}