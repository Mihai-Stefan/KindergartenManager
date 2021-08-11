using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class KidParentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the child's parent full name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ParentType { get; set; }
        public bool IsLegalTutor { get; set; }
        public string ParentJob { get; set; }
        public string ParentWorkplace { get; set; }
    }
}
