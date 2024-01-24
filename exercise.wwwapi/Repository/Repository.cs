using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataCollection _Database;

        public Repository(DataCollection carDatabase)
        {
            _Database = carDatabase;
        }
        public IEnumerable<Student> GetStudents()
        {
            return _Database.getAllStudents();
        }

        public Student AddStudent(Student student)
        {
            return _Database.AddStudent(student);
        }

        public Student GetAStudent(string firstname)
        {
            return _Database.GetStudent(firstname);
        }

        public Student UpdateStudent(string firstname, Student student)
        {
            return _Database.UpdateStudent(firstname, student);
        }

        public Student DeleteAStudent(string firstname)
        {
            return _Database.DeleteStudent(firstname);
        }

        public Language AddLanguage(Language language)
        {
            return _Database.AddLanguage(language);
        }

        public IEnumerable<Language> GetLanguage()
        {
            return _Database.getAllLanguages();
        }

        public Language GetALanguage(string name)
        {
            return _Database.GetLanguage(name);
        }

        public Language UpdateALanguage(string name, Language language)
        {
            return (_Database.UpdateLanguage(name, language));
        }

        public Language DeleteALanguage(string name)
        {
            return _Database.DeleteLanguage(name);
        }
    }
}
