using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection : IData<Student>
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student Get(string firstName)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstName);    
        }

        public Student Add(Student student)
        {
            _students.Add(student);
            return student;
        }

        public Student Update(string firstName, Student student)
        {
            var targetStudent = _students.FirstOrDefault(student => student.FirstName == firstName);
            targetStudent.FirstName = student.FirstName;
            targetStudent.LastName = student.LastName;
            return targetStudent;
        }

        public Student Delete(string firstName)
        {
            var student = _students.FirstOrDefault(student => student.FirstName == firstName);
            if(student != null) {
                _students.Remove(student);
            } 
            return student;
        }

    };


}
