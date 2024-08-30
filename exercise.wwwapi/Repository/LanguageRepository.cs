using exercise.wwwapi.Data;
using exercise.wwwapi.Models;

namespace exercise.wwwapi.Repository
{
    public class LanguageRepository : IRepository<Language, string>
    {
        public List<Language> GetAll()
        {
            return LanguageCollection.GetLanguages();
        }

        public Language GetOne(string name)
        {
            return LanguageCollection.GetALanguage(name);

        }

        public Language Add(Language entity)
        {
            LanguageCollection.AddLanguage(entity);
            return entity;
        }

        public Language Update(string name, Language language)
        {
            return LanguageCollection.UpdateLanguage(name, language);
        }

        public Language Delete(string name)
        {
            return LanguageCollection.DeleteLanguage(name);
        }


    }
}
