using CrudEscuela.Application.DTO;
using CrudEscuela.Domain.Entities;

namespace CrudEscuela.Application.Interface.Persistence
{
    public interface ISubjectRepository
    {
        List<SubjectDTO> GetAllSubjects();
        SubjectDTO GetSubjectById(int id);
        void CreateSubject(Subject subject);
        void EditSubject(Subject subject);
        void DeleteSubject(int id);
    }
}
