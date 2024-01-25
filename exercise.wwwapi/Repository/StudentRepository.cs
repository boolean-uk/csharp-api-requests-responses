using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        private IData<Student> _studentDatabase;

        public StudentRepository(IData<Student> studentDatabase)
        {
            _studentDatabase = studentDatabase;
        }


        public Student Get(string firstName)
        {
            return _studentDatabase.Get(firstName);

        }
        public IEnumerable<Student> GetAll()
        {
            return _studentDatabase.GetAll();

        }

        public Student Add(Student student)
        {
            return _studentDatabase.Add(student);
        }

        public Student Update(string firstName, Student student)
        {
            return _studentDatabase.Update(firstName, student);
        }

        public Student Delete(string firstName)
        {
            return _studentDatabase.Delete(firstName);
        }
    }
}
