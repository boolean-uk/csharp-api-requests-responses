using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student Add(Student student);
        bool Delete(Student student);
    }

    public class StudentRepository : IStudentRepository
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
