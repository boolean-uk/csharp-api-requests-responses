using Microsoft.AspNetCore.Mvc;
using exercise.wwwapi.controllers.Models;
using System.Diagnostics.Metrics;
using exercise.wwwapi.controllers.Data;

namespace exercise.wwwapi.controllers.Controllers
{
    [ApiController]
    [Route("api/student/[controller]")]
    public class StudentController : ControllerBase
    {
        List<Student> students = StudentData.GetAll();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("student/create")]
        public ActionResult CreateStudent(Student student) 
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            StudentData.Add(new Student()
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            });
            return Ok();
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("student")]
        public async Task<IResult> GetAllStudents()
        {
            return TypedResults.Ok(students);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [Route("student/{firstname}")]
        public async Task<IResult> GetAStudent(string  firstname)
        {
            var student = students.FirstOrDefault(stud => stud.FirstName == firstname);
            return TypedResults.Ok(student);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("student/delete/{firstname}")]
        public ActionResult<Student> DeleteStudent(string firstname)
        {
            try
            {
                var studentToDelete = students.FirstOrDefault(stud => stud.FirstName == firstname);

                if (studentToDelete == null)
                {
                    return NotFound($"Employee with name = {firstname} not found");
                }

                StudentData.DeleteStudent(firstname);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [Route("student/update/{firstname}")]
        public ActionResult UpdateStduent(string firstname, string newFirstName, string newLastaName)
        {
            var student = students.FirstOrDefault(stud => stud.FirstName == firstname);

            if (student != null)
            {
                student.FirstName = newFirstName;
                student.LastName = newLastaName;

                //SaveChanges();
            }
            return Ok();
        }


    }
}
