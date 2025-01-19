using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository2
    {

        public void AddLanguage(Language language)
        {
            LanguageCollection.AddLanguage(language);
        }

        public List<Language> GetAllLanguages()
        {
            return LanguageCollection.GetAllLanguages();
        }

        public Language GetLanguage(string name)
        {
            return LanguageCollection.GetLanguage(name);
        }

        public Language UpdateLanguage(string oldName, string newName)
        {

            return LanguageCollection.UpdateLanguage(oldName, newName);
        }

        public Language DeleteLanguage(string name)
        {
            return LanguageCollection.DeleteLanguage(name);
        }

    }
}
