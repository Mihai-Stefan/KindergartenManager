using DataAccess.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Data
{
    public class KidParent
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the child's parent full name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ParentType { get; set; }
        public bool IsLegalTutor { get; set; }
        public string ParentJob { get; set; }
        public string ParentWorkplace { get; set; }
        [ForeignKey("KidId")]
        public virtual Kid Kid{ get; set; }


        public string IconStyle { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
