namespace CrudEscuela.Domain.Entities
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int StudentSubjectId { get; set; }
        public decimal GradeValue { get; set; }

        //Relation
        public StudentSubject StudentSubject { get; set; }
    }
}
