using CrudEscuela.Application.DTO;
using CrudEscuela.Domain.Entities;

namespace CrudEscuela.Application.Interface.Persistence
{
    public interface IStudentSubjectRepository
    {
        List<StudentSubjectDTO> GetAssignments();
        void CreateAssignment(StudentSubjectDTO assignment);
        void UpdateAssignment(StudentSubjectDTO assignment);
        void DeleteAssignment(int id);
        StudentSubjectDTO GetStudentSubjectById(int id);
    }
}
