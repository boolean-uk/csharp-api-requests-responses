using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;
using System.Diagnostics.Metrics;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        public static List<Student> students = new List<Student>();
        public StudentController()
        {
            if (students.Count == 0)
            {
                students.Add(new Student("Nathan", "King"));
                students.Add(new Student("Spiros", "Kafiris"));
                students.Add(new Student("George", "Papa"));
                students.Add(new Student("Chris", "Pratt"));
                students.Add(new Student("Albert", "Einstein"));
            }
        }

        //post
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> CreateStudent(Student student)
        {
            students.Add(student);
            return Results.Ok(student);
        }

        //get
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetStudents()
        {
            return Results.Ok(students);
        }

        //get{firstname}
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{firstname}")]
        public async Task<IResult> GetAStudent(string firstname)
        {
            var student = students.Where(s => s.firstName == firstname).FirstOrDefault();
            return student != null ? Results.Ok(student) : Results.NotFound();
        }

        //update
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{firstname}")]
        public async Task<IResult> Update(string firstname, Student student)
        {
            //get item to update
            var item = students.Where(s => s.firstName == firstname).FirstOrDefault();

            if (item == null) return Results.NotFound();

            item.firstName = string.IsNullOrEmpty(student.firstName) ? item.firstName : student.firstName;
            item.lastName = string.IsNullOrEmpty(student.lastName) ? item.lastName : student.lastName;

            return Results.Ok(item);
        }

        //delete
        [HttpDelete]
        [Route("{firstname}")]
        public async Task<IResult> DeleteAStudent(string firstname)
        {
            var student = students.Where(s => s.firstName == firstname).FirstOrDefault();
            int result = students.RemoveAll(s => s.firstName == firstname);
            return result >= 0 && student != null ? Results.Ok(student) : Results.NotFound();
        }


    }
}