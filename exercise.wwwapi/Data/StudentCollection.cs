using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public static Student Add(Student student)
        {
            if (_students.Find(x => x.FirstName == student.FirstName) == null)
            {
                _students.Add(new Student() { FirstName = student.FirstName, LastName = student.LastName });
                return student;
            }
            return null;
        }

        public static List<Student> GetAll()
        {
            return _students.ToList();
        }

        internal static Student Delete(string FirstName)
        {
            Student student = null;
            _students.Remove(student = _students.FirstOrDefault(x => x.FirstName == FirstName));
            return student;
        }

        internal static Student GetStudent(string FirstName)
        {
            return _students.FirstOrDefault(x => x.FirstName == FirstName);
        }

        internal static Student UpdateStudent(string FirstName, Student student)
        {
            Student studentOld = _students.FirstOrDefault(x => x.FirstName == FirstName);
            if (studentOld != null)
            {
                studentOld.FirstName = student.FirstName;
                studentOld.LastName = student.LastName;
            }
            return studentOld;
        }
    };


}
