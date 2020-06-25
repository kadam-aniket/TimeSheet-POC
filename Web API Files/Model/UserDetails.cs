using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserAddress { get; set; }

        public virtual ProjectDetail ProjectDetails { get; set; }
    }
}
