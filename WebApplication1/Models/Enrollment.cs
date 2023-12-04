using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication3.Models
{
    public class Enrollment
    {
        [Key]
        public int idEnrollment { get; set; }

        public DateTime date { get; set; }

        public int idStudent { get; set; }

        public virtual Student Student { get; set; }

        public int IdCourse { get; set; }

        public virtual Course Course { get; set; }
    }
}
