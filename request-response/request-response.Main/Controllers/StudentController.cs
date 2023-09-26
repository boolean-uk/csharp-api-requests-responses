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
                _students.Add(new Student() { firstName = "Nathan", lastName = "King" } );
            //_students.Add(_students.Last());
             }

         }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("addStudent")]
        public async Task<IResult> AddStudent(Student student)
        {
            _students.Add(student);
            return Results.Created($"https://localhost:7241/Student/addStudent", student);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("getStudents")]
        public async Task<IResult> GetStudents()
        {
            return Results.Ok(_students);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{firstName}")]
        public async Task<IResult> GetAStudent(string firstName)
        {
            var student = _students.Where(s => s.firstName == firstName).FirstOrDefault();
            return student != null ? Results.Ok(_students) : Results.NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IResult> UpdateStudent(string firstName, Student student)
        {
            var item = _students.Where(x => x.firstName == firstName).FirstOrDefault();
            item.firstName = student.firstName != string.Empty ? student.firstName : item.firstName;
            item.lastName = student.lastName;
            return Results.Ok(item);
        }

    }
}