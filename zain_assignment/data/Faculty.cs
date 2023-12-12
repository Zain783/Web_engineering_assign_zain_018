using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace assignement.data
{
    public class Faculty
    {
        [Key]
        public int Fid { get; set; }
        public string Fname { get; set; }
        public int Deptid { get; set; }
        public int Standing { get; set; }
        public ICollection<Class> Classes { get; set; }
    }
}