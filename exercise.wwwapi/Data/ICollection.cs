using exercise.wwwapi.Models;

namespace exercise.wwwapi.Data
{
    public interface ICollection
    {
        IEnumerable<Student> GetStudents();

        Student GetStudent(string name);

        Student AddStudent(Student student);

        Student UpdateStudentName(string name, Student student);

        Student DeleteStudent(string name);

        IEnumerable<Language> GetLanguages();

        Language GetLanguage(string name);

        Language AddLanguage(string name);

        Language UpdateLanguage(string oldName, string newName);

        Language DeleteLanguage(string name);
    }
}
