using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {

        private ICollection _collection;

        public Repository(ICollection collection)
        {
            _collection = collection;
        }

        public IEnumerable<Student> GetStudents()
        {
            return _collection.GetStudents();
        }

        public Student GetStudent(string name)
        {
            return _collection.GetStudent(name);
        }

        public Student AddStudent(Student student)
        {
            return _collection.AddStudent(student);
        }

        public Student UpdateStudentName(string name, Student student)
        {
            return _collection.UpdateStudentName(name, student);
        }

        public Student DeleteStudent(string name)
        {
            return _collection.DeleteStudent(name);
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _collection.GetLanguages();
        }

        public Language GetLanguage(string name)
        {
            return _collection.GetLanguage(name);
        }

        public Language AddLanguage(string name)
        {
            return _collection.AddLanguage(name);
        }

        public Language UpdateLanguage(string oldName, string newName)
        {
            return _collection.UpdateLanguage(oldName, newName);
        }

        public Language DeleteLanguage(string name)
        {
            return _collection.DeleteLanguage(name);
        }
    }
}
