using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Student> getStudentCollections();

        IEnumerable<Language> getLanguageCollections();

        IEnumerable<Student> getStudent(string firstName);

        Student addStudent(string firstName, string lastName);

        Student updateStudent(string firstName, string newFirstName, string newLastName);

        Student deleteStudent(string firstName);

    }
}
