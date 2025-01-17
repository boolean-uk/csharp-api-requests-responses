using exercise.wwwapi.Models;
using exercise.wwwapi.Views;

namespace exercise.wwwapi.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetStudent(string name);
        Student? AddStudent(StudentView student);
        Student? UpdateStudent(string name, StudentView studentview);
        Student? DeleteStudent(string name);
    }
}
