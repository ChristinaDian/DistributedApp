using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.VIewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        [MinLength(8, ErrorMessage = "The password must be at least 8 characters!")]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [StringLength(50)]
        public string Town { get; set; }
        
        public UserVM() { }
        public UserVM(UserDTO userDTO)
        {
            Id = userDTO.Id;
            Username = userDTO.Username;
            Password = userDTO.Password;
            FirstName = userDTO.FirstName;
            LastName = userDTO.LastName;
            Age = userDTO.Age;
            Town = userDTO.Town;
        }
    }
}