using CrudEscuela.Application.DTO;
using CrudEscuela.Application.Interface.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrudEscuela.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        readonly IStudentApplication _studentApplication;
        public StudentsController(IStudentApplication studentApplication)
        {
            _studentApplication = studentApplication;
        }

        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents() 
        {
            return Ok(_studentApplication.GetAllStudents());
        }

        [HttpGet("GetStudentById/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentApplication.GetStudentById(id);
            if (student == null)
            {
                return NotFound("Student not found");
            }
            return Ok(student);
        }

        [HttpPost("CreateStudent")]
        public IActionResult CreateStudent(StudentDTO student) 
        {
            if(ModelState.IsValid)
            {
                _studentApplication.CreateStudent(student);
                return Ok("Student created correctly");
            }
            return BadRequest();
        }

        [HttpPut("UpdateStudent/{id}")]
        public IActionResult EditStudent(int id, [FromBody] StudentDTO studentDto)
        {
            if (ModelState.IsValid)
            {
                var existeStudent = _studentApplication.GetStudentById(id);
                if(existeStudent == null)
                {
                    return Ok("Student not found");
                }
                _studentApplication.UpdateStudent(studentDto);
                return Ok("Student updated correctly");
            }

            return BadRequest();
        }

        [HttpDelete("DeleteStudent/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _studentApplication.DeleteStudent(id);
            return Ok("Student deleted correctly");
        }
    }
}
