using System.ComponentModel.DataAnnotations;

namespace CrudEscuela.Domain.Entities
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
        public List<StudentSubject> StudentSubjects { get; set; }
    }
}
