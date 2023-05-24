using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;
using System;
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
        public async Task<IResult> createStudent([Required] string firstName, [Required] string lastName)
        {
            try
            {
                Student student = new Student(firstName, lastName);
                students.Add(student);
                return Results.Created("ok", student);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("/students/{firstName}")]
        public async Task<IResult> getAStudent([Required] string firstName)
        {
            try
            {
                foreach (Student student in students)
                {
                    if (student.firstName.Equals(firstName))
                    {
                        return Results.Ok(student);
                    }
                }
                return Results.NotFound();

            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("/students")]
        public async Task<IResult> getAllStudents()
        {
            try
            {
                if (students.Count() != 0)
                {
                    return Results.Ok(students);
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
        public async Task<IResult> updateAStudent([Required] string firstName)
        {
            try
            {
                foreach (Student student in students)
                {
                    if (student.firstName.Equals(firstName))
                    {
                        student.lastName = "updated";
                        return Results.Ok(student);
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
        public async Task<IResult> DeleteAStudent([Required] string firstName)
        {
            try
            {
                foreach (Student student in students)
                {
                    if (student.firstName.Equals(firstName))
                    {
                        students.Remove(student);
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