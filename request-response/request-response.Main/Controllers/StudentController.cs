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

        // create a student
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> CreateAStudent(Student student)
        {
            _students.Add(student);
            return Results.Created($"http://localhost:5186/Student/{student.FirstName}", student);
        }


        // get all students
        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetStudents()
        {
            return Results.Ok(_students);
        }

        // get a student
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{firstName}")]
        public async Task<IResult> GetAStudent(string firstName)
        {
            var student = _students.FirstOrDefault(s => s.FirstName == firstName);
            return student != null ? Results.Ok(student) : Results.NotFound();
        }

        // update a student
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{firstName}")]
        public async Task<IResult> UpdateAStudent(string firstName, Student newStudent)
        {
            var student = _students.FirstOrDefault(s => s.FirstName == firstName);
            if (student == null) return Results.NotFound();

            if (!string.IsNullOrEmpty(newStudent.FirstName))
                student.FirstName = newStudent.FirstName;
            if (!string.IsNullOrEmpty(newStudent.LastName))
                student.LastName = newStudent.LastName;

            return Results.Created($"http://localhost:5186/Student/{student.FirstName}", student);
        }
    }
}