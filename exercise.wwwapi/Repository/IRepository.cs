using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public interface IRepository
    {
        IEnumerable<Student> GetStudents();
        Student AddStudent(Student student);
        Student GetStudent(string firstName);
        Student DeleteStudent(string firstName);
        Student UpdateStudent(string firstName, Student newStudent);

        IEnumerable<Language> GetLanguages();
        Language AddLanguage(Language language);
        Language GetLanguage(string name);
        Language DeleteLanguage(string name);
        Language UpdateLanguage(string name, Language newLanguage);
    }
}
