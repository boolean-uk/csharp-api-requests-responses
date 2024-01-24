using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{

    public class StudentRepository : IRepository<Student>
    {
        private readonly StudentCollection _studentCollection;

        public StudentRepository(StudentCollection studentCollection)
        {
            _studentCollection = studentCollection;
        }

        public List<Student> GetAll()
        {
            return _studentCollection.getAll();
        }

        public Student Add(Student student)
        {
            return _studentCollection.Add(student);
        }

        public bool Delete(Student student)
        {
            return _studentCollection.Delete(student);
        }
    }
}
