using CrudEscuela.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudEscuela.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
    }
}
