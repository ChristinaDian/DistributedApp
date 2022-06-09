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
    public class EventManagementService
    {
		public Event @event;
		public EventManagementService()
        {
			this.@event = new Event();
        }
		public List<EventDTO> Get(string searchByName, DateTime? searchByDate, int? page)
		{
			List<EventDTO> eventsDTO = new List<EventDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.EventRepository.Get())
				{
					EventDTO eventDTO = new EventDTO();

					if (!String.IsNullOrEmpty(searchByName) && !item.Name.ToUpper().Contains(searchByName.ToUpper()))
					{
						continue;
					}
					if (!String.IsNullOrEmpty(searchByDate.ToString()) && item.StartDate<=searchByDate)
					{
						continue;
					}
					eventDTO.Id = item.Id;
					eventDTO.Name = item.Name;
					eventDTO.StartDate = item.StartDate;
					eventDTO.EndDate = item.EndDate;
					eventDTO.Town = item.Town;
					eventDTO.Address = item.Address;
					eventDTO.Price = item.Price;
					eventDTO.MaxParticipants = item.MaxParticipants;

					if (item.OrganisationId >0)
					{
						eventDTO.OrganisationId = item.OrganisationId;
						Organisation organisation = item.Organisation;
						OrganisationDTO organisationDTO = new OrganisationDTO();
						organisationDTO.Id = organisation.Id;
						organisationDTO.Name = organisation.Name;
						organisationDTO.Description = organisation.Description;

						eventDTO.Organisation = organisationDTO;
					}
					if (item.Participants != null)
					{
						foreach (var user in item.Participants)
						{
							UserDTO userDTO = new UserDTO();
							userDTO.Id = user.Id;
							userDTO.Username = user.Username;
							userDTO.Password = user.Password;
							userDTO.FirstName = user.FirstName;
							userDTO.LastName = user.LastName;
							userDTO.Age = user.Age;
							userDTO.Town = user.Town;

							eventDTO.Participants.Add(userDTO);
						}
					}
					eventsDTO.Add(eventDTO);
				}
			}
			if (page == null)
			{
				page = 1;
			}
			int itemsPerPage = 2;
			int pagesCount = (int)Math.Ceiling(eventsDTO.Count / (double)itemsPerPage);
			return eventsDTO.Skip((int)(itemsPerPage * (page - 1))).Take(itemsPerPage).ToList();
		}

		public EventDTO GetById(int id)
		{
			EventDTO eventDTO = new EventDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				Event @event = unitOfWork.EventRepository.GetByID(id);

				if (@event != null)
				{
					eventDTO.Name = @event.Name;
					eventDTO.StartDate = @event.StartDate;
					eventDTO.EndDate = @event.EndDate;
					eventDTO.Town = @event.Town;
					eventDTO.Address = @event.Address;
					eventDTO.Price = @event.Price;
					eventDTO.MaxParticipants = @event.MaxParticipants;

					if (@event.OrganisationId >0)
					{
						eventDTO.OrganisationId = @event.OrganisationId;
						Organisation organisation = @event.Organisation;
						OrganisationDTO organisationDTO = new OrganisationDTO();
						organisationDTO.Id = organisation.Id;
						organisationDTO.Name = organisation.Name;
						organisationDTO.Description = organisation.Description;

						eventDTO.Organisation = organisationDTO;
					}
				}

				return eventDTO;
			}
		}

		public bool Save(EventDTO eventDTO)
		{
			Event @event = new Event
			{
				Id = eventDTO.Id,
				Name = eventDTO.Name,
				StartDate = eventDTO.StartDate,
				EndDate = eventDTO.EndDate,
				Town = eventDTO.Town,
				Address = eventDTO.Address,
				Price = eventDTO.Price,
				MaxParticipants = eventDTO.MaxParticipants,
				OrganisationId = eventDTO.OrganisationId
			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					if (eventDTO.Id == 0)
					{
						unitOfWork.EventRepository.Insert(@event);
					}
                    else
                    {
						unitOfWork.EventRepository.Update(@event);
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
		public bool Update(EventDTO eventDTO)
		{
			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					@event = unitOfWork.EventRepository.GetByID(eventDTO.Id);
					@event.Name = eventDTO.Name;
					@event.StartDate = eventDTO.StartDate;
					@event.EndDate = eventDTO.EndDate;
					@event.Town = eventDTO.Town;
					@event.Address = eventDTO.Address;
					@event.Price = eventDTO.Price;
					@event.MaxParticipants = eventDTO.MaxParticipants;
					@event.OrganisationId = eventDTO.OrganisationId;

					unitOfWork.EventRepository.Update(@event);
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
					unitOfWork.EventRepository.Delete(id);
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
