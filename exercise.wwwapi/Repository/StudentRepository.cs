using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentCollection _studentDatabase;

        public StudentRepository(StudentCollection studentDatabase)
        {
            _studentDatabase = studentDatabase;
        }
        public IEnumerable<Student> GetStudents()
        {
            return _studentDatabase.GetAll();
        }

        public void AddStudent(Student student)
        {
            _studentDatabase.Add(student);
        }

        public void DeleteStudent(Student student)
        {
            _studentDatabase.Delete(student);
        }
    }
}
