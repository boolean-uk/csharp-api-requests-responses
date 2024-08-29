using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public static class StudentCollection
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student() { Id = 1, FirstName="Nathan",LastName="King" },
            new Student() { Id = 2, FirstName="Dave", LastName="Ames" }
        };

        public static Student Add(Student student)
        {
            _students.Add(new Student() { Id = _students.Max(x => x.Id) + 1, FirstName = student.FirstName, LastName = student.LastName });
            return student;
        }

        public static List<Student> GetAll()
        {
            return _students.ToList();
        }

        internal static Student Delete(int id)
        {
            Student student = null;
            _students.Remove(student = _students.FirstOrDefault(x => x.Id == id));
            return student;
        }

        internal static Student GetStudent(int id)
        {
            return _students.Find(x=>x.Id == id);
        }

        internal static Student UpdateStudent(Student student)
        {
            Student studentOld = _students.Find(x=>x.Id==student.Id);
            if (studentOld != null)
            {
                studentOld.FirstName = student.FirstName;
                studentOld.LastName = student.LastName;
            }
            return studentOld;
        }
    };


}
