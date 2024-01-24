using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
    {
        private List<Student> _students = new List<Student>()
        {
            new Student("Nathan", "King"),
            new Student("Dave", "Ames")
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

        public Student getAStudent(string firstName)
        {
            Student student = _students.Where(Student => Student.FirstName == firstName).FirstOrDefault();
            if (student == null)
            {
                return null;
            }
            return student;
        }

        public Student updateStudent(string firstName, string newfirstname, string LastName)
        {
            Student student = _students.Where(Student => Student.FirstName == firstName).FirstOrDefault();
            if (student == null)
            {
                return null;
            }
            student.FirstName = newfirstname;
            student.LastName = LastName;
            return student;
        }

        public Student deleteAStudent(string firstName)
        {
            Student student = _students.Where(Student => Student.FirstName == firstName).FirstOrDefault();
            if (student == null)
            {
                return null;
            }
            _students.Remove(student);
            return student;
        }
    };


}
