namespace CrudEscuela.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        //Relation
        public List<Student> Students { get; set; } 
    }
}
