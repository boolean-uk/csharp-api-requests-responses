using exercise.wwwapi.Endpoints;
using exercise.wwwapi.Models;
using exercise.wwwapi.Repository;

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

        public static Student DeleteStudent(string firstName)
        {
            var studToRemove = GetStudent(firstName);
            _students.Remove(studToRemove);
            return studToRemove;
        }

        public static List<Student> GetStudents()
        {
            return _students.ToList();
        }

        public static Student GetStudent(string firstName)
        {
            return _students.Find(x => x.FirstName.Equals(firstName, StringComparison.CurrentCultureIgnoreCase));
        }
        public static Student UpdateStudent(Student student, string firstName)
        {
            var studentToUpdate = _students.First(x => x.FirstName.Equals(firstName, StringComparison.CurrentCultureIgnoreCase));

            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = student.LastName;
            return studentToUpdate;
        }
    };


}
