using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FEBEPrototype.Web.DTOs
{
    public class CreateProjectRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Tags { get; set; }
        public List<int> ComponentIds { get; set; }

        public CreateProjectRequest()
        {
            Tags = new List<string>();
            ComponentIds = new List<int>();
        }
    }
}
