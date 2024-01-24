using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private StudentCollection _studentCollection;
        private LanguageCollection _languageCollection;

        public Repository(StudentCollection studentCollection, LanguageCollection languageCollection)
        {
            _studentCollection = studentCollection;
            _languageCollection = languageCollection;
        }
        public IEnumerable<Student> GetStudents()
        {
            return _studentCollection.GetAll();
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _languageCollection.GetAll();
        }

        public Student CreateStudent(Student student)
        {
            return _studentCollection.Add(student);
        }

        public Student GetStudent(string searchInput)
        {
            return _studentCollection.Get(searchInput);
        }

        public Student UpdateStudent(string studentName, string firstName)
        {
            return _studentCollection.Update(studentName, firstName);
        }

        public bool DeleteStudent(string studentName)
        {
            return _studentCollection.Delete(studentName);
        }
    }
}
