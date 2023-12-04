using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Grade
    {
        [Key]
        public int IdGrade { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public bool IsDeleted { get; set; }
    }
}
