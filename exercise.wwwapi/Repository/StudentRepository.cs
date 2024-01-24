using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentCollection _studentcollection;

        public StudentRepository(StudentCollection studentCollection) 
        {
        _studentcollection = studentCollection;
        
        }

        public IEnumerable<Student> Get()
        {
            return _studentcollection.Get();
        }

        public Student Add(Student student)
        {
            return _studentcollection.Add(student);
        }

        public Student Get(string firstName)
        {
            return _studentcollection.Get(firstName);
        }

        public Student Update(string firstName, Student student)
        {

            return _studentcollection.Update(firstName, student);
        }

        public Student Delete(string firstName)
        {
            return _studentcollection.Delete(firstName);

        }
    }
}
