using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class KidCommentDTO
    {
        [Key]
        public int Id { get; set; }

        public int KidId { get; set; }

        [Required(ErrorMessage = "Please enter a title fot this comment")]
        public string Title { get; set; }
        //[Required(ErrorMessage ="Please enter a comment content")]
        public string Content { get; set; }
    }
}
