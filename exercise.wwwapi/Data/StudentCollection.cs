using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student(){ FirstName="Nathan", LastName="King" },
            new Student(){ FirstName="Nathan", LastName="King" }
        };

        public static Student Add(Student student)
        {            
            _students.Add(student);

            return student;
        }

        public static Student Get(string firstName)
        {
            return _students.FirstOrDefault(x => x.FirstName.Equals(firstName));
        }

        public static List<Student> GetAll()
        {
            return _students.ToList();
        }

        public static Student Delete(string firstName)
        {
            var student = _students.FirstOrDefault(x => x.FirstName.Equals(firstName));
            if (student == null) return null;
            _students.Remove(student);
            return student;
        }

        public static Student Update(string firstName, Student entity)
        {
            var student = _students.FirstOrDefault(x => x.FirstName.Equals(firstName));
            if (student == null) return null;
            student.FirstName = entity.FirstName;
            student.LastName = entity.LastName;
            return student;
        }
    };


}
