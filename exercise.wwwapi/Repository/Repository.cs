using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private StudentCollection _students;
        private LanguageCollection _languages;
        public Repository(StudentCollection studentCollection, LanguageCollection languageCollection)
        {
            _students = studentCollection;
            _languages = languageCollection;
        }

        public Student AddStudent(Student student)
        {
            return _students.Add(student);
        }

        public Student DeleteStudent(string firstName)
        {
            return _students.RemoveStudent(firstName);
        }

        public Student GetStudent(string firstName)
        {
            return _students.GetStudent(firstName);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students.getAll();
        }

        public Student UpdateStudent(string firstName, Student student)
        {
            return _students.UpdateStudent(firstName, student);
        }



        

        public Language AddLanguage(Language language)
        {
            return _languages.Add(language);
        }

        public Language DeleteLanguage(string name)
        {
            return _languages.RemoveLanguage(name);
        }

        public Language GetLanguage(string name)
        {
            return _languages.GetLanguage(name);
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _languages.getAll();
        }

        public Language UpdateLanguage(string name, Language language)
        {
            return _languages.UpdateLanguage(name, language);
        }
    }
}
