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

        public static Student Delete(string FirstName)
        {
            Student student = _students.FirstOrDefault(x => x.FirstName == FirstName);
            if (student != null) _students.Remove(student);
            return student;
        }

        public static Student Get(string FirstName)
        {
            Student student = _students.FirstOrDefault(x => x.FirstName == FirstName);
            return student;
        }

        public static Student Update(string FirstName, Student student)
        {
            Student studentToUpdate = _students.FirstOrDefault(y => y.FirstName == FirstName);
            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            return studentToUpdate;
        }

        public static List<Student> getAll()
        {
            return _students.ToList();
        }
    };


}
