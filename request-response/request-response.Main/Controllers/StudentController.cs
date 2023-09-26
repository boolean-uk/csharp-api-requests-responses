using Microsoft.AspNetCore.Mvc;
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
                _students.Add(new Student("Nigel", "Sibbert"));
                _students.Add(new Student("Nathan", "King"));
                _students.Add(new Student("Dave", "Ames"));
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetAllStudents()
        {
            return Results.Ok(_students);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> AddStudent(Student student)
        {
            _students.Add(student);
            return Results.Created($"http://www.boolean.com/student/{student.firstName}", student);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{firstName}")]
        public async Task<IResult> GetStudentByName(string firstName)
        {
            var student = _students.Where(s => s.firstName == firstName).FirstOrDefault();
            return student != null ? Results.Ok(student) : Results.NotFound();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{firstName}")]
        public async Task<IResult> DeleteStudent(string firstName)
        {
            var student = _students.Where(s => s.firstName == firstName).FirstOrDefault();
            int result = _students.RemoveAll(s => s.firstName == firstName);
            return result >= 0 && student != null ? Results.Ok(student) : Results.NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{firstName}")]
        public async Task<IResult> UpdateStudent(string firstName, Student student)
        {
            var item = _students.Where(s => s.firstName == firstName).FirstOrDefault();

            if (item == null) return Results.NotFound();

            item.firstName = string.IsNullOrEmpty(student.firstName) ? item.firstName : student.firstName;
            item.lastName = string.IsNullOrEmpty(student.lastName) ? item.lastName : student.lastName;

            return Results.Created($"http://www.boolean.com/student/{student.firstName}", student);
        }
    }
}