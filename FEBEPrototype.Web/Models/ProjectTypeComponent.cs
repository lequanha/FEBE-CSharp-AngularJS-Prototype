namespace FEBEPrototype.Web.Models
{
    public class ProjectTypeComponent
    {
        public int ProjectTypeId { get; set; }
        public int ComponentId { get; set; }

        public ProjectType ProjectType { get; set; }
        public Component Component { get; set; }

    }
}
