using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student Add(string firstName, string lastName)
        {
            _students.Add(new Student() { FirstName = firstName, LastName = lastName });
            return _students.Last();
        }

        public List<Student> GetAll()
        {
            return _students.ToList();
        }

        public Student? Get(int id)
        {
            return _students[id];
        }

        public void Delete(int id)
        {
            _students.RemoveAt(id);
        }
    };


}
