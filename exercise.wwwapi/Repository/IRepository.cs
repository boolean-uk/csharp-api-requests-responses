using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        Student InsertStudent(Student student);
        Language InsertLanguage(Language language);

        IEnumerable<Student> GetStudents();
        IEnumerable<Language> GetLanguages();

        Student GetStudentById(string firstName);
        Language GetLanguageById(string name);

        Student UpdateStudent(string firstName, Student student);
        Language UpdateLanguage(string name, Language language);

        Student DeleteStudent(string firstName);
        Language DeleteLanguage(string name);
    }
}
