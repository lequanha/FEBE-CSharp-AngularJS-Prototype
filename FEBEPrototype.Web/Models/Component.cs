using System.ComponentModel.DataAnnotations;

namespace FEBEPrototype.Web.Models
{
    public class Component
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(500)]
        public string Description { get; set; }

    }
}
