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
    public class UserManagementService
    {
		public  User user;
        public UserManagementService()
        {
			this.user = new User();
        }

        public List<UserDTO> Get(string searchByName, string searchByTown, int? page)
		{
			List<UserDTO> usersDTO = new List<UserDTO>();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				foreach (var item in unitOfWork.UserRepository.Get())
				{						
					if (!String.IsNullOrEmpty(searchByName)&&(!item.LastName.ToUpper().Contains(searchByName.ToUpper())&& !item.FirstName.ToUpper().Contains(searchByName.ToUpper())))
					{
						continue;
					}
					if (!String.IsNullOrEmpty(searchByTown)&&!item.Town.Contains(searchByTown))
					{
						continue;
					}	
					UserDTO userDTO = new UserDTO();				
					
					userDTO.Id = item.Id;
					userDTO.Username = item.Username;
					userDTO.Password = item.Password;
					userDTO.FirstName = item.FirstName;
					userDTO.LastName = item.LastName;
					userDTO.Age = item.Age;
					userDTO.Town = item.Town;

					usersDTO.Add(userDTO);                   
				}
			}
			if(page == null)
            {
				page = 1;
            }
			int itemsPerPage = 2;
			int pagesCount=(int)Math.Ceiling(usersDTO.Count/(double)itemsPerPage);
			return usersDTO.Skip((int)(itemsPerPage * (page-1))).Take(itemsPerPage).ToList();		
		}
		public UserDTO GetById(int id)
		{
			UserDTO userDTO = new UserDTO();

			using (UnitOfWork unitOfWork = new UnitOfWork())
			{
				User user = unitOfWork.UserRepository.GetByID(id);

				if (user != null)
				{
					userDTO.Username = user.Username;
					userDTO.Password = user.Password;
					userDTO.FirstName = user.FirstName;
					userDTO.LastName = user.LastName;
					userDTO.Age = user.Age;
					userDTO.Town = user.Town;
				}

				return userDTO;
			}
		}

		public bool Save(UserDTO userDTO)
		{
			User user = new User
			{
				Id = userDTO.Id,
				Username = userDTO.Username,
				Password = userDTO.Password,
				FirstName = userDTO.FirstName,
				LastName = userDTO.LastName,	
				Age = userDTO.Age,
				Town = userDTO.Town
			};

			try
			{
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					if (userDTO.Id == 0)
					{
						unitOfWork.UserRepository.Insert(user);	
					}
                    else
                    {
						unitOfWork.UserRepository.Update(user);
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
		public bool Update(UserDTO userDTO)
        {
            try
            {
				using (UnitOfWork unitOfWork = new UnitOfWork())
				{
					user = unitOfWork.UserRepository.GetByID(userDTO.Id);
					user.Username = userDTO.Username;
					user.Password = userDTO.Password;
					user.FirstName = userDTO.FirstName;
					user.LastName = userDTO.LastName;
					user.Age = userDTO.Age;	
					user.Town = userDTO.Town;	

					unitOfWork.UserRepository.Update(user);
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
					unitOfWork.UserRepository.Delete(id);
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
