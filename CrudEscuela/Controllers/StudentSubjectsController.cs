using CrudEscuela.Application.DTO;
using CrudEscuela.Application.Interface.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace CrudEscuela.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSubjectsController : ControllerBase
    {
        readonly IStudentSubjectApplication _studentSubjectApplication;

        public StudentSubjectsController(IStudentSubjectApplication studentSubjectApplication)
        {
            _studentSubjectApplication = studentSubjectApplication;
        }

        [HttpGet("GetAllAssignments")]
        public IActionResult GetAllAssignments()
        {
            return Ok(_studentSubjectApplication.GetStudentSubjects());
        }

        [HttpGet("GetAssignmentById/{id}")]
        public IActionResult GetAssignmentById(int id)
        {
            var assignment = _studentSubjectApplication.GetAssignmentById(id);
            if (assignment == null)
            {
                return NotFound("Assignment not found");
            }
            return Ok(assignment);
        }

        [HttpPost("CreateAssignment")]
        public IActionResult CreateAssignment([FromBody] StudentSubjectDTO studentSubjectDTO)
        {
            if (ModelState.IsValid)
            {
                _studentSubjectApplication.CreateAssignment(studentSubjectDTO);
                return Ok("Assignment created correctly");
            }
            return BadRequest();
        }

        [HttpPut("UpdateAssignment/{id}")]
        public IActionResult UpdateAssignment(int id, [FromBody] StudentSubjectDTO studentSubjectDTO)
        {
            if (ModelState.IsValid)
            {
                var existingAssignment = _studentSubjectApplication.GetAssignmentById(id);
                if (existingAssignment == null)
                {
                    return NotFound("Assignment not found");
                }

                _studentSubjectApplication.UpdateAssignment(studentSubjectDTO);
                return Ok("Assignment updated correctly");
            }

            return BadRequest();
        }

        [HttpDelete("DeleteAssignment/{id}")]
        public IActionResult DeleteAssignment(int id)
        {
            var existingAssignment = _studentSubjectApplication.GetAssignmentById(id);
            if (existingAssignment == null)
            {
                return NotFound("Assignment not found");
            }

            _studentSubjectApplication.DeleteAssignment(id);
            return Ok("Assignment deleted correctly");
        }
    }
}
