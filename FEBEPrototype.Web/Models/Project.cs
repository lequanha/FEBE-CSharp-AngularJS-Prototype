using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FEBEPrototype.Web.Models
{
    public class Project
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }

        public List<ProjectComponent> ProjectComponents { get; set; }
        public User User { get; set; }
        
        [ForeignKey("User")]
        public string UserId { get; set; }

        public List<string> Tags { get; set; }

        public Project()
        {
            ProjectComponents = new List<ProjectComponent>();
        }
    }
}

