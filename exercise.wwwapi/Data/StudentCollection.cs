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

        public static Student AddStudent(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public static List<Student> GetAll()
        {
            return _students;
        }

        public static Student GetStudent(string firstname)
        {
            var match = _students.FirstOrDefault(x => x.FirstName.ToLower() == firstname.ToLower());
            return match;
        }

        public static Student UpdateStudent(string firstname, string newfirstname, string newlastname)
        {
            var match = _students.FirstOrDefault(x => x.FirstName.ToLower() == firstname.ToLower());
            match.FirstName = newfirstname;
            match.LastName = newlastname;
            return match;
        }

        public static Student DeleteStudent(string firstname)
        {
            var match = _students.FirstOrDefault(x => x.FirstName.ToLower() == firstname.ToLower());
            _students.Remove(match);
            return match;
        }
    };
}
