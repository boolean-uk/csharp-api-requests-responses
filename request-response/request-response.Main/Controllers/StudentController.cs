using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using request_response.Models;

namespace request_response.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        public static List<Student> _students = new List<Student>();
        public StudentsController()
        {

        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Student info is not provided");
                }
                _students.Add(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPost]
        //public IActionResult CreateStudentBase(Student students)
        //{
        //    try
        //    {
        //        if (student == null)
        //        {
        //            return BadRequest("Student info is not provided");
        //        }
        //        _students.Add(student);
        //        return Ok(student);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpGet]
        public IActionResult GetAll() 
        {
        try
            {
                return Ok(_students);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/{firstName}")]
        public IActionResult Get(string firstName)    
        {
            try
            {
                var student = _students.Where(x => x.FirstName == firstName).FirstOrDefault();
                return student != null ? Ok(student) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        
    }
}