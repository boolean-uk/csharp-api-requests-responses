using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection
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

        public static Student Get(string firstName)
        {
            return _students.FirstOrDefault(x => x.FirstName == firstName);
        }

        public static Student Update(string firstName, Student student)
        {
            Student StudentToUpdate = Get(firstName);
            StudentToUpdate = student;
            return StudentToUpdate;
        }

        public static Student Delete(string firstName)
        {
            Student studentToDelete = Get(firstName);
            _students.Remove(studentToDelete);
            return studentToDelete;
        }
    };
}
