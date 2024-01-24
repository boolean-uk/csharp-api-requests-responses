using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Student> GetStudents();

        Student GetStudentByFirstName(string firstName);

        Student PostStudent(string firstName, string lastName);

        Student UpdateStudentByFirstName(string firstName, string newFirstName, string newLastName);

        Student DeleteStudentByFirstName(string firstName);

        Language PostLanguage(string languageName);

        IEnumerable<Language> GetLanguages();

        Language GetSpecificLanguage(string languageName);

        Language UpdateLanguageName(string languageName, string newLanguageName);

        Language DeleteLanguage(string languageName);
    }
}
