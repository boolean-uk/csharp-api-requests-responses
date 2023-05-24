using api_counter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;

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
        public async Task<IResult> CreateStudent(Student student)
        {
            try
            {
                students.Add(student);
                return Results.Ok(student);

            }catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        
    }
}