using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public class StudentCollection : IData<Student>
    {
        private List<Student> _students = new List<Student>()
        {
            new Student() { FirstName="Nathan",LastName="King" },
            new Student() { FirstName="Dave", LastName="Ames" }
        };

        public Student Add(Student student)
        {
            _students.Add(student);

            return student;
        }

        public List<Student> GetAll()
        {
            return _students.ToList();
        }

        public Student GetSpecific(string firstName)
        {
            return _students.Where(x => x.FirstName == firstName).FirstOrDefault();
        }

        public Student Update(string firstName, Student newInfo)
        {

            Student dbStudent = _students.Where(x => x.FirstName == firstName).FirstOrDefault();
            if (dbStudent == null) { return null; }
            dbStudent.FirstName = newInfo.FirstName;
            dbStudent.LastName = newInfo.LastName;
            return dbStudent;
        }

        public Student Delete(string firstName)
        {
            Student dbStudent = _students.Where(x => x.FirstName == firstName).FirstOrDefault();
            if (dbStudent == null) { return null; }
            _students.Remove(dbStudent);
            return dbStudent;
        }
    };


}
