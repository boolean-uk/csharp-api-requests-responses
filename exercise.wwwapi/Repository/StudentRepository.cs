using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentCollection _studentCollection;

        public StudentRepository(StudentCollection studentCollection) 
        {
            _studentCollection = studentCollection;
        }

        public IEnumerable<Student> Get()
        {
            return _studentCollection.Get();
        }

        public Student Get(string firstName)
        {
            return _studentCollection.Get(firstName);
        }

        public Student Add(Student student)
        {
            return _studentCollection.Add(student);
        }

        public Student Update(string firstName, Student student)
        {
            return _studentCollection.Change(firstName, student);
        }

        public Student Remove(string firstName)
        {
            return _studentCollection.Remove(firstName);
        }
    }
}
