using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication3.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base (options)
        {
        }

        public DbSet<Course> Course { get; set; }

        public DbSet<Enrollment> Enrollment { get; set; }

        public DbSet<Grade> Grade { get; set; }

        public DbSet<Student> Student { get; set; }
    }
}
