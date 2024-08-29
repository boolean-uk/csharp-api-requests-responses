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
            int index = _students.FindIndex(x => x.FirstName == firstName);

            if (index == -1)
                return null;

            _students[index] = student;

            return student;
        }
        
        public Student Delete(string firstName)
        {
            Student deletedStudent = _students.Find(x => x.FirstName == firstName);
            _students.Remove(deletedStudent);

            return deletedStudent;
        }

    };


}
