using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Student>GetStudents();
        Student GetStudent(string FirstName);
        Student UpdateStudent(string FirstName, string NewFirstName);

        Student DeleteStudent(string FirstName);

        Student CreateStudent(string FirstName, string LastName);

        IEnumerable<Language> GetLanguages();

        Language GetLanguage(string LanguageName);
        Language CreateLanguage(string LanguageName);
        Language UpdateLanguage(string LanguageName, string NewLanguage);
        Language DeleteLanguage(string LanguageName);





    }
}
