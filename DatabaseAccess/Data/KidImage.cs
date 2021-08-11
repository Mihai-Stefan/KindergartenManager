using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Data
{
    public class KidImage
    {
        public int Id { get; set; }
        public int KidId { get; set; }
        public string KidImageUrl { get; set; }
        [ForeignKey("KidId")]
        public virtual Kid Kid { get; set; }
    }
}
