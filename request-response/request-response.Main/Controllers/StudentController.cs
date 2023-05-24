using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;
using System.ComponentModel.DataAnnotations;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>();

        public StudentController()
        {
        }
        [HttpPost]
        [Route("/students")]
        public async Task<IResult> AddStudent([Required] string firstName, [Required] string lastName)
        {
            try
            {
                Student student = new Student() { FirstName = firstName, LastName = lastName };
                students.Add(student);
                return Results.Created($"https://localhost:7241/students/{student.FirstName}", student);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IResult> GetAllStudents()
        {
            try
            {
                if (students.Count > 0)
                {
                    return Results.Ok(students);
                }
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("/students/{firstName}")]
        public async Task<IResult> GetStudentByFirstName([Required] string firstName)
        {
            try
            {
                foreach (Student i in students)
                {
                    if (i.FirstName == firstName)
                    {
                        return Results.Ok(i);
                    }
                }
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("/students/{firstName}")]
        public async Task<IResult> UpdateStudent([Required] string firstName, [Required] string updatedName)
        {
            try
            {
                foreach (Student i in students)
                {
                    if (i.FirstName == firstName)
                    {
                        i.LastName = updatedName;
                        return Results.Created($"https://localhost:7241/students/{i.FirstName}", i);
                    }
                }
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/students/{firstName}")]
        public async Task<IResult> DeleteStudent([Required] string firstName)
        {
            try
            {
                foreach (Student i in students)
                {
                    if (i.FirstName == firstName)
                    {
                        students.Remove(i);
                        return Results.Ok();
                    }
                }
                return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}