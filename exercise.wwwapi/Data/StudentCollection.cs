using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection : IDatabase<Student>
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public IEnumerable<Student> Data { get { return _students; } set { _students = (List<Student>)value; } }
    };
}
