using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class RegistrationDetails
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        [Required]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
