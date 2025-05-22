using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEBEPrototype.Web.Models
{
    public class ProjectComponent
    {
        public int ProjectId { get; set; }
        public int ComponentId { get; set; }
        public Project Project { get; set; }
        public Component Component { get; set; }
    }
}
