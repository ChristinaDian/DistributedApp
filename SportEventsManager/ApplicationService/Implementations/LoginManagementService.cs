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
    public class LoginManagementService
    {
        private bool IsValid(LoginDTO loginDTO)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                var users = unitOfWork.UserRepository.Get();
                User loggedUser = users.Where(u => u.Password == loginDTO.Password && u.Username == loginDTO.Username).ToList().FirstOrDefault();
                if (loggedUser != null)
                {            
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool Validate(LoginDTO loginDTO)
        {
            return IsValid(loginDTO);
        }
    }
}
