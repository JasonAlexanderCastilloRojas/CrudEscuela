using CrudEscuela.Application.DTO;
using CrudEscuela.Application.Interface.Persistence;
using CrudEscuela.Domain.Entities;
using CrudEscuela.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudEscuela.Infraestructure.Repositories
{
    public class StudentSubjectRepository : IStudentSubjectRepository
    {
        readonly ApplicationDbContext _context;
        public StudentSubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateAssignment(StudentSubjectDTO assignment)
        {
            var studentSubject = new StudentSubject
            {
                StudentId = assignment.StudentId,
                SubjectId = assignment.SubjectId
            };
            _context.StudentSubjects.Add(studentSubject);
            _context.SaveChanges();
        }

        public void DeleteAssignment(int id)
        {
            var assignment = _context.StudentSubjects.FirstOrDefault(a => a.StudentSubjectId == id);
            if (assignment != null)
            {
                _context.StudentSubjects.Remove(assignment);
                _context.SaveChanges();
            }
        }

        public List<StudentSubjectDTO> GetAssignments()
        {
            return _context.StudentSubjects.Select(a => new StudentSubjectDTO
            {
                StudentSubjectId = a.StudentSubjectId,
                StudentId = a.StudentId,
                SubjectId = a.SubjectId
            }).ToList();
        }

        public StudentSubjectDTO GetStudentSubjectById(int id)
        {
            var studentSubject = _context.StudentSubjects.Where(w => w.StudentSubjectId == id).FirstOrDefault();
            return StudentSubjectData(studentSubject);
        }

        public void UpdateAssignment(StudentSubjectDTO assignment)
        {
            var existingAssignment = _context.StudentSubjects.FirstOrDefault(a => a.StudentSubjectId == assignment.StudentSubjectId);
            if (existingAssignment != null)
            {
                existingAssignment.StudentId = assignment.StudentId;
                existingAssignment.SubjectId = assignment.SubjectId;
                _context.SaveChanges();
            }
        }

        private StudentSubjectDTO StudentSubjectData(StudentSubject student)
        {
            return new StudentSubjectDTO
            {
                StudentSubjectId = student.StudentSubjectId,
                StudentId = student.StudentId,
                SubjectId= student.SubjectId
            };
        }
    }
}
