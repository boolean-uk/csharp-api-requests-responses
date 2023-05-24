using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;
using System;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();

        public StudentController()
        {
            //Student student1 = new Student();
            //student1.FirstName = "Nathan";
            //student1.LastName = "King";
            //_students.Add(student1);

            //Student student2 = new Student();
            //student2.FirstName = "Nigel";
            //student2.LastName = "Sibbert";
            //_students.Add(student2);
        }

        [HttpPost]
        [Route("")]
        public async Task<IResult> AddStudent(Student student)
        {
            try
            {
                if (student == null) return Results.Problem();
                _students.Add(student);
                return Results.Ok(student);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpGet]
        [Route("")]
        public async Task<IResult> SeeAllStudents()
        {
            try
            {
                return Results.Ok(_students);
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{firstname}")]
        public async Task<IResult> SeeAStudents(string firstname )
        {
            try
            {
                var student = _students.Where(x => x.FirstName == firstname).FirstOrDefault();
                return Results.Ok(student);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{firstname}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> ChangeAStudent(string firstname, string? newFirstName, string? newLastName)
        {
            try
            {
                if (_students.Any(x => x.FirstName == firstname))
                {
                    var s = _students.SingleOrDefault(x => x.FirstName == firstname); // this pulls out the student you want to change
                    if (s != null)
                    {
                        if (!string.IsNullOrEmpty(newFirstName))
                        {
                            s.FirstName = newFirstName;
                        }
                        if (!string.IsNullOrEmpty(newLastName))
                        {
                            s.LastName = newLastName;
                        }
                        return Results.Created($"https://localhost:7241/Student/{s.FirstName}", s);
                    }
                }
                    return Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
            

            //Update a student's details using the firstName provided.
            //Just update the first student found in the list with the provided first name.

        }
    }
}