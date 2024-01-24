using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public enum StudentQuerryOption
    {
        FirstName,
        LastName,
        FullName,
    }

    public interface IRepository
    {
        IEnumerable<Student> GetStudents();

        Student GetStudent(string name);
        Student CreateStudent(Student student);
        IEnumerable<Language> GetLanguages();
        Student UpdateStudent(string studentName, string firstName);
        bool DeleteStudent(string studentName);
    }
}
