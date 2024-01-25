using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Endpoints
{
    [ApiController]
    [Route("student")]
    public class StudentEndpoints : ControllerBase
    {
        private readonly IRepository _repository;

        public StudentEndpoints(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult CreateStudent([FromBody] StudentPost studentPost)
        {
            if (studentPost == null || string.IsNullOrEmpty(studentPost.FirstName) || string.IsNullOrEmpty(studentPost.LastName))
            {
                return BadRequest("Invalid student data");
            }

            var newStudent = new Student { FirstName = studentPost.FirstName, LastName = studentPost.LastName };
            var createdStudent = _repository.AddStudent(newStudent);
            return Created($"/student/{createdStudent.Id}", createdStudent);
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetStudents()
        {
            var students = _repository.GetStudents();
            return Ok(students);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddStudent([FromBody] StudentPost studentPost)
        {
            if (studentPost == null || string.IsNullOrEmpty(studentPost.FirstName) || string.IsNullOrEmpty(studentPost.LastName))
            {
                return BadRequest("Invalid student data");
            }

            var newStudent = new Student { FirstName = studentPost.FirstName, LastName = studentPost.LastName };
            var createdStudent = _repository.AddStudent(newStudent);
            return Created($"/student/{createdStudent.Id}", createdStudent);
        }

        [HttpPut]
        [Route("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateStudent(int id, [FromBody] StudentPut studentPut)
        {
            var updatedStudent = _repository.UpdateStudent(id, studentPut);
            if (updatedStudent == null)
            {
                return NotFound($"Student with ID {id} not found");
            }
            return Ok(updatedStudent);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteStudent(int id)
        {
            var studentDeleted = _repository.DeleteStudent(id);
            if (studentDeleted)
            {
                return NoContent();
            }
            return NotFound($"Student with ID {id} not found");
        }
    }
}
