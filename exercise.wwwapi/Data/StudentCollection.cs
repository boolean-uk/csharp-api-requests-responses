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

        public static List<Student> Students { get { return _students; } }

        public static Student Create(Student student)
        {
            _students.Add(student);

            return student;
        }

        public static List<Student> getAll()
        {
            return _students.ToList();
        }
        public static Student GetStudent(string firstname)
        {
            return _students.Find(x => x.FirstName == firstname);
        }
        public static Student UpdateStudent(string firstname, Student student)
        {
            int index = _students.FindIndex(student => student.FirstName == firstname);

            _students[index] = student;

            return student;
        }
        public static Student DeleteStudent(string firstname)
        {

            var deletedstudent = _students.FirstOrDefault(x => x.FirstName == firstname);
            _students.Remove(deletedstudent);
            return deletedstudent;

        }
    }


}
