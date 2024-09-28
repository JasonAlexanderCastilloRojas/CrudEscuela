using CrudEscuela.Application.DTO;
using CrudEscuela.Domain.Entities;

namespace CrudEscuela.Application.Interface.Persistence
{
    public interface IStudentRepository
    {
        List<StudentDTO> GetAllStudents();
        StudentDTO GetStudentById(int id);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
