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

        public static List<Student> getAll()
        {
            return _students.ToList();
        }

        public static Student getOne(string firstName)
        {
            return _students.FirstOrDefault(x => x.FirstName.Equals(firstName));
        }
        public static Student Add(Student student)
        {
            _students.Add(student);

            return student;
        }

        public static Student Update(string firstName, Student student)
        {
            Student toReplace = _students.FirstOrDefault(x => x.FirstName.Equals(firstName));
            _students[_students.IndexOf(toReplace)] = student;

            return student;
        }

        public static Student Delete(string firstName)
        {
            Student toDelete = _students.FirstOrDefault(x => x.FirstName.Equals(firstName));
            _students.Remove(toDelete);

            return toDelete;
        }


    }


}
