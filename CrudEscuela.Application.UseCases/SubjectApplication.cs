using CrudEscuela.Application.DTO;
using CrudEscuela.Application.Interface.Persistence;
using CrudEscuela.Application.Interface.UseCases;
using CrudEscuela.Domain.Entities;

namespace CrudEscuela.Application.UseCases
{
    public class SubjectApplication : ISubjectApplication
    {
        readonly ISubjectRepository _subjectRepository;
        public SubjectApplication(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public List<SubjectDTO> GetAllSubjects()
        {
            return _subjectRepository.GetAllSubjects();
        }

        public SubjectDTO GetSubjectById(int id)
        {
            return _subjectRepository.GetSubjectById(id);
        }

        public void CreateSubject(SubjectDTO subjectDto)
        {
            var subject = new Subject
            {
                SubjectId = subjectDto.SubjectId,
                DescriptionSubject = subjectDto.DescriptionSubject
            };

            _subjectRepository.CreateSubject(subject);
        }

        public void EditSubject(SubjectDTO subjectDto)
        {
            var subject = new Subject
            {
                SubjectId = subjectDto.SubjectId,
                DescriptionSubject = subjectDto.DescriptionSubject
            };
            _subjectRepository.EditSubject(subject);
        }
        
        public void DeleteSubject(int id)
        {
            _subjectRepository.DeleteSubject(id);
        }
    }
}
