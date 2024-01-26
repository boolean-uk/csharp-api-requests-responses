using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private IStudentData studentDatabase;
        private ILanguageData languageDatabase;

        public Repository(IStudentData studentDatabase, ILanguageData languageDatabase)
        {
            this.studentDatabase = studentDatabase;
            this.languageDatabase = languageDatabase;
        }

        public Language DeleteLanguage(string name)
        {
            return languageDatabase.Delete(name);
        }

        public Student DeleteStudent(string name)
        {
            return studentDatabase.Delete(name);
        }

        public Language GetLanguageById(string name)
        {
            return languageDatabase.Get(name);
        }

        public IEnumerable<Language> GetLanguages()
        {
            return languageDatabase.GetAll();
        }

        public Student GetStudentById(string name)
        {
            return studentDatabase.Get(name);
        }

        public IEnumerable<Student> GetStudents()
        {
            return studentDatabase.GetAll();
        }

        public Language InsertLanguage(Language language)
        {
            return languageDatabase.Add(language);
        }

        public Student InsertStudent(Student student)
        {
            return studentDatabase.Add(student);
        }

        public Language UpdateLanguage(string name, Language language)
        {
            return languageDatabase.Update(name, language);
        }

        public Student UpdateStudent(string firstName, Student student)
        {
            return studentDatabase.Update(firstName, student);
        }
    }
}
