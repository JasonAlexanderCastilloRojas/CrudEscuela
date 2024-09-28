using CrudEscuela.Application.DTO;

namespace CrudEscuela.Application.Interface.UseCases
{
    public interface ISubjectApplication
    {
        List<SubjectDTO> GetAllSubjects();
        SubjectDTO GetSubjectById(int id);
        void CreateSubject(SubjectDTO subjectDto);
        void EditSubject(SubjectDTO subjectDto);
        void DeleteSubject(int id);
    }
}
