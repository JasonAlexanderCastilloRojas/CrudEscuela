namespace CrudEscuela.Domain.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string DescriptionSubject { get; set; }

        //Relations
        public List<StudentSubject> StudentSubjects { get; set; }
    }
}
