using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IRepository<Student>
    {
        public IEnumerable<Student> GetAll()
        {
            return StudentCollection.GetAll();
        }
        public Student Add(Student student)
        {
            return StudentCollection.Add(student);
        }
        public Student GetOne(string firstname)
        {
            return StudentCollection.GetOne(firstname);
        }
        public bool Delete(string firstname)
        {
            return StudentCollection.Delete(firstname);
        }
    }
}
