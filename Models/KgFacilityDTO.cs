using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class KgFacilityDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter facility name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter facility description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Please enter facility icon from font awesome")]
        public string IconStyle { get; set; }

    }
}
