using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IStudentRepository
    {
        List<Student> GetStudents();
        Student GetStudent(string firstName);
    }
}
