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

        public Student AddStudent(Student student)
        {
            return _dataCollection.AddStudent(student);
        }

        public Student DeleteStudent(string FirstName)
        {
            return _dataCollection.DeleteStudent(FirstName);
        }
        public Student GetOneStudent(string FirstName)
        {
            return _dataCollection.GetOneStudent(FirstName);
        }
        public IEnumerable<Student> GetStudents()
        {
            return _dataCollection.getAllStudents();
        }
        public Student UpdateStudent(string FirstName, Student newStudent)
        {
            return _dataCollection.UpdateStudent(FirstName, newStudent);
        }
        public IEnumerable<Language> GetLanguages()
        {
            return _dataCollection.GetAllLanguages();
        }

        public Language GetOneLanguage(string name)
        {
            return _dataCollection.GetOneLanguage(name);
        }

        public Language AddLanguage(Language language)
        {
            return _dataCollection.AddLanguage(language);
        }

        public Language UpdateLanguage(string name, Language language)
        {
            return _dataCollection.UpdateLanguage(name, language);

        }

        public Language DeleteLanguage(string name)
        {
            return _dataCollection.DeleteLanguage(name);
        }
    }
}
