using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace FEBEPrototype.Web.Models
{
    public class User : IdentityUser
    {
        public List<Project> Projects { get; set; }

        public User()
        {
            Projects = new List<Project>();
        }
    }
}
