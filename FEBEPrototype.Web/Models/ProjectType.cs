using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FEBEPrototype.Web.Models
{
    public class ProjectType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public List<ProjectTypeComponent> ProjectTypeComponents { get; set; }

        public ProjectType()
        {
            ProjectTypeComponents = new List<ProjectTypeComponent>();
        }


    }
}
