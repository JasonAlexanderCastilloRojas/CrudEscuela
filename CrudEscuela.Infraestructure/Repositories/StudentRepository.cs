using CrudEscuela.Application.DTO;
using CrudEscuela.Application.Interface.Persistence;
using CrudEscuela.Domain.Entities;
using CrudEscuela.Infraestructure.Data;

namespace CrudEscuela.Infraestructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public List<StudentDTO> GetAllStudents()
        {
            return _context.Students.Select(s => new StudentDTO
            {
                StudentId = s.StudentId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Phone = s.Phone,
                Email = s.Email,
            }).ToList();
        }

        public StudentDTO GetStudentById(int id)
        {
            var student = _context.Students.FirstOrDefault(f => f.StudentId == id);
            return UsuarioData(student); 
        }

        public void UpdateStudent(Student student)
        {
            var existStudent = _context.Students.Where(w => w.StudentId == student.StudentId)
                .UpdateFromQuery( u => new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Phone = student.Phone,
                    Email = student.Email,
                });            
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.Where(f => f.StudentId == id).FirstOrDefault();
            if(student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        private StudentDTO UsuarioData(Student student)
        {
            return new StudentDTO
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Phone = student.Phone,
                Email = student.Email
            };
        }
    }
}
