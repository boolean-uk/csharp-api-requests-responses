using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataCollection _dataCollection;

        public Repository(DataCollection dataCollection)
        {
            _dataCollection = dataCollection;
        }

        public Language AddLanguage(Language language)
        {
            return _dataCollection.AddLanguage(language);
        }

        public IEnumerable<Language> GetAllLanguages()
        {
            return _dataCollection.GetAllLanguages();
        }

        public Language GetLanguage(string Name)
        {
            return _dataCollection.GetLanguage(Name);
        }

        public Language UpdateLanguage(string Name, Language language)
        {
            return _dataCollection.UpdateLanguage(Name, language);
        }

        public Language DeleteLanguage(string Name)
        {
            return _dataCollection.DeleteLanguage(Name);
        }

        public Student AddStudent(Student student)
        {
            return _dataCollection.AddStudent(student);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _dataCollection.GetAllStudents();
        }

        public Student GetStudent(string firstName)
        {
            return _dataCollection.GetStudent(firstName);
        }

        public Student UpdateStudent(string firstName, Student student)
        {
            return _dataCollection.UpdateStudent(firstName, student);
        }

        public Student DeleteStudent(string firstName)
        {
            return _dataCollection.DeleteStudent(firstName);
        }

    }
}
