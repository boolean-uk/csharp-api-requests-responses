using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;

namespace request_response.Controllers
{
    [ApiController]
    [Route("students")]
    public class StudentController : ControllerBase
    {
        public static List<Student> Students { get; set; } = new List<Student>();
        public StudentController()
        {
        }

        [HttpPost]
        public async Task<IResult> CreateStudent(Student student)
        {
            try
            {
                if (student != null)
                {
                    Students.Add(student);
                    return Results.Created("https://localhost:7241/Students", student);
                }
                else
                {
                    return Results.Problem("Student was empty");
                }


            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IResult> GetStudents()
        {
            try
            {
                if (Students.Count != 0)
                {
                    return Results.Ok(Students);
                }
                else
                {
                    return Results.Problem("There are no students yet");
                }
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{firstName}")]
        public async Task<IResult> GetStudent(string firstName)
        {
            try
            {
                var stud = Students.FirstOrDefault(x => x.FirstName == firstName);
                if (stud != null)
                {
                    return Results.Ok(stud);
                }
                else
                {
                    return Results.Problem($"There is no student named {firstName}");
                }         
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{firstName}")]
        public async Task<IResult> DeleteStudent(string firstName)
        {
            try
            {
                var stud = Students.FirstOrDefault(x => x.FirstName == firstName);
                if ( stud != null )
                {
                    Students.Remove(stud);
                    return Results.Ok(stud);
                } 
                else
                {
                    return Results.Problem($"There is no student named {firstName}");
                }
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("{firstName}")]
        public async Task<IResult> UpdateStudent (Student student, string firstName)
        {
            try
            {
                var stud = Students.FirstOrDefault(x => x.FirstName == firstName);
                if (stud != null)
                {
                    stud.LastName = student.LastName;
                    return Results.Ok(stud);
                }
                else
                {
                    return Results.Problem($"There is no student named {firstName}");
                }
            } catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}