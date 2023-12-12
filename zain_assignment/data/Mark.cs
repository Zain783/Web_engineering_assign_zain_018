using System.ComponentModel.DataAnnotations;

namespace assignement.data
{
    public class Mark
    {
        [Key]
        public int MarkId { get; set; }
        public int EnrolledCid { get; set; }
        public Enrolled Enrolled { get; set; }
        // Additional mark-related properties
    }
}
