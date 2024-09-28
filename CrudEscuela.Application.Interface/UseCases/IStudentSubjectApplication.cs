using CrudEscuela.Application.DTO;

namespace CrudEscuela.Application.Interface.UseCases
{
    public interface IStudentSubjectApplication
    {
        List<StudentSubjectDTO> GetStudentSubjects();
        void CreateAssignment(StudentSubjectDTO assignment);
        void UpdateAssignment(StudentSubjectDTO assignment);
        void DeleteAssignment(int id);
        StudentSubjectDTO GetAssignmentById(int id);
    }
}
