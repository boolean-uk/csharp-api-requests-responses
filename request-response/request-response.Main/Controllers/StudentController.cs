using Microsoft.AspNetCore.Mvc;
using request_response.Models;

namespace request_response.Controllers
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-5
    /// Used DTO object to define data
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();

        static StudentController() // used 30 popular names around the world for this
        {
            if (_students.Count == 0)
            {
                _students.Add(new Student() { FirstName = "Liam", LastName = "Smith" });
                _students.Add(new Student() { FirstName = "Olivia", LastName = "Johnson" });
                _students.Add(new Student() { FirstName = "Arjun", LastName = "Patel" });
                _students.Add(new Student() { FirstName = "Fatima", LastName = "Khan" });
                _students.Add(new Student() { FirstName = "Santiago", LastName = "García" });
                _students.Add(new Student() { FirstName = "Sofía", LastName = "Rodriguez" });
                _students.Add(new Student() { FirstName = "Muhammad", LastName = "Ali" });
                _students.Add(new Student() { FirstName = "Aisha", LastName = "Hussain" });
                _students.Add(new Student() { FirstName = "Lucas", LastName = "Silva" });
                _students.Add(new Student() { FirstName = "Maria", LastName = "Fernandez" });
                _students.Add(new Student() { FirstName = "Noah", LastName = "Taylor" });
                _students.Add(new Student() { FirstName = "Emma", LastName = "Martin" });
                _students.Add(new Student() { FirstName = "Jia", LastName = "Wang" });
                _students.Add(new Student() { FirstName = "Ming", LastName = "Li" });
                _students.Add(new Student() { FirstName = "Ethan", LastName = "Brown" });
                _students.Add(new Student() { FirstName = "Sophia", LastName = "Davis" });
                _students.Add(new Student() { FirstName = "Mateo", LastName = "Lopez" });
                _students.Add(new Student() { FirstName = "Mia", LastName = "Gonzalez" });
                _students.Add(new Student() { FirstName = "Yusuf", LastName = "Öztürk" });
                _students.Add(new Student() { FirstName = "Elif", LastName = "Y?lmaz" });
                _students.Add(new Student() { FirstName = "Leo", LastName = "Clark" });
                _students.Add(new Student() { FirstName = "Isabella", LastName = "Jones" });
                _students.Add(new Student() { FirstName = "Harper", LastName = "Miller" });
                _students.Add(new Student() { FirstName = "Benjamin", LastName = "White" });
                _students.Add(new Student() { FirstName = "Ava", LastName = "Williams" });
                _students.Add(new Student() { FirstName = "Elijah", LastName = "Anderson" });
                _students.Add(new Student() { FirstName = "Amelia", LastName = "Hall" });
                _students.Add(new Student() { FirstName = "Logan", LastName = "Turner" });
                _students.Add(new Student() { FirstName = "Riley", LastName = "Evans" });
                _students.Add(new Student() { FirstName = "Mason", LastName = "King" });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> CreateStudent([FromBody] CreateStudent studentDto)
        {
            return await Task.Run(() =>
            {
                var student = new Student { FirstName = studentDto.FirstName, LastName = studentDto.LastName };
                _students.Add(student);
                return Results.Created($"/students/{studentDto.FirstName}", student);
            });
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetAllStudents()
        {
            return await Task.Run(() => Results.Ok(_students));
        }

        [HttpGet("{firstName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> GetStudent(string firstName)
        {
            return await Task.Run(() =>
            {
                var student = _students.FirstOrDefault(s => s.FirstName == firstName);
                if (student == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(student);
            });
        }

        [HttpPut("{firstName}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IResult> UpdateStudent(string firstName, [FromBody] CreateStudent studentDto)
        {
            return await Task.Run(() =>
            {
                var student = _students.FirstOrDefault(s => s.FirstName == firstName);
                if (student == null)
                {
                    return Results.NotFound();
                }
                student.FirstName = studentDto.FirstName;
                student.LastName = studentDto.LastName;
                return Results.Created($"/students/{studentDto.FirstName}", student);
            });
        }

        [HttpDelete("{firstName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IResult> DeleteStudent(string firstName)
        {
            return await Task.Run(() =>
            {
                var student = _students.FirstOrDefault(s => s.FirstName == firstName);
                if (student == null)
                {
                    return Results.NotFound();
                }
                _students.Remove(student);
                return Results.Ok(student);
            });
        }
    }
}