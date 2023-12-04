using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Student
    {
        [Key]
        public int idStudent { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public int IdGrade { get; set; }

        public virtual Grade Grade { get; set; }

    }
}
