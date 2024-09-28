namespace CrudEscuela.Domain.Entities
{
    public class StudentSubject
    {
        public int StudentSubjectId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        //Relations
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
