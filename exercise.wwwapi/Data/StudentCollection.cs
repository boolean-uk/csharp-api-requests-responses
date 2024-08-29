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

        public static List<Student> getAll()
        {
            return _students.ToList();
        }

        public static Student Get(string firstname)
        {
            return _students.Find(s => s.FirstName.ToLower() == firstname.ToLower());
        }

        public static Student Update(string firstname, Student updated)
        {
            Student s = _students.Find(s => s.FirstName.ToLower() != firstname.ToLower());
            s.FirstName = updated.FirstName;
            s.LastName = updated.LastName;
            return s;
        }

        public static Student Delete(string firstname)
        {
            Student s = _students.Find(s => s.FirstName.ToLower() == firstname.ToLower());
            _students.Remove(s);
            return s;
        }
    };
}
