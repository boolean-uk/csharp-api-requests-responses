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

        public static Student Get(string firstname)
        {
            return _students.FirstOrDefault(x => x.FirstName == firstname);
        }

        public static void Delete(string firstname)
        {
            Student student = _students.FirstOrDefault(x => x.FirstName == firstname);
            _students.Remove(student);
        }
        public static Student Update(Student newStudentValues, string firstname)
        {
            Student student = _students.FirstOrDefault(x => x.FirstName == firstname);
            student.LastName = newStudentValues.LastName;
            student.FirstName = newStudentValues.FirstName;

            return student;
        }
    };


}
