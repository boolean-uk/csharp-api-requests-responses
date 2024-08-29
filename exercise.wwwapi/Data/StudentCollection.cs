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
            _students.Add(student);

            return student;
        }

        public static List<Student> GetAll()
        {
            return _students.ToList();
        }


        public static Student GetStudent(string firstName)
        {
            var student = _students.FirstOrDefault(x => x.FirstName == firstName);
            return student;
        }

        public static Student UpdateStudent(Student newStudent, string firstName)
        {
            var student = _students.FirstOrDefault(x => x.FirstName == firstName);
            student.LastName = newStudent.LastName;
            student.FirstName = newStudent.FirstName;
            return student;
        }

        public static Student DeleteStudent(string firstName)
        {
            var student = _students.FirstOrDefault(x => x.FirstName == firstName);
            _students.Remove(student);
            return student;
        }

    };


}
