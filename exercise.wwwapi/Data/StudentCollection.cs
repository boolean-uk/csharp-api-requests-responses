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

        public Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public List<Student> getAll()
        {
            return _students.ToList();
        }

        public Student Get(string firstName)
        {
            return _students.Find(x => x.FirstName == firstName);
        }

        public Student Update(string firstName, Student student)
        {
            var updatedStudent = _students.Find(x => x.FirstName == firstName);
            updatedStudent = student;

            return updatedStudent;
        }
        
        public Student Delete(string firstName)
        {
            Student deletedStudent = _students.Find(x => x.FirstName == firstName);
            _students.Remove(deletedStudent);

            return deletedStudent;
        }

    };


}
