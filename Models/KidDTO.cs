using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class KidDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }
        public string Details { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<KidImageDTO> KidImages { get; set; }

        public List<string> ImageUrls { get; set; }

    }
}
