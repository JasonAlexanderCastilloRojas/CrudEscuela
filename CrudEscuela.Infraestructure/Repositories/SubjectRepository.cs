using CrudEscuela.Application.DTO;
using CrudEscuela.Application.Interface.Persistence;
using CrudEscuela.Domain.Entities;
using CrudEscuela.Infraestructure.Data;

namespace CrudEscuela.Infraestructure.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        readonly ApplicationDbContext _context;
        public SubjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SubjectDTO> GetAllSubjects()
        {
            return _context.Subjects.Select(s=> new SubjectDTO
            {
                SubjectId = s.SubjectId,
                DescriptionSubject = s.DescriptionSubject,
            }).ToList();
        }

        public SubjectDTO GetSubjectById(int id)
        {
            var subject = _context.Subjects.Where(w => w.SubjectId == id).FirstOrDefault();
            return DataSubject(subject);
        }


        public void CreateSubject(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public void EditSubject(Subject subject)
        {
            var existeSubject = _context.Subjects.Where(w => w.SubjectId == subject.SubjectId)
                .UpdateFromQuery(u => new Subject
                {
                    SubjectId = subject.SubjectId,
                    DescriptionSubject = subject.DescriptionSubject
                });
        }

        public void DeleteSubject(int id)
        {
            var subject = _context.Subjects.Where(w => w.SubjectId == id).FirstOrDefault();
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            }
        }

        public SubjectDTO DataSubject(Subject subject)
        {
            return new SubjectDTO
            {
                SubjectId = subject.SubjectId,
                DescriptionSubject = subject.DescriptionSubject,
            };
        }
    }
}
