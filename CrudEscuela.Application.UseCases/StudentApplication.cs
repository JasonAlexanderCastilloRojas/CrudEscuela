using CrudEscuela.Application.DTO;
using CrudEscuela.Application.Interface.Persistence;
using CrudEscuela.Application.Interface.UseCases;
using CrudEscuela.Domain.Entities;

namespace CrudEscuela.Application.UseCases
{
    public class StudentApplication : IStudentApplication
    {
        readonly IStudentRepository _studentRepository;
        public StudentApplication(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void CreateStudent(StudentDTO studentDto)
        {
            var student = new Student
            {
                StudentId = studentDto.StudentId,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                Phone = studentDto.Phone,
                Email = studentDto.Email
            };

            _studentRepository.CreateStudent(student);
        }

        public List<StudentDTO> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }
        public StudentDTO GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public void UpdateStudent(StudentDTO studentDTO)
        {
            var student = new Student
            {
                StudentId = studentDTO.StudentId,
                FirstName = studentDTO.FirstName,
                LastName = studentDTO.LastName,
                Phone = studentDTO.Phone,
                Email = studentDTO.Email
            };

            _studentRepository.UpdateStudent(student);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.DeleteStudent(id);
        }
    }
}
