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

        public static Student Get(string firstName)
        {
            return _students.FirstOrDefault(s => s.FirstName == firstName);
        }

        public static bool Remove(string firstName)
        {
            return _students.RemoveAll(s => s.FirstName == firstName) > 0 ? true : false;
        }

        public static Student Update(string firstName, Student entity)
        {
            Student student = Get(firstName);
            student.FirstName = entity.FirstName;
            student.LastName = entity.LastName;
            return student;
        }

        public static List<Student> Students { get { return _students; } }
    };


}
