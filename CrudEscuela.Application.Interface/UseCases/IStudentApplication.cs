using CrudEscuela.Application.DTO;

namespace CrudEscuela.Application.Interface.UseCases
{
    public interface IStudentApplication
    {
        List<StudentDTO> GetAllStudents();
        StudentDTO GetStudentById(int id);
        void CreateStudent(StudentDTO student);
        void UpdateStudent(StudentDTO student);
        void DeleteStudent(int id);
    }
}
