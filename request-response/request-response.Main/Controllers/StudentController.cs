using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();

        public StudentController()
        {
            if (_students.Count == 0)
            {
                _students.Add(new Student("Nathan", "King"));
                _students.Add(new Student("Nigel", "Sibbert"));
                _students.Add(new Student("Dave", "Ames"));
            }
        }

        // TODO: create a student


        // get all students
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetStudents()
        {
            return Results.Ok(_students);
        }
    }
}