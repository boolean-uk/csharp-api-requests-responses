using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        public Language CreateLanguage(string name)
        {
            Language newLanguage = new Language(name) { name = name };
            LanguageCollection.Add(newLanguage);

            return newLanguage;
        }

        public Language DeleteLanguage(string name)
        {
            Language studentToBeDeleted = LanguageCollection.Delete(name);
            return studentToBeDeleted;
        }

        public List<Language> GetAll()
        {
            return LanguageCollection.GetAll();
        }
        public Language GetALanguage(string name)
        {
            return LanguageCollection.GetAll().FirstOrDefault(l => l.name == name);
        }

        public Language UpdateLanguage(string name, string newName)
        {
            Language languageToBeUpdated = LanguageCollection.GetAll().FirstOrDefault(l => l.name == name);
            languageToBeUpdated.name = newName;

            return languageToBeUpdated;
        }
    }
}
