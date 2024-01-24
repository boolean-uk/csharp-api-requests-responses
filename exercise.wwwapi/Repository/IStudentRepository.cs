using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        void AddStudent(Student student);
        void DeleteStudent(Student student);
    }
}
