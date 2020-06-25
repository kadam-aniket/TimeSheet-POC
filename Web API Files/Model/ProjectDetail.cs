using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ProjectDetail
    {   
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string ProjectManager { get; set; }
    }
}
