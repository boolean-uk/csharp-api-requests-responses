using api_counter.Models;
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
            if(students.Count == 0)
            {
                Student student = new Student();
                student.firstName = "thanasis";
                student.lastName = "andritsios";

                Student student2 = new Student();
                student2.firstName = "test";
                student2.lastName = "lol";

                students.Add(student);
                students.Add(student2);



            }





        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                
                return Results.Ok(students);

            }catch (Exception ex)
            {
                return Results.Problem(ex.Message);          
            }
        }

        [HttpGet]
        [Route("{firstname}")]

        public async Task<IResult> GetStudents(string firstname)
        {
            try
            {
                foreach (var student in students)
                {
                    if(student.firstName.ToLower() == firstname.ToLower()) { 
                    
                    
                        return Results.Ok(student);
                        
                    }
                }return Results.NotFound(firstname);


            }catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IResult> CreateStudent([Required]string firstname, [Required]string lastname)
        {
            try
            {
                Student student = new Student();
                student.firstName = firstname;
                student.lastName = lastname;
                
                students.Add(student);
                return Results.Ok(student);

            }catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IResult> DeleteStudent([Required]string firstname)
        {
            try
            {
                if(students.Any(x=>x.firstName.ToLower() == firstname.ToLower()))
                {
                    var student = students.Where(x=>x.firstName.ToLower().Equals(firstname.ToLower())).FirstOrDefault();

                students.Remove(student);
                return Results.Ok(students);
                }
                else
                {
                    return Results.NotFound(firstname);
                }


            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        [HttpPut]
        [Route("{firstname}")]

        public async Task<IResult> UpdateStudent([Required]string firstname, string newFirstName, string newLastName)
        {
            try
            {

                if (students.Any(x => x.firstName.ToLower() == firstname.ToLower()))
                {
                    var student = students.Where(x=> x.firstName.ToLower() == firstname.ToLower()).FirstOrDefault();
                    student.lastName = newLastName;
                    student.firstName = newFirstName;

                    return Results.Ok(student);








                }
                else
                {
                    return Results.NotFound($"{firstname} not found");

                }






            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }

        }
        
    }
}