using CrudEscuela.Application.DTO;
using CrudEscuela.Application.Interface.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace CrudEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        readonly ISubjectApplication _subjectApplication;
        public SubjectsController(ISubjectApplication subjectApplication)
        {
            _subjectApplication = subjectApplication;
        }

        [HttpGet("GetAllSubjects")]
        public IActionResult GetAllSubjects() 
        {
            return Ok(_subjectApplication.GetAllSubjects());
        }

        [HttpGet("GetSubjectById/{id}")]
        public IActionResult GetSubjectById(int id) 
        {
            var subject = _subjectApplication.GetSubjectById(id);
            if (subject == null)
            {
                return NotFound("Subject not found");
            }
            return Ok(subject);
        }

        [HttpPost("CreateSubject")]
        public IActionResult CreateSubject(SubjectDTO subjectDTO)
        {
            if (ModelState.IsValid)
            {
                _subjectApplication.CreateSubject(subjectDTO);
                return Ok("Subject created correctly");
            }
            return BadRequest();
        }

        [HttpPut("UpdateSubject/{id}")]
        public IActionResult EditSubject(int id,[FromBody]SubjectDTO subjectDTO)
        {
            if (ModelState.IsValid)
            {
                var existeSubject = _subjectApplication.GetSubjectById(id);
                if (existeSubject == null)
                {
                    return Ok("Subject not found");
                }
                _subjectApplication.EditSubject(subjectDTO);
                return Ok("Subject edited correctly");
            }
            return BadRequest();
        }

        [HttpDelete("DeleteSubject/{id}")]
        public IActionResult DeleteSubject(int id)
        {
            _subjectApplication.DeleteSubject(id);
            return Ok("Subject deleted correctly");
        }
    }
}
