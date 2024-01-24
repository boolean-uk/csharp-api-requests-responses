using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataCollection _dataCollection = new DataCollection();
        public Repository(DataCollection DataCollection) 
        {
            _dataCollection = DataCollection;
        }
        public Student GetStudent(string FirstName)
        {
            return _dataCollection.GetStudent(FirstName);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _dataCollection.getAllStudents();
        }

        public Student CreateStudent(string FirstName, string LastName)
        {
            return _dataCollection.CreateStudent(FirstName, LastName);
        }


        public Student UpdateStudent(string FirstName, string NewFirstName)
        {
            return _dataCollection.UpdateStudent(FirstName, NewFirstName);
        }
        public Student DeleteStudent(string FirstName)
        {
            return _dataCollection.DeleteStudent(FirstName);
        }

     
        public Language GetLanguage(string LanguageName)
        {
            return _dataCollection.GetLanguage(LanguageName);
        }
        public IEnumerable<Language> GetLanguages()
        {
            return _dataCollection.GetLanguages();
        }
        public Language CreateLanguage(string LanguageName)
        {
            return _dataCollection.CreateLanguage(LanguageName);
        }
        public Language UpdateLanguage(string LanguageName, string NewLanguage)
        {
           return _dataCollection.UpdateLanguage(LanguageName, NewLanguage);
        }
        public Language DeleteLanguage(string LanguageName)
        {
            return _dataCollection.DeleteLanguage(LanguageName);
        }






    }
}
