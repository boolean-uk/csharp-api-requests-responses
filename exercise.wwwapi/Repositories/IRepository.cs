using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public interface IRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(string firstName);
        Student CreateStudent(Student student);
        Student UpdateStudent(string firstName, Student updatedStudent);
        Student DeleteStudent(string firstName);
    }
}
