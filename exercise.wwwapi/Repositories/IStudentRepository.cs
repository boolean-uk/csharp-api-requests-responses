using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(string LastName);
        bool Delete(string LastName);
        Student AddStudent(Student student);
        Student UpdateStudent(string LastName, Student student);
    }
}
