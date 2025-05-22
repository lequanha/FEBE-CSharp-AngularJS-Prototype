using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEBEPrototype.Web.DTOs
{
    public class ProjectTypeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> ComponentIds { get; set; }

        public ProjectTypeResponse()
        {

        }
    }
}
