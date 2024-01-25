using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {

        Student AddStudent(Student student);
        IEnumerable<Student> GetStudents();

        Student GetStudent(string firstName);

        Student UpdateStudent(string firstName, Student student);

        Student DeleteStudent(string firstName);

        Language AddLanguage(Language language);
        IEnumerable<Language> GetLanguages();

        Language GetLanguage(string name);

        Language UpdateLanguage(string name, Language language);

        Language DeleteLanguage(string name);

    }
}
