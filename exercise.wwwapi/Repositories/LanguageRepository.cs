using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repositories
{
    public interface ILanguageRepository
    {
        Language CreateStudent(Language student);
        List<Language> GetAllStudents();
        Language GetStudent(string firstName);
        Language UpdateStudent(string firstName, Language newInfo);
        Language DeleteStudent(string firstName);

    }

    public class LanguageRepository : ILanguageRepository
    {
        private LanguageCollection _languageCollection;
        public LanguageRepository(LanguageCollection lc)
        {
            _languageCollection = lc;
        }

        public Language CreateStudent(Language language)
        {
            _languageCollection.Add(language);
            return language;
        }

        public Language DeleteStudent(string name)
        {
            return _languageCollection.Delete(name);
        }

        public List<Language> GetAllStudents()
        {
            return _languageCollection.getAll();
        }

        public Language GetStudent(string name)
        {
            return _languageCollection.getLanguageByName(name);
        }

        public Language UpdateStudent(string name, Language newInfo)
        {
            return _languageCollection.Update(name, newInfo);
        }
    }
}
