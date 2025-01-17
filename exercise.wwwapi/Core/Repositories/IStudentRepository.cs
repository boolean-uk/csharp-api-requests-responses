using exercise.wwwapi.Core.Models;

namespace exercise.wwwapi.Core.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        Student GetSingleStudent(string firstName);
        Student AddStudent(Student student);
        bool UpdateStudent(string firstName, Student updatedStudent);
        bool DeleteStudent(string firstName);
    }
}
