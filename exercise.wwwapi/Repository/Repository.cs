using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class Repository : IRepository
    {
        #region Students
        public Student AddStudent(Student entity)
        {
            return StudentCollection.Add(entity);
        }

        public bool Delete(string FirstName)
        {
            return StudentCollection.Remove(FirstName);
        }

        public Student GetStudent(string FirstName)
        {
            return StudentCollection.Get(FirstName);
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return StudentCollection.Students;
        }

        public IEnumerable<Student> GetStudents()
        {
            return StudentCollection.Students;
        }
        #endregion


        #region Language
        public Language AddLanguage(Language entity)
        {
            return LanguageCollection.Add(entity);
        }

        //public bool Delete(string FirstName)
        //{
        //    return LanguageCollection.Remove(FirstName);
        //}

        public Language GetLanguage(string FirstName)
        {
            return LanguageCollection.Get(FirstName);
        }

        public IEnumerable<Language> GetAllLanguage()
        {
            return LanguageCollection.Languages;

            #endregion
        }

        public IEnumerable<Language> GetLanguages()
        {
            throw new NotImplementedException();
        }

        public bool DeleteL(string FirstName)
        {
            throw new NotImplementedException();
        }
    }
}
