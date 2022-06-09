using ApplicationService.DTOs;
using Data.Entity;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class OrganisationManagementService
    {
        public Organisation organisation;
        public OrganisationManagementService()
        {
            this.organisation = new Organisation();
        }
        public List<OrganisationDTO> Get(string searchByName, int? page)
        {
            List<OrganisationDTO> organisationsDTO = new List<OrganisationDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.OrganisationRepository.Get())
                {
                    OrganisationDTO organisationDTO = new OrganisationDTO();

                    if (!String.IsNullOrEmpty(searchByName) && !item.Name.ToUpper().Contains(searchByName.ToUpper()))
                    {
                        continue;
                    }

                    organisationDTO.Id = item.Id;
                    organisationDTO.Name = item.Name;
                    organisationDTO.Description = item.Description;
                    organisationDTO.HostedEvents = new List<EventDTO>();
                    if (item.UserId > 0)
                    {
                        organisationDTO.UserId = item.UserId;
                        User user = unitOfWork.UserRepository.GetByID(item.UserId);
                        UserDTO userDTO = new UserDTO();
                        userDTO.Id = user.Id;
                        userDTO.Username = user.Username;
                        userDTO.Password = user.Password;
                        userDTO.FirstName = user.FirstName;
                        userDTO.LastName = user.LastName;
                        userDTO.Age = user.Age;
                        userDTO.Town = user.Town;

                        organisationDTO.Owner = userDTO;
                    }

                    if (item.HostedEvents.Count >1)
                    {
                        foreach (var @event in item.HostedEvents)
                        {
                            EventDTO eventDTO = new EventDTO();
                            eventDTO.Id = @event.Id;
                            eventDTO.Name = @event.Name;
                            eventDTO.StartDate = @event.StartDate;
                            eventDTO.EndDate = @event.EndDate;
                            eventDTO.Town = @event.Town;
                            eventDTO.Address = @event.Address;
                            eventDTO.MaxParticipants = @event.MaxParticipants;
                            eventDTO.Price = @event.Price;
                            eventDTO.OrganisationId = @event.OrganisationId;

                            organisationDTO.HostedEvents.Add(eventDTO);
                        }
                    }
                    organisationsDTO.Add(organisationDTO);
                }
            }
            if (page == null)
            {
                page = 1;
            }
            int itemsPerPage = 2;
            int pagesCount = (int)Math.Ceiling(organisationsDTO.Count / (double)itemsPerPage);
            return organisationsDTO.Skip((int)(itemsPerPage * (page - 1))).Take(itemsPerPage).ToList();
        }

        public OrganisationDTO GetById(int id)
        {
            OrganisationDTO organisationDTO = new OrganisationDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Organisation organisation = unitOfWork.OrganisationRepository.GetByID(id);

                if (organisation != null)
                {
                    organisationDTO.Name = organisation.Name;
                    organisationDTO.Description = organisation.Description;
                    organisationDTO.HostedEvents = new List<EventDTO>();
                    if (organisation.UserId > 0)
                    {
                        organisationDTO.UserId = organisation.UserId;
                        User user = unitOfWork.UserRepository.GetByID(organisation.UserId);
                        UserDTO userDTO = new UserDTO();
                        userDTO.Id = user.Id;
                        userDTO.Username = user.Username;
                        userDTO.Password = user.Password;
                        userDTO.FirstName = user.FirstName;
                        userDTO.LastName = user.LastName;
                        userDTO.Age = user.Age;
                        userDTO.Town = user.Town;

                        organisationDTO.Owner = userDTO;
                    }
                    if (organisation.HostedEvents.Count > 1)
                    {
                        foreach (var @event in organisation.HostedEvents)
                        {
                            EventDTO eventDTO = new EventDTO();
                            eventDTO.Id = @event.Id;
                            eventDTO.Name = @event.Name;
                            eventDTO.StartDate = @event.StartDate;
                            eventDTO.EndDate = @event.EndDate;
                            eventDTO.Town = @event.Town;
                            eventDTO.Address = @event.Address;
                            eventDTO.MaxParticipants = @event.MaxParticipants;
                            eventDTO.Price = @event.Price;
                            eventDTO.OrganisationId = @event.OrganisationId;

                            organisationDTO.HostedEvents.Add(eventDTO);
                        }
                    }
                }

                return organisationDTO;
            }
        }

        public bool Save(OrganisationDTO organisationDTO)
        {
            Organisation organisation = new Organisation
            {
                Id = organisationDTO.Id,
                Name = organisationDTO.Name,
                Description = organisationDTO.Description,
                UserId = organisationDTO.UserId,
               
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (organisationDTO.Id == 0)
                    {
                        unitOfWork.OrganisationRepository.Insert(organisation);
                    }
                    else
                    {
                        unitOfWork.OrganisationRepository.Update(organisation);
                    }
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(OrganisationDTO organisationDTO)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    organisation = unitOfWork.OrganisationRepository.GetByID(organisationDTO.Id);
                    organisation.Name = organisationDTO.Name;
                    organisation.Description = organisationDTO.Description;
                    organisation.UserId = organisationDTO.UserId;
                    

                    unitOfWork.OrganisationRepository.Update(organisation);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.OrganisationRepository.Delete(id);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
