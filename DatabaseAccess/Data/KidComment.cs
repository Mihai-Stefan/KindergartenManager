using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseAccess.Data
{
    public class KidComment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("KidId")]
        public int KidId { get; set; }

        [Required]
        public string Title { get; set; }
        //[Required]
        public string Content { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
