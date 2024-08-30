using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        public static List<Student> _students = new List<Student>()
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

        public static Student Update(Student newStudent, string firstName)
        {
            var student = _students.FirstOrDefault(x => x.FirstName == firstName);
            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;
            return student;
        }

        public static Student Delete(string firstName)
        {
            Student student = Get(firstName);
            _students.Remove(student);
            return student;
        }
    };


}
