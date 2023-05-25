using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;
using System;

namespace request_response
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();
        public StudentController()
        {
        }

        [HttpPost]
        [Route("")]
        public async Task<IResult> PostStudent(Student student)
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
        public async Task<IResult> GetStudents()
        {
            try
            {
                return Results.Ok(_students);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{firstname}")]
        public async Task<IResult> GetStudent(string firstname)
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
        public async Task<IResult> ChangeStudent(string firstname, string? newFirstName, string? newLastName)
        {
            try
            {
                if (_students.Any(x => x.FirstName == firstname))
                {
                    var changeStudent = _students.SingleOrDefault(x => x.FirstName == firstname);
                    if (changeStudent != null)
                    {
                        if (!string.IsNullOrEmpty(newFirstName))
                        {
                            changeStudent.FirstName = newFirstName;
                        }
                        if (!string.IsNullOrEmpty(newLastName))
                        {
                            changeStudent.LastName = newLastName;
                        }
                        return Results.Ok(changeStudent);
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
        [Route("{firstname}")]
        public async Task<IResult> DeleteStudent(string firstname)
        {
            try
            {
                if (_students.Any(x => x.FirstName == firstname))
                {
                    var deleteStudent = _students.SingleOrDefault(x => x.FirstName == firstname);
                    _students.Remove(deleteStudent);
                    return Results.Ok(deleteStudent);
                }
                else
                {
                    return Results.NotFound();
                }
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}