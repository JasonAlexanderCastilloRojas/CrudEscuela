using CrudEscuela.Application.DTO;
using CrudEscuela.Application.Interface.Persistence;
using CrudEscuela.Application.Interface.UseCases;

namespace CrudEscuela.Application.UseCases
{
    public class StudentSubjectApplication : IStudentSubjectApplication
    {
        readonly IStudentSubjectRepository _studentSubjectRepository;
        public StudentSubjectApplication(IStudentSubjectRepository studentSubjectRepository)
        {
            _studentSubjectRepository = studentSubjectRepository;
        }
        public void CreateAssignment(StudentSubjectDTO assignment)
        {
            _studentSubjectRepository.CreateAssignment(assignment);
        }

        public void DeleteAssignment(int id)
        {
            _studentSubjectRepository.DeleteAssignment(id);
        }

        public StudentSubjectDTO GetAssignmentById(int id)
        {
            return _studentSubjectRepository.GetStudentSubjectById(id);
        }

        public List<StudentSubjectDTO> GetStudentSubjects()
        {
            return _studentSubjectRepository.GetAssignments();
        }

        public void UpdateAssignment(StudentSubjectDTO assignment)
        {
            _studentSubjectRepository.UpdateAssignment(assignment);
        }
    }
}
