using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }
        public Student Remove(Student student)
        {
            _students.Remove(student);

            return student;
        }
        public List<Student> GetAll()
        {
            return _students.ToList();
        }

        public Student Get(string searchInput)
        {
            Student student = _students.Find(x => (x.FirstName.ToLower() + " " + x.LastName.ToLower()).Contains(searchInput.ToLower()));
            if(student == null || student == default(Student))
                student = _students.FirstOrDefault(x => x.LastName.Contains(searchInput));

            return student;
        }

        public Student Update(string studentName, string newFirstName)
        {
            Student student = Get(studentName);
            student.FirstName = newFirstName;
            return student;
        }

        public bool Delete(string studentName)
        {
            Student student = Get(studentName);
            if (student == null || student == default(Student))
                return false;

            _students.Remove(student);
            return true;
        }

    };
}
