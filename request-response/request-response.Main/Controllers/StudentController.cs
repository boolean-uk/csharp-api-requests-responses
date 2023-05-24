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
            if (_students.Count == 0)
            {
                Student student1 = new Student();
                student1.FirstName = "Tom";
                student1.LastName = "Sawyer";


                Student student2 = new Student();
                student2.FirstName = "Huckleberry";
                student2.LastName = "Finn";

                _students.Add(student1);
                _students.Add(student2);

            }

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

        [HttpGet("{firstName}")]

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

        [HttpPut("{firstName}")]

        public IActionResult Put(Student student)
        {
            try
            {
                if (_students.Any(x => x.FirstName == student.FirstName))
                {
                    var s = _students.SingleOrDefault(x => x.FirstName == student.FirstName);
                    if (s != null)
                    {
                        s.FirstName = student.FirstName;
                        return Ok(s);
                    }
                    return BadRequest();
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{firstName}")]

        public IActionResult Delete(string firstName)
        {
            try
            {
                if (_students.Any(x => x.FirstName == firstName))
                {
                    _students.RemoveAll(x => x.FirstName == firstName);
                    return Ok();
                }
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

