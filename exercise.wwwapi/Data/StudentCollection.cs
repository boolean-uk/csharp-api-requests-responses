using exercise.wwwapi.Models.Student;

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
            Student newStudent = new Student();
            newStudent.FirstName = student.FirstName;
            newStudent.LastName = student.LastName;

            _students.Add(student);

            return student;
        }

        public List<Student> getAll()
        {
            return _students.ToList();
        }

        public Student GetAStudent(string firstName)
        {
            var student = _students.FirstOrDefault(s => s.FirstName == firstName);
            if (student == default) return null;
            return student;
        }

        public Student UpdateStudent(string firstName, StudentPayload updatePayload)
        {
            var student = GetAStudent(firstName);
            if (student == null) return null;

            bool isUpdated = false;
            if (!string.IsNullOrWhiteSpace(updatePayload.FirstName))
            {
                student.FirstName = updatePayload.FirstName;
                isUpdated = true;
            }
            if (!string.IsNullOrWhiteSpace(updatePayload.LastName))
            {
                student.LastName = updatePayload.LastName;
                isUpdated = true;
            }
            if (!isUpdated) { return null; }

            return student;

        }

        public Student DeleteStudent(string firstName)
        {
            var student = _students.FirstOrDefault(s => s.FirstName.Equals(firstName));

            if (!_students.Remove(student))
            {
                return null;
            }
            else
            {
                _students.Remove(student);
                return student;
            }
        }
    };


}
